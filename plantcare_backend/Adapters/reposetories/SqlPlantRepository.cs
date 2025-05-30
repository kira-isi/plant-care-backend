using Application.repositoryInterfaces;
using Domain.entities;
using entities;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Adapters.reposetories
{
    public class SqlPlantRepository : IPlantRepository
    {
        private readonly IDbConnection _connection;

        public SqlPlantRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task AddAsync(Plant plant)
        {
            const string sql = @"
            INSERT INTO Plant (Id, Name, PlantType, Location)
            VALUES (@Id, @Name, @PlantType, @Location)";

            await _connection.ExecuteAsync(sql, new
            {
                Id = plant.Id,
                Name = plant.Name,
                PlantType = plant.PlantTypeId,
                Location = plant.LocationId
            });
        }

        public async Task<Plant?> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT Id, Name, PlantType, Location FROM Plant WHERE Id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync(sql, new { Id = id });

            if (result == null) return null;

            return new Plant(
                result.Id as Guid? ?? Guid.Parse(result.Id.ToString()),
                result.PlantTypeId as Guid? ?? Guid.Parse(result.PlantTypeId.ToString()),
                result.LocationId as Guid? ?? Guid.Parse(result.LocationId.ToString()),
                (string)result.Name
            );
        }

        public async Task<List<Plant>> GetAllAsync()
        {
            const string sql = "SELECT Id, Name, PlantType, Location FROM Plant";
            var results = await _connection.QueryAsync(sql);

            return results.Select(row => new Plant(
                Guid.Parse((string)row.Id),
                Guid.Parse((string)row.PlantType),
                Guid.Parse((string)row.Location),
                (string)row.Name
            )).ToList();
        }

        public async Task UpdateAsync(Plant plant)
        {
            const string sql = @"
            UPDATE Plant
            SET Name = @Name,
                PlantType = @PlantType,
                Location = @Location
            WHERE Id = @Id";

            await _connection.ExecuteAsync(sql, new
            {
                Id = plant.Id,
                Name = plant.Name,
                PlantType = plant.PlantTypeId,
                Location = plant.LocationId
            });
        }

        public async Task DeleteAsync(Plant plant)
        {
            const string sql = "DELETE FROM Plant WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = plant.Id });
        }

        public async Task<IEnumerable<Plant>> GetPlantsByTypeAsync(PlantType plantType)
        {
            const string sql = "SELECT Id, Name, PlantType, Location FROM Plant WHERE PlantType = @PlantTypeId";
            var results = await _connection.QueryAsync(sql, new { PlantTypeId = plantType.Id });

            return results.Select(row => new Plant(
                Guid.Parse((string)row.Id),
                Guid.Parse((string)row.PlantType),
                Guid.Parse((string)row.Location),
                (string)row.Name
            )).ToList();
        }
    }
}