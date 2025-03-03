using OnderzoekDapper.models;
using OnderzoekDapper.models.Joins;
using OnderzoekDapper.models.SP;
using OnderzoekDapper.Repositories;

namespace OnderzoekDapper.Services;

public class ServerService
{
    private readonly ServerRepository _repository;

    public ServerService(ServerRepository repository)
    {
        _repository = repository;
    }

    public Task<IEnumerable<Servers>> GetAllServers()
    {
        return _repository.GetAllServers();
    }

    public Task<IEnumerable<ServerSpeed>> GetServerSpeedById(int serverId)
    {
        return _repository.GetServerSpeedById(serverId);
    }

    public Task<IEnumerable<ServerLocationInfo>> GetLocationsByServer(string locationName)
    {
        return _repository.GetLocationsByServer(locationName);
    }
}