using OnderzoekDapper.models;
using OnderzoekDapper.Repositories.Interfaces;

namespace OnderzoekDapper.Services;

using System.Collections.Generic;
using System.Threading.Tasks;

public class UserService
{
    private readonly IUserRepository _userRepository;

    public UserService(IUserRepository userRepository)
    {
        _userRepository = userRepository;
    }

    public Task<IEnumerable<User>> GetAllUsers()
    {
        return _userRepository.GetAllUsers();
    }
}
