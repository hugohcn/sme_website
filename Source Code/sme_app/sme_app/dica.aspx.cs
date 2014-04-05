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

namespace sme_app
{
    public partial class dica : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            //Carrega os dados da notícia
            try
            {
                if (!IsPostBack)
                {
                    if (!string.IsNullOrEmpty(Request.QueryString["idDica"]))
                    {
                        tbldica obj = new DicasBU().RetornaDicaById(Convert.ToInt32(Request.QueryString["idDica"]));

                        if (obj != null)
                        {
                            //Seta o nome da página
                            this.Page.Title = "Oficina SME - " + ((tbldica)obj).titulo;

                            //Seta o conteúdo da noticia
                            tituloNoticia.InnerText = ((tbldica)obj).titulo;
                            dtHoraNoticia.InnerText = ((tbldica)obj).dt_criacao.ToLongDateString();
                            contentLoader.InnerHtml = ((tbldica)obj).conteudo;
                            fonteDica.InnerText = ((tbldica)obj).fonte;
                        }
                        else
                        {
                            throw new Exception("Falha ao recuperar os dados da dica: notícia inválida ou inexistente.");
                        }
                    }
                    else
                    {
                        throw new Exception("Falha ao recuperar os dados da dica: parâmetro nulo ou inválido.");
                    }
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
