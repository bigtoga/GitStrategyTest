using Microsoft.AspNet.Identity.Owin;
using Tournaments.Models;
using Microsoft.AspNet.Identity;
using Microsoft.Owin.Security;
using System.Threading.Tasks;
using System.Security.Claims;
using Microsoft.Owin;
using Models.Models;

namespace Tournaments.Identity
{
    public class ApplicationSignInManager : SignInManager<User, string>
    {
        public ApplicationSignInManager(UserManager<User, string> userManager, IAuthenticationManager authenticationManager)
            : base(userManager, authenticationManager)
        {

        }

        public override Task<ClaimsIdentity> CreateUserIdentityAsync(User user)
        {
            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
        }

        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
        {
            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
        }
    }
}