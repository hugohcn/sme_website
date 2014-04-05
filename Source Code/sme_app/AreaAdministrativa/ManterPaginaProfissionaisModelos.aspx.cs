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

namespace AreaAdministrativa
{
    public partial class ManterPaginaProfissionaisModelos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    object obj = new PaginaConteudoBU().RetornaConteudoPagina("prof_modelos");

                    if (obj != null && obj.GetType().Equals(typeof(tblpaginaprofissionai)))
                    {
                        //Existem dados...
                        tblpaginaprofissionai pagEmpresa = (tblpaginaprofissionai)obj;
                        htmlConteudo.Html = pagEmpresa.conteudo;
                        hdnTipoOperacao.Set("tpOperacao", "A");
                    }
                    else
                    {
                        //Não existem dados
                        hdnTipoOperacao.Set("tpOperacao", "I");
                    }
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void cbSalvarDadosPagina_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                if (e.Parameter == null || string.IsNullOrEmpty(e.Parameter))
                {
                    throw new Exception("Parâmetro nulo ou inválido.");
                }

                if (e.Parameter.Equals("A"))
                {
                    //Alteração
                    new PaginaConteudoBU().AtualizarConteudoPagina("prof_modelos", htmlConteudo.Html);
                    e.Result = "Dados alterados com sucesso!";
                }
                else if (e.Parameter.Equals("I"))
                {
                    //Inclusão
                    new PaginaConteudoBU().InserirConteudoPagina("prof_modelos", htmlConteudo.Html);
                    e.Result = "Dados inseridos com sucesso!";
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void dtFotosPagina_CustomCallback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            try
            {
                //dtFotosPagina.DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void cpInserirAlbumFoto_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                //Inserindo o album
                /*if (!string.IsNullOrEmpty(txtTituloAlbum.Text) && !string.IsNullOrEmpty(txtDescricaoAlbumFotos.Text))
                    new AlbumFotosBU().InserirAbum(txtTituloAlbum.Text, txtDescricaoAlbumFotos.Text, "pag_prof_modelos");
                else
                    throw new Exception("Parâmetros nulos ou inválidos. Favor verifique o conteúdo inserido nos campos Título e Descrição do Álbum!");
                */
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
