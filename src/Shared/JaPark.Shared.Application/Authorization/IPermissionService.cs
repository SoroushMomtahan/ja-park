namespace LearnTop.Shared.Application.Authorization;

public interface IPermissionService
{
    Task<HashSet<string>> GetPermissionsAsync(Guid memberId);
}
