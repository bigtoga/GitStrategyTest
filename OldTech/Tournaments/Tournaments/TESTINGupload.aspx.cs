using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tournaments
{
    public partial class TESTINGupload : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.labelPictureUrl.Text = (string)Session["Url"];
        }
    }
}