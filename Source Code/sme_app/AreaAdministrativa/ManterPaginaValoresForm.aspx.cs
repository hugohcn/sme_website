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
    public partial class ManterPaginaValoresForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    object obj = new PaginaConteudoBU().RetornaConteudoPagina("valores");

                    if (obj != null && obj.GetType().Equals(typeof(tblvalore)))
                    {
                        //Existem dados...
                        tblvalore pagEmpresa = (tblvalore)obj;
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
                    new PaginaConteudoBU().AtualizarConteudoPagina("valores", htmlConteudo.Html);
                    e.Result = "Dados alterados com sucesso!";
                }
                else if (e.Parameter.Equals("I"))
                {
                    //Inclusão
                    new PaginaConteudoBU().InserirConteudoPagina("valores", htmlConteudo.Html);
                    e.Result = "Dados inseridos com sucesso!";
                }
                else if (e.Parameter.Contains("?"))
                {
                    string[] vet = e.Parameter.Split('?');
                    string idAlbum = vet[0];
                    string tpOperacao = vet[1];

                    if (tpOperacao.Equals("D"))
                    {
                        //Deleção do Álbum
                        new AlbumFotosBU().DeletarAlbumFotos(idAlbum);
                        e.Result = "Álbum deletado com sucesso!";

                    }
                    else
                    {
                        throw new Exception("Parâmetro Tipo de operação inválido.");
                    }
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
                /*
                if (!string.IsNullOrEmpty(txtTituloAlbum.Text) && !string.IsNullOrEmpty(txtDescricaoAlbumFotos.Text))
                    new AlbumFotosBU().InserirAbum(txtTituloAlbum.Text, txtDescricaoAlbumFotos.Text, "pag_valores");
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
