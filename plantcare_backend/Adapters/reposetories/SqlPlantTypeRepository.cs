using Application.repositoryInterfaces;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;
using System.Runtime.InteropServices.JavaScript;

namespace Adapters.reposetories
{
    public class SqlPlantTypeRepository : IPlantTypeRepository
    {
        private readonly IDbConnection _connection;

        public SqlPlantTypeRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<PlantType?> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM PlantTypes WHERE Id = @Id";
            var plantType = await _connection.QuerySingleOrDefaultAsync<PlantType>(sql, new { Id = id });

            return plantType;
        }

        public async Task<List<PlantType>> GetAllAsync()
        {
            const string sql = "SELECT * FROM PlantTypes";
            var result = await _connection.QueryAsync<PlantType>(sql);
            return result.ToList();
        }

        public async Task AddAsync(PlantType type)
        {
            const string sql = @"INSERT INTO PlantTypes (Id, Name, RequiredWaterAmountMl, WeeklyWateringTimes, NeedsDirectSunlight)
                             VALUES (@Id, @Name, @RequiredWaterAmountMl, @WeeklyWateringTimes, @NeedsDirectSunlight)";
            await _connection.ExecuteAsync(sql, new
            {
                type.Id,
                type.Name,
                type.RequiredWaterAmountMl,
                type.WeeklyWateringTimes,
                type.NeedsDirectSunlight
            });
        }

        public async Task UpdateAsync(PlantType type)
        {
            const string sql = @"UPDATE PlantTypes SET
                             RequiredWaterAmountMl = @RequiredWaterAmountMl,
                             WeeklyWateringTimes = @WeeklyWateringTimes,
                             NeedsDirectSunlight = @NeedsDirectSunlight
                             WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new
            {
                type.Id,
                type.Name,
                type.RequiredWaterAmountMl,
                type.WeeklyWateringTimes,
                type.NeedsDirectSunlight
            });
        }

        public async Task DeleteAsync(PlantType type)
        {
            const string sql = "DELETE FROM PlantTypes WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { type.Id });
        }
    }
}
