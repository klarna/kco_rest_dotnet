using System;
using System.Threading.Tasks;

using System.Collections.Generic;
using Client = Klarna.Rest.Core.Klarna;
using Klarna.Rest.Core.Common;
using Klarna.Rest.Core.Commuication;
using Klarna.Rest.Core.Model;
using Klarna.Rest.Core.Model.Enum;

namespace WebForms
{

    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs args)
        {
            
        }

        public void checkoutClicked(object sender, EventArgs args)
        {
            Response.Redirect("Checkout.aspx");
        }
    }
}
