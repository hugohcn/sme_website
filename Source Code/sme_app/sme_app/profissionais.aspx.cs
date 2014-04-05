using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Business;
using Sme.Data;
using SubSonic.Schema;

namespace sme_app
{
    public partial class profissionais : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Recupera conteudo da página
                object obj = new PaginaConteudoBU().RetornaConteudoPagina("pag_prof_modelos");
                
                if(obj != null)
                    contentLoader.InnerHtml = ((tblpaginaprofissionai)obj).conteudo;
                else
                    throw new Exception("Falha ao carregar dados da página.");
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
