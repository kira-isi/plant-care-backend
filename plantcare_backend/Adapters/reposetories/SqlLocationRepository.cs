using Application.repositoryInterfaces;
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
    public class SqlLocationRepository : ILocationRepository
    {
        private readonly IDbConnection _connection;

        public SqlLocationRepository(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<Location?> GetByIdAsync(Guid id)
        {
            const string sql = "SELECT * FROM Locations WHERE Id = @Id";
            var result = await _connection.QuerySingleOrDefaultAsync<Location>(sql, new { Id = id });

            return result == null ? null : new Location(result.Id, result.Name, result.Description);
        }

        public async Task<List<Location>> GetAllAsync()
        {
            const string sql = "SELECT * FROM Locations";
            var results = await _connection.QueryAsync<Location>(sql);
            return results.Select(r => new Location(r.Id, r.Name, r.Description)).ToList();
        }

        public async Task AddAsync(Location entity)
        {
            const string sql = "INSERT INTO Locations (Id, Name, Description) VALUES (@Id, @Name, @Description)";
            await _connection.ExecuteAsync(sql, new
            {
                Id = entity.Id.ToString(),
                entity.Name,
                entity.Description
            });
        }

        public async Task UpdateAsync(Location entity)
        {
            const string sql = "UPDATE Locations SET Name = @Name, Description = @Description WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new
            {
                Id = entity.Id,
                entity.Name,
                entity.Description
            });
        }

        public async Task DeleteAsync(Location entity)
        {
            const string sql = "DELETE FROM Locations WHERE Id = @Id";
            await _connection.ExecuteAsync(sql, new { Id = entity.Id });
        }
    }
}