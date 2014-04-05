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
using DevExpress.Web.ASPxUploadControl;
using System.IO;
using DevExpress.Web;
using System.Drawing;
using Business;

namespace AreaAdministrativa
{
    public partial class ManterAlbumFotografiaForm : System.Web.UI.Page
    {
        const string UploadDirectory = "FotosPaginas/";
        //const string ThumbnailFileName = "ThumbnailImage.jpg";
    
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void ucImagem_FileUploadComplete(object sender, DevExpress.Web.ASPxUploadControl.FileUploadCompleteEventArgs e)
        {
            try
            {
                if (!e.IsValid)
                     throw new Exception("Dados de entrada inválidos.");

                string titulo = hdnTituloImagem.Get("titImagem").ToString();
                string descricao = hdnDescricaoImagem.Get("descImagem").ToString();
                
                if(!string.IsNullOrEmpty(titulo) && !string.IsNullOrEmpty(descricao))
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
            string thumbName = uploadedFile.FileName.Substring(0,uploadedFile.FileName.IndexOf('.')) + "_thumb" + uploadedFile.FileName.Substring(uploadedFile.FileName.IndexOf('.'));
                                
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
            
            //Salva os dados no banco
            new AlbumFotosBU().SalvarFoto(Convert.ToInt32(Request.QueryString["idAlbum"].ToString()), titulo, descricao, UploadDirectory, uploadedFile.FileName, UploadDirectory, thumbName);            
        }

        protected void dtFotosAlbum_CustomCallback(object sender, DevExpress.Web.ASPxClasses.CallbackEventArgsBase e)
        {
            try
            {   
                if (e.Parameter.Contains("?"))
                {
                    string[] vet = e.Parameter.Split('?');
                    string idFoto = vet[0];
                    string tpOperacao = vet[1];

                    if (tpOperacao.Equals("D"))
                    {
                        //Deleção do Álbum
                        new AlbumFotosBU().DeletarFoto(idFoto);
                        //e.Result = "Foto deletada com sucesso!";

                    }
                    else
                    {
                        throw new Exception("Parâmetro 'Tipo de Operação' inválido.");
                    }
                }
                
                dtFotosAlbum.DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
