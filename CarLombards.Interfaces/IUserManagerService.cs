using Microsoft.AspNetCore.Identity;

namespace CarLombards.Interfaces;

public interface IUserManagerService
{
    public Task<List<IdentityUser>> GetList(CancellationToken token = default);

    public Task ChangeStatus(string id, bool status, CancellationToken token = default);
}   