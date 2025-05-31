using Application.repositoryInterfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.entities;
using Domain.valueObjects.careTaskDetails;
using System.Data;
using Dapper;
using Domain.valueObjects;
using Domain;
using System.Text.Json;
using System.Numerics;

namespace Adapters.reposetories
{
    public class SqlCarePlanRepository : ICarePlanRepository
    {
        private readonly IDbConnection _connection;

        public SqlCarePlanRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<CarePlan?> GetByIdAsync(Guid id)
        {
            //Tasks
            const string sqlTask = "SELECT * FROM CareTasks WHERE CarePlanId = @Id";
            var tasksOut = await _connection.QueryAsync(sqlTask, new { Id = id });

            var careTasks = new List<CareTask>();

            foreach (var row in tasksOut)
            {
                CareType type = CareTypeFactory.FromString((string)row.CareType);
                ICareTaskDetails details = type switch
                {
                    Watering => JsonSerializer.Deserialize<WateringDetails>((string)row.DetailsJson)
                        ?? throw new InvalidOperationException("Deserialization of WateringDetails returned null."),

                    Fertilizing => JsonSerializer.Deserialize<FertilizingDetails>((string)row.DetailsJson)
                        ?? throw new InvalidOperationException("Deserialization of FertilizingDetails returned null."),

                    _ => throw new InvalidOperationException($"Unsupported care type {type}")
                };


                CareTask task = row.ScheduledDate != null
                    ? CareTaskFactory.CreateScheduled(type, details, DateTime.Parse((string)row.ScheduledDate), row.IsCompleted)
                    : CareTaskFactory.CreateRecurring(type, details, TimeSpan.FromDays((int)row.IntervalDays), DateTime.Parse((string)row.LastPerformed));

                careTasks.Add(task);
            }

            //Name
            const string sqlName = "SELECT Name FROM CarePlan WHERE CarePlanId = @Id";
            string? name = await _connection.QuerySingleOrDefaultAsync<string>(sqlName, new { Id = id });

            //Plants
            const string sqlPlant = "SELECT Id FROM Plants WHERE CarePlanId = @Id";
            var plants = (await _connection.QueryAsync<Guid>(sqlPlant, new { Id = id })).ToList();

            return new CarePlan(id, name, careTasks, plants);
        }

        public async Task<List<CarePlan>> GetAllAsync()
        {
            // 1. Alle CarePlans laden
            const string sqlCarePlans = "SELECT CarePlanId, Name FROM CarePlan";
            var carePlansRaw = await _connection.QueryAsync(sqlCarePlans);

            // 2. Alle CareTasks laden
            const string sqlTasks = "SELECT * FROM CareTasks";
            var allTasks = await _connection.QueryAsync(sqlTasks);

            // 3. Alle Plants laden
            const string sqlPlants = "SELECT Id, CarePlanId FROM Plants";
            var allPlants = await _connection.QueryAsync(sqlPlants);

            var carePlans = new List<CarePlan>();

            foreach (var planRow in carePlansRaw)
            {
                Guid planId = Guid.Parse((string)planRow.CarePlanId);
                string name = (string)planRow.Name;

                // Zuordnen: alle Tasks für diesen Plan
                List<CareTask> tasks = allTasks
                    .Where(t => (string)t.CarePlanId == planId.ToString())
                    .Select(row =>
                    {
                        CareType type = CareTypeFactory.FromString((string)row.CareType);
                        ICareTaskDetails details = type switch
                        {
                            Watering => JsonSerializer.Deserialize<WateringDetails>((string)row.DetailsJson)
                                ?? throw new InvalidOperationException("Deserialization of WateringDetails returned null."),
                            Fertilizing => JsonSerializer.Deserialize<FertilizingDetails>((string)row.DetailsJson)
                                ?? throw new InvalidOperationException("Deserialization of FertilizingDetails returned null."),
                            _ => throw new InvalidOperationException($"Unsupported care type {type}")
                        };

                        CareTask task = row.ScheduledDate != null
                            ? CareTaskFactory.CreateScheduled(type, details, DateTime.Parse((string)row.ScheduledDate), row.IsCompleted)
                            : CareTaskFactory.CreateRecurring(type, details, TimeSpan.FromDays((int)row.IntervalDays), DateTime.Parse((string)row.LastPerformed));

                        return task;
                    })
                    .ToList();

                // Zuordnen: alle Plant-IDs für diesen Plan
                List<Guid> plantIds = allPlants
                    .Where(p => (string)p.CarePlanId == planId.ToString())
                    .Select(p => Guid.Parse((string)p.Id))
                    .ToList();

                carePlans.Add(new CarePlan(planId, name, tasks, plantIds));
            }

            return carePlans;
        }



