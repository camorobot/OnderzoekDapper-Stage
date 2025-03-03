using Microsoft.AspNetCore.Mvc;
using OnderzoekDapper.models;
using OnderzoekDapper.models.Joins;
using OnderzoekDapper.models.SP;
using OnderzoekDapper.Services;

namespace OnderzoekDapper.Controller;

[ApiController]
[Route("api/servers")]
public class ServerController
{
    private readonly ServerService _serverService;

    public ServerController(ServerService serverService)
    {
        _serverService = serverService;
    }

    [HttpGet]
    public Task<IEnumerable<Servers>> GetAllServers()
    {
        return _serverService.GetAllServers();
    }

    [HttpGet("speed/{serverId}")]
    public Task<IEnumerable<ServerSpeed>> GetServerSpeedById(int serverId)
    {
        return _serverService.GetServerSpeedById(serverId);
    }

    [HttpGet("location/{locationName}")]
    public Task<IEnumerable<ServerLocationInfo>> GetLocationsByServer(string locationName)
    {
        return _serverService.GetLocationsByServer(locationName);
    }
}