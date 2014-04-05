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
using DevExpress.Web.ASPxUploadControl;

namespace AreaAdministrativa
{
    public partial class ManterPaginaEmpresaForm : System.Web.UI.Page
    {
        const string UploadDirectory = "FotosPaginas/";

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!IsPostBack)
                {
                    object obj = new PaginaConteudoBU().RetornaConteudoPagina("empresa");

                    if (obj != null && obj.GetType().Equals(typeof(tblpaginaempresa)))
                    {
                        //Existem dados...
                        tblpaginaempresa pagEmpresa = (tblpaginaempresa)obj;
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

        protected void ucImagem_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            try
            {
                if (!e.IsValid)
                    throw new Exception("Dados de entrada inválidos.");

                string titulo = hdnTituloImagem.Get("titImagem").ToString();
                string descricao = hdnDescricaoImagem.Get("descImagem").ToString();

                if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(descricao))
                    SavePostedFile(e.UploadedFile, titulo, descricao);
                else
                    throw new Exception("Título e Descrição da imagem são campos obrigatórios. Tente novamente!");
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        private void SavePostedFile(UploadedFile uploadedFile, string titulo, string descricao)
        {
            string thumbName = uploadedFile.FileName.Substring(0, uploadedFile.FileName.IndexOf('.')) + "_thumb" + uploadedFile.FileName.Substring(uploadedFile.FileName.IndexOf('.'));

            //Monta o nome do arquivo.    
            string fileName = System.IO.Path.Combine(MapPath(UploadDirectory), thumbName);

            //Recupera a imagem
            using (System.Drawing.Image original = System.Drawing.Image.FromStream(uploadedFile.FileContent))

            //Recupera a imagem no formato menor (thumb)
            using (System.Drawing.Bitmap thumbnail = PhotoUtils.CreateThumbnail(original, 150))
            {
                //Salva o thumb da foto
                PhotoUtils.SaveToJpeg(thumbnail, fileName, 100);
            }

            //Salva o arquivo enviado (foto em tamanho padrao)
            uploadedFile.SaveAs(System.IO.Path.Combine(MapPath(UploadDirectory), uploadedFile.FileName));

            try
            {
                //Inserindo o album
                if (!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(descricao))
                    new AlbumFotosBU().InserirAbum(titulo, descricao, "pag_empresa", UploadDirectory, thumbName, UploadDirectory, uploadedFile.FileName);
                else
                    throw new Exception("Parâmetros nulos ou inválidos. Favor verifique o conteúdo inserido nos campos Título e Descrição do Álbum!");
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
                    new PaginaConteudoBU().AtualizarConteudoPagina("empresa", htmlConteudo.Html);
                    e.Result = "Dados alterados com sucesso!";
                }
                else if (e.Parameter.Equals("I"))
                {
                    //Inclusão
                    new PaginaConteudoBU().InserirConteudoPagina("empresa", htmlConteudo.Html);
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
                dtFotosPagina.DataBind();
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
                if(!string.IsNullOrEmpty(txtTituloAlbum.Text) && !string.IsNullOrEmpty(txtDescricaoAlbumFotos.Text))
                    new AlbumFotosBU().InserirAbum(txtTituloAlbum.Text, txtDescricaoAlbumFotos.Text, "pag_empresa");
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
