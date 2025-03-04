using Microsoft.AspNetCore.Mvc;
using OnderzoekDapper.models;

namespace OnderzoekDapper.Repositories.Interfaces;

public interface IUserRepository
{
    Task<IEnumerable<User>> GetAllUsers();
}

