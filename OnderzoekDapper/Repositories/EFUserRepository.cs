using OnderzoekDapper.DBContext;
using OnderzoekDapper.models;
using OnderzoekDapper.Repositories.Interfaces;

namespace OnderzoekDapper.Repositories;

using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

public class EFUserRepository : IUserRepository
{
    private readonly AppDbContext _context;

    public EFUserRepository(AppDbContext context)
    {
        _context = context;
    }

    public async Task<IEnumerable<User>> GetAllUsers()
    {
        return await _context.Users.OrderBy(u => u.Id).Take(200000).ToListAsync();
    }
}


