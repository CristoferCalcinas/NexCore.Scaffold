using System.Security.Claims;
using Microsoft.AspNetCore.Http;
using NexCore.Application.Common.Interfaces;

namespace NexCore.Infrastructure.Common.Services;

public sealed class CurrentUserService(IHttpContextAccessor httpContextAccessor) : ICurrentUserService
{
    public string? UserId =>
        httpContextAccessor.HttpContext?.User.FindFirstValue(ClaimTypes.NameIdentifier);
}
