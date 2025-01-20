using Dapper;
using ProjectManagement.Domain.Entities;
using ProjectManagement.Domain.Interfaces;
using System.Data;
using System.Data.SqlClient;

namespace ProjectManagement.Infrastructure.Repositories {
    public class ProjectRepository : IProjectRepository {
        private readonly string _connectionString;

        public ProjectRepository(string connectionString) {
            _connectionString = connectionString;
        }

        public async Task<IEnumerable<Project>> GetAllAsync() {
            using (IDbConnection db = new SqlConnection(_connectionString)) {
                return await db.QueryAsync<Project>("SELECT * FROM Projects");
            }
        }

        public async Task<Project> GetByIdAsync(int id) {
            using (IDbConnection db = new SqlConnection(_connectionString)) {
                return await db.QueryFirstOrDefaultAsync<Project>("SELECT * FROM Projects WHERE Id = @Id", new { Id = id });
            }
        }

        public async Task AddAsync(Project project) {
            using (IDbConnection db = new SqlConnection(_connectionString)) {
                var sql = "INSERT INTO Projects (Name, Description, Deadline) VALUES (@Name, @Description, @Deadline)";
                await db.ExecuteAsync(sql, project);
            }
        }

        public async Task UpdateAsync(Project project) {
            using (IDbConnection db = new SqlConnection(_connectionString)) {
                var sql = "UPDATE Projects SET Name = @Name, Description = @Description, Deadline = @Deadline WHERE Id = @Id";
                await db.ExecuteAsync(sql, project);
            }
        }

        public async Task DeleteAsync(int id) {
            using (IDbConnection db = new SqlConnection(_connectionString)) {
                await db.ExecuteAsync("DELETE FROM Projects WHERE Id = @Id", new { Id = id });
            }
        }
    }
}