        public async Task AddAsync(CarePlan plan)
        {
            // 1. CarePlan einfügen
            const string sql = "INSERT INTO CarePlan (CarePlanId, Name) VALUES (@Id, @Name)";
            await _connection.ExecuteAsync(sql, new { Id = plan.Id.ToString(), Name = plan.Name });

            // 2. Pflanzen zuordnen
            foreach (var plantId in plan.Plants)
            {
                await _connection.ExecuteAsync(
                    "UPDATE Plants SET CarePlanId = @CarePlanId WHERE Id = @Id",
                    new { CarePlanId = plan.Id, Id = plantId });
            }

            // 3. Tasks einfügen
            foreach (var task in plan.TaskList)
            {
                var common = new
                {
                    Id = task.Id.ToString(),
                    CarePlanId = plan.Id,
                    Type = task.Type.ToString(),
                    DetailsJson = JsonSerializer.Serialize(task.Details)
                };

                if (task is RecurringCareTask recurring)
                {
                    await _connection.ExecuteAsync(@"
                    INSERT INTO CareTasks 
                    (Id, CarePlanId, CareType, DetailsJson, IntervalDays, LastPerformed)
                    VALUES (@Id, @CarePlanId, @Type, @DetailsJson, @IntervalDays, @LastPerformed)",
                        new
                        {
                            Id = common.Id.ToString(),
                            CarePlanId = common.CarePlanId.ToString(),
                            common.Type,
                            common.DetailsJson,
                            IntervalDays = (int)recurring.Interval.TotalDays,
                            LastPerformed = recurring.LastPerformed.ToString("s") // ISO-8601 Format
                        });
                }
                else if (task is ScheduledCareTask scheduled)
                {
                    await _connection.ExecuteAsync(@"
                INSERT INTO CareTasks 
                (Id, CarePlanId, CareType, DetailsJson, ScheduledDate, IsCompleted)
                VALUES (@Id, @CarePlanId, @Type, @DetailsJson, @ScheduledDate, @IsCompleted)",
                        new
                        {
                            common.Id,
                            common.CarePlanId,
                            common.Type,
                            common.DetailsJson,
                            ScheduledDate = scheduled.ScheduledDate.ToString("s"),
                            IsCompleted = scheduled.IsCompleted ? 1 : 0
                        });
                }
            }
        }


        public async Task UpdateAsync(CarePlan plan)
        {
            await DeleteAsync(plan);
            await AddAsync(plan);
        }

        public async Task DeleteAsync(CarePlan plan)
        {
            await _connection.ExecuteAsync("DELETE FROM CareTasks WHERE CarePlanId = @Id", new { Id = plan.Id });
            await _connection.ExecuteAsync("UPDATE Plants SET CarePlanId = NULL WHERE CarePlanId = @Id", new { Id = plan.Id });
            await _connection.ExecuteAsync("DELETE FROM CarePlans WHERE Id = @Id", new { Id = plan.Id });
        }

        public Task<IEnumerable<CarePlan>> GetPlansWithDueAsync() =>
            Task.FromResult<IEnumerable<CarePlan>>(new List<CarePlan>()); // TODO

        public Task<IEnumerable<CarePlan>> GetPlansWithOverdueAsync() =>
            Task.FromResult<IEnumerable<CarePlan>>(new List<CarePlan>()); // TODO
    }
}
