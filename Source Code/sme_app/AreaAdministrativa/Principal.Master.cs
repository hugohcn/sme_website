using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;

namespace AreaAdministrativa
{
    public partial class Principal : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ASPxMenu1_ItemClick(object source, DevExpress.Web.ASPxMenu.MenuItemEventArgs e)
        {
            try
            {
                //Destroi todos os tickets existentes
                FormsAuthentication.SignOut();

                //Limpa as sessões existentes
                Session.Clear();

                //Redireciona para a página principal
                FormsAuthentication.RedirectToLoginPage();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
