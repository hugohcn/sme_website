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

namespace sme_app
{
    public partial class principal : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Buscando as ultimas noticias
                rptUltimasNoticias.DataSource = new NoticiasBU().Retorna4UltimasNoticiasAposUltima();
                rptUltimasNoticias.DataBind();
                
                //Buscando as ultimas dicas
                rptUltimasDicas.DataSource = new DicasBU().Retorna4UltimasDicasAposUltima();
                rptUltimasDicas.DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
