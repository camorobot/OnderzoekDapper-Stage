using System.Data;
using Dapper;
using Microsoft.Data.SqlClient;
using OnderzoekDapper.Config;
using OnderzoekDapper.models;
using OnderzoekDapper.models.Joins;
using OnderzoekDapper.models.SP;

namespace OnderzoekDapper.Repositories;

public class ServerRepository
{
    private readonly string _connectionString;

    public ServerRepository(DatabaseConfig dbConfig)
    {
        _connectionString = dbConfig.ConnectionString;
    }
    
    private IDbConnection Connection => new SqlConnection(_connectionString);

    public async Task<IEnumerable<Servers>> GetAllServers()
    {
        using var db = Connection;
        return await db.QueryAsync<Servers>("SELECT * FROM Servers");
    }

    public async Task<IEnumerable<ServerSpeed>> GetServerSpeedById(int serverId)
    {
        using var db = Connection;
        return await db.QueryAsync<ServerSpeed>(
            $"""
             SELECT s.ServerId, s.ServerName, nc.ConnectionType, nc.Bandwidth 
             FROM Servers s 
                 Inner JOIN NetworkConnections nc on s.ServerId = nc.ServerId
             WHERE s.ServerId = @serverId
             """, new {serverId});
    }

    public async Task<IEnumerable<ServerLocationInfo>> GetLocationsByServer(string locationName)
    {
        using var db = Connection;
        var paramenter = new { locationName };

        return await db.QueryAsync<ServerLocationInfo>(
            "GetServersByLocation", 
            paramenter,
            commandType: CommandType.StoredProcedure);
    }
        
}