using Microsoft.Data.SqlClient;
using OnderzoekDapper.models;
using OnderzoekDapper.Repositories.Interfaces;

namespace OnderzoekDapper.Repositories;

using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Threading.Tasks;
using Dapper;

public class DapperUserRepository : IUserRepository
{
    private readonly string _connectionString;

    public DapperUserRepository(string connectionString)
    {
        _connectionString = connectionString;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT TOP(200000) Id, First_name, Last_name, Email, password_hash FROM dbo.Users";
            return await db.QueryAsync<User>(sql);
        }
    }

    public async Task<User> GetUserById(string id)
    {
        using (IDbConnection db = new SqlConnection(_connectionString))
        {
            string sql = "SELECT * FROM dbo.Users WHERE Id = @Id";
            return await db.QuerySingleOrDefaultAsync<User>(sql, new { Id = id });
        }
    }

    // public async Task<User> GetUsersHomeAddress(string id)
    // {
    //     string sql = "SELECT u.Id, u.First_name, u.Last_name, a.Id, a.Street FROM Users u INNER JOIN Addresses a ON u.Id = a.UserId";
    //     var users = connection.Query<User, Address, User>(sql, (user, address) => {
    //         user.Address = address;
    //         return user;
    //     }, splitOn: "Id");
    // }
}
