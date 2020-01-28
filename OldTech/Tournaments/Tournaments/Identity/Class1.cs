//using System;
//using System.Security.Claims;
//using System.Threading.Tasks;
//using System.Web;
//using Microsoft.AspNet.Identity;
//using Microsoft.AspNet.Identity.EntityFramework;
//using Microsoft.AspNet.Identity.Owin;
//using Microsoft.Owin.Security;
//using WebApplication2.Models;
//using Microsoft.Owin;
//using Owin;
//using Microsoft.Owin.Security.Cookies;

//[assembly: OwinStartupAttribute(typeof(WebApplication2.Startup))]
//namespace WebApplication2
//{
//        public partial class Startup
//        {
//            public void Configuration(IAppBuilder app)
//            {
//                ConfigureAuth(app);
//            }
//        }
//}

//namespace WebApplication2.Models
//{


//    // You can add User data for the user by adding more properties to your User class, please visit http://go.microsoft.com/fwlink/?LinkID=317594 to learn more.
//    public class ApplicationUser : IdentityUser
//    {
//        public ClaimsIdentity GenerateUserIdentity(ApplicationUserManager manager)
//        {
//            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
//            var userIdentity = manager.CreateIdentity(this, DefaultAuthenticationTypes.ApplicationCookie);
//            // Add custom user claims here
//            return userIdentity;
//        }

//        public Task<ClaimsIdentity> GenerateUserIdentityAsync(ApplicationUserManager manager)
//        {
//            return Task.FromResult(GenerateUserIdentity(manager));
//        }
//    }

//    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
//    {
//        public ApplicationDbContext()
//            : base("TounamentsDb", throwIfV1Schema: false)
//        {
//        }

//        public static ApplicationDbContext Create()
//        {
//            return new ApplicationDbContext();
//        }
//    }
//}

//#region Helpers
//namespace WebApplication2
//{
//    public static class IdentityHelper
//    {
//        // Used for XSRF when linking external logins
//        public const string XsrfKey = "XsrfId";

//        public const string ProviderNameKey = "providerName";
//        public static string GetProviderNameFromRequest(HttpRequest request)
//        {
//            return request.QueryString[ProviderNameKey];
//        }

//        public const string CodeKey = "code";
//        public static string GetCodeFromRequest(HttpRequest request)
//        {
//            return request.QueryString[CodeKey];
//        }

//        public const string UserIdKey = "userId";
//        public static string GetUserIdFromRequest(HttpRequest request)
//        {
//            return HttpUtility.UrlDecode(request.QueryString[UserIdKey]);
//        }

//        public static string GetResetPasswordRedirectUrl(string code, HttpRequest request)
//        {
//            var absoluteUri = "/Account/ResetPassword?" + CodeKey + "=" + HttpUtility.UrlEncode(code);
//            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
//        }

//        public static string GetUserConfirmationRedirectUrl(string code, string userId, HttpRequest request)
//        {
//            var absoluteUri = "/Account/Confirm?" + CodeKey + "=" + HttpUtility.UrlEncode(code) + "&" + UserIdKey + "=" + HttpUtility.UrlEncode(userId);
//            return new Uri(request.Url, absoluteUri).AbsoluteUri.ToString();
//        }

//        private static bool IsLocalUrl(string url)
//        {
//            return !string.IsNullOrEmpty(url) && ((url[0] == '/' && (url.Length == 1 || (url[1] != '/' && url[1] != '\\'))) || (url.Length > 1 && url[0] == '~' && url[1] == '/'));
//        }

//        public static void RedirectToReturnUrl(string returnUrl, HttpResponse response)
//        {
//            if (!String.IsNullOrEmpty(returnUrl) && IsLocalUrl(returnUrl))
//            {
//                response.Redirect(returnUrl);
//            }
//            else
//            {
//                response.Redirect("~/");
//            }
//        }
//    }
//}
//#endregion



//namespace WebApplication2
//{
//    public class EmailService : IIdentityMessageService
//    {
//        public Task SendAsync(IdentityMessage message)
//        {
//            // Plug in your email service here to send an email.
//            return Task.FromResult(0);
//        }
//    }

//    public class SmsService : IIdentityMessageService
//    {
//        public Task SendAsync(IdentityMessage message)
//        {
//            // Plug in your SMS service here to send a text message.
//            return Task.FromResult(0);
//        }
//    }

//    // Configure the application user manager used in this application. UserManager is defined in ASP.NET Identity and is used by the application.
//    public class ApplicationUserManager : UserManager<ApplicationUser>
//    {
//        public ApplicationUserManager(IUserStore<ApplicationUser> store)
//            : base(store)
//        {
//        }

//        public static ApplicationUserManager Create(IdentityFactoryOptions<ApplicationUserManager> options, IOwinContext context)
//        {
//            var manager = new ApplicationUserManager(new UserStore<ApplicationUser>(context.Get<ApplicationDbContext>()));
//            // Configure validation logic for usernames
//            manager.UserValidator = new UserValidator<ApplicationUser>(manager)
//            {
//                AllowOnlyAlphanumericUserNames = false,
//                RequireUniqueEmail = true
//            };

