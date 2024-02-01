using Microsoft.AspNetCore.Identity;
using System;

namespace FirstDemo.Infrastructure.Membership
{
    public class ApplicationRole : IdentityRole<Guid>
    {
        public ApplicationRole()
            : base()
        {
        }

        public ApplicationRole(string roleName)
            : base(roleName)
        {
        }
    }
}
