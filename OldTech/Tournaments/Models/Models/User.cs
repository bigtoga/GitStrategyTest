using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Tournaments.Models;

namespace Models.Models
{
    public class User: IdentityUser
    {
        public ClaimsIdentity GenerateUserIdentity(UserManager<User> manager)
        {
            // note the authenticationtype must match the one defined in cookieauthenticationoptions.authenticationtype
            var useridentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
            // add custom user claims here
            return useridentity;
        }

        public Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<User> manager)
        {
            return Task.FromResult(GenerateUserIdentity(manager));
        }
    }
}
