using CarLombards.Domain;
using CarLombards.Interfaces;
using CarLombards.DAL;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace CarLombards.Services;

public class UserManagerService : IUserManagerService
{
    private readonly UserManager<IdentityUser> _userManager;

    public UserManagerService(UserManager<IdentityUser> userManager)
    {
        _userManager = userManager;
    }

    public async Task<List<IdentityUser>> GetList(CancellationToken token = default)
    {
        return await _userManager.Users.ToListAsync(token);
    }

    public async Task ChangeStatus(string id, bool status, CancellationToken token = default)
    {
        var user = await _userManager.Users.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (user is null)
            throw new Exception($"Can't find user with id == {id}");
        user.EmailConfirmed = status;
        await _userManager.UpdateAsync(user);
    }
}