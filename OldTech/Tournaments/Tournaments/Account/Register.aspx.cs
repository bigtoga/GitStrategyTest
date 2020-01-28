using Microsoft.AspNet.Identity.Owin;
using System;
using System.Linq;
using System.Web;
using System.Web.UI;
using Tournaments.Models;
using Microsoft.AspNet.Identity;
using Tournaments.Identity;
using Models.Models;

namespace Tournaments.Account
{
    public partial class Register : Page
    {
        protected void CreateUser_Click(object sender, EventArgs e)
        {
            var manager = Context.GetOwinContext().GetUserManager<ApplicationUserManager>();
            var signInManager = Context.GetOwinContext().Get<ApplicationSignInManager>();

            var user = new User()
            {
                UserName = this.UserName.Text,
                Email = this.Email.Text
            };

            IdentityResult result = manager.Create(user, this.Password.Text);
            if (result.Succeeded)
            {
                // For more information on how to enable account confirmation and password reset please visit http://go.microsoft.com/fwlink/?LinkID=320771
                //string code = manager.GenerateEmailConfirmationToken(user.Id);
                //string callbackUrl = IdentityHelper.GetUserConfirmationRedirectUrl(code, user.Id, Request);
                //manager.SendEmail(user.Id, "Confirm your account", "Please confirm your account by clicking <a href=\"" + callbackUrl + "\">here</a>.");

                signInManager.SignIn(user, isPersistent: false, rememberBrowser: false);
                IdentityHelper.RedirectToReturnUrl(Request.QueryString["ReturnUrl"], Response);
            }
            else
            {
                ErrorMessage.Text = result.Errors.FirstOrDefault();
            }
        }

        protected void DropDownListRole_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedDropdownValue = this.DropDownListRole.SelectedValue;

            if(selectedDropdownValue == "sponsor")
            {
                this.PanelUserData.Visible = false;
                this.PanelSponsorData.Visible = true;
            }
            else
            {
                //player and coach have the same required fields
                this.PanelUserData.Visible = true;
                this.PanelSponsorData.Visible = false;
            }
        }
    }
}