using Microsoft.AspNetCore.Identity;
using PrivatSchoolsAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrivatSchoolsAPI.Infrastructure.Identity
{
    public class ApplicationUser : IdentityUser
    {
        public string FullName { get; set; }

        public IsActive IsActive { get; set; } = IsActive.Active;

    }
    public enum IsActive
    {
        Active = 1,
        Inactive = 2
    }
}
