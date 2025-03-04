using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using OnderzoekDapper.models;
using OnderzoekDapper.Services;

namespace OnderzoekDapper.Controller;

[ApiController]
[Route("api/users")]
public class UserController
{
    private readonly UserService _userService;

    public UserController(UserService userService)
    {
        this._userService = userService;
    }

    [HttpGet]
    public Task<IEnumerable<User>> GetUsers()
    {
        return _userService.GetAllUsers();
    }
}