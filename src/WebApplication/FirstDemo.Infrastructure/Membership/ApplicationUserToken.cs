using System;

using Microsoft.AspNetCore.Identity;

namespace FirstDemo.Infrastructure.Membership
{
    public class ApplicationUserToken
        : IdentityUserToken<Guid>
    {

    }
}