//            // Configure validation logic for passwords
//            manager.PasswordValidator = new PasswordValidator
//            {
//                RequiredLength = 6,
//                RequireNonLetterOrDigit = false,
//                RequireDigit = false,
//                RequireLowercase = false,
//                RequireUppercase = false,
//            };

//            // Register two factor authentication providers. This application uses Phone and Emails as a step of receiving a code for verifying the user
//            // You can write your own provider and plug it in here.
//            manager.RegisterTwoFactorProvider("Phone Code", new PhoneNumberTokenProvider<ApplicationUser>
//            {
//                MessageFormat = "Your security code is {0}"
//            });
//            manager.RegisterTwoFactorProvider("Email Code", new EmailTokenProvider<ApplicationUser>
//            {
//                Subject = "Security Code",
//                BodyFormat = "Your security code is {0}"
//            });

//            // Configure user lockout defaults
//            manager.UserLockoutEnabledByDefault = true;
//            manager.DefaultAccountLockoutTimeSpan = TimeSpan.FromMinutes(5);
//            manager.MaxFailedAccessAttemptsBeforeLockout = 5;

//            manager.EmailService = new EmailService();
//            manager.SmsService = new SmsService();
//            var dataProtectionProvider = options.DataProtectionProvider;
//            if (dataProtectionProvider != null)
//            {
//                manager.UserTokenProvider = new DataProtectorTokenProvider<ApplicationUser>(dataProtectionProvider.Create("ASP.NET Identity"));
//            }
//            return manager;
//        }
//    }

//    public class ApplicationSignInManager : SignInManager<ApplicationUser, string>
//    {
//        public ApplicationSignInManager(ApplicationUserManager userManager, IAuthenticationManager authenticationManager) :
//            base(userManager, authenticationManager)
//        { }

//        public override Task<ClaimsIdentity> CreateUserIdentityAsync(ApplicationUser user)
//        {
//            return user.GenerateUserIdentityAsync((ApplicationUserManager)UserManager);
//        }

//        public static ApplicationSignInManager Create(IdentityFactoryOptions<ApplicationSignInManager> options, IOwinContext context)
//        {
//            return new ApplicationSignInManager(context.GetUserManager<ApplicationUserManager>(), context.Authentication);
//        }
//    }
//}


//namespace WebApplication2
//{
//    public partial class Startup
//    {

//        // For more information on configuring authentication, please visit http://go.microsoft.com/fwlink/?LinkId=301883
//        public void ConfigureAuth(IAppBuilder app)
//        {
//            // Configure the db context, user manager and signin manager to use a single instance per request
//            app.CreatePerOwinContext(ApplicationDbContext.Create);
//            app.CreatePerOwinContext<ApplicationUserManager>(ApplicationUserManager.Create);
//            app.CreatePerOwinContext<ApplicationSignInManager>(ApplicationSignInManager.Create);

//            // Enable the application to use a cookie to store information for the signed in user
//            // and to use a cookie to temporarily store information about a user logging in with a third party login provider
//            // Configure the sign in cookie
//            app.UseCookieAuthentication(new CookieAuthenticationOptions
//            {
//                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
//                LoginPath = new PathString("/Account/Login"),
//                Provider = new CookieAuthenticationProvider
//                {
//                    OnValidateIdentity = SecurityStampValidator.OnValidateIdentity<ApplicationUserManager, ApplicationUser>(
//                        validateInterval: TimeSpan.FromMinutes(30),
//                        regenerateIdentity: (manager, user) => user.GenerateUserIdentityAsync(manager))
//                }
//            });
//            // Use a cookie to temporarily store information about a user logging in with a third party login provider
//            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

//            // Enables the application to temporarily store user information when they are verifying the second factor in the two-factor authentication process.
//            app.UseTwoFactorSignInCookie(DefaultAuthenticationTypes.TwoFactorCookie, TimeSpan.FromMinutes(5));

//            // Enables the application to remember the second login verification factor such as phone or email.
//            // Once you check this option, your second step of verification during the login process will be remembered on the device where you logged in from.
//            // This is similar to the RememberMe option when you log in.
//            app.UseTwoFactorRememberBrowserCookie(DefaultAuthenticationTypes.TwoFactorRememberBrowserCookie);

//            // Uncomment the following lines to enable logging in with third party login providers
//            //app.UseMicrosoftAccountAuthentication(
//            //    clientId: "",
//            //    clientSecret: "");

//            //app.UseTwitterAuthentication(
//            //   consumerKey: "",
//            //   consumerSecret: "");

//            //app.UseFacebookAuthentication(
//            //   appId: "",
//            //   appSecret: "");

//            //app.UseGoogleAuthentication(new GoogleOAuth2AuthenticationOptions()
//            //{
//            //    ClientId = "",
//            //    ClientSecret = ""
//            //});
//        }
//    }
//}



