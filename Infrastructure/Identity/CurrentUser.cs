using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using Application.Common;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using PrivatSchoolsAPI.Infrastructure.Identity;

namespace Infrastructure.Identity
{
    public class CurrentUser(IHttpContextAccessor httpContextAccessor) : ICurrentUser
    {
        public string? UserId =>
            httpContextAccessor.HttpContext?.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
    }
}
