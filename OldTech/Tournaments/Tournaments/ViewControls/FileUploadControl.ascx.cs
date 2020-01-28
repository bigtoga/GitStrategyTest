using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tournaments.Models;
using Tournaments.Models_project;
using Tournaments.Presenters;
using Tournaments.Views;
using WebFormsMvp;
using WebFormsMvp.Web;

namespace Tournaments.ViewControls
{
    public partial class FileUploadControl : System.Web.UI.UserControl
    {
        //public event EventHandler<GetUserAvatarEventArgs> EventGetUserAvatar;
        //public event EventHandler<AvatarUploadEventArgs> EventUploadAvatar;
        //public string FileUrl { get; private set; }
        //http://stackoverflow.com/questions/6495395/how-to-create-a-custom-event-for-a-user-control-in-webforms
        //http://stackoverflow.com/questions/3486377/how-to-add-an-event-to-a-usercontrol-in-c
        //public delegate void TextChangedEventHandler(object sender, EventArgs e);
        //public event TextChangedEventHandler LabelTextChanged;

        //-------- grab a copy of the subscriber list(to keep it thread safe)
        //var myEvent = this.LabelTextChanged;

        //-------- check there are subscribers, and trigger if necessary
        //if (myEvent != null)
        //myEvent(this, new MyNewEventArgs(....));

        protected void Page_Load(object sender, EventArgs e)
        {
            //ScriptManager.GetCurrent(this.Page).RegisterPostBackControl(this.UploadAvatarBtn);
            //if (!this.IsPostBack)
            //{
            //    this.EventGetUserAvatar(this, new GetUserAvatarEventArgs() { LoggedUseUserName = this.Context.User.Identity.Name });
            //    this.UserAvatar.ImageUrl = this.Model.UserAvatarUrl;
            //}
        }

        protected void UploadFileBtn_Click(object sender, EventArgs e)
        {
            if (this.FileUpload.HasFile)
            {
                //var loggedUserUserName = this.Context.User.Identity.Name;
                HttpPostedFile postedFile = this.FileUpload.PostedFile;
                HttpPostedFileBase file = new HttpPostedFileWrapper(postedFile);

                string extension = Path.GetExtension(postedFile.FileName);
                string filename = "loggedUserUserName" + extension;

                string fileStoragePath = Server.MapPath("~/UploadedFiles/Pictures/") + filename;
                string userAvatarUrl = "~/UploadedFiles/Pictures/" + filename;

                file.SaveAs(fileStoragePath);
                Session["Url"]=userAvatarUrl;
                //this.EventUploadAvatar(this, new AvatarUploadEventArgs()
                //{
                //    LoggedUserUserName = loggedUserUserName,
                //    PostedFile = file,
                //    AvatarStorateLocation = avatarStoragePath,
                //    UserAvatarUrl = userAvatarUrl
                //});


                this.Notifier.NotifySuccess("File uploaded successfully");
            }
            else
            {
                this.Notifier.NotifyError("Please choose a file");
            }
        }
    }
}