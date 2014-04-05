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

namespace AreaAdministrativa
{
    public partial class ManterNoticiasForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbDica_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                if(string.IsNullOrEmpty(e.Parameter))
                    throw new Exception("Parâmetro de Edição Nulo ou Inválido.");
                    
                string tpOperacao = e.Parameter.ToString();
                
                string titulo = txtTituloDica.Text;
                string descricao = txtDescricaoDica.Text;
                string conteudo = txtConteudo.Html;
                string fonte = txtFonte.Text;
                DateTime dtCriacao = txtDataCriacao.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second).AddMilliseconds(DateTime.Now.Millisecond);
                
                if(tpOperacao.Equals("A"))
                {
                    //Atualçizacao da Noticia
                    //Adiciona o Identificador
                    string idNoticia = hdnIdAtualizacao["id_noticia"].ToString();
                    
                    //Verifica o ID
                    if(string.IsNullOrEmpty(idNoticia))
                        throw new Exception("Falha ao recuperar ID da Notícia.");
                        
                    //Verifica o restante dos dados
                    if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(descricao) || String.IsNullOrEmpty(conteudo) || String.IsNullOrEmpty(fonte))
                        throw new Exception("Campos nulos ou inválidos.");

                    //Atualização da Noticia
                    new NoticiasBU().AtualizarNoticia(idNoticia, titulo, descricao, conteudo, fonte, dtCriacao);
                }
                else
                {
                    //Não será necessário obter o ID
                
                    //Verifica o restante dos dados
                    if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(descricao) || String.IsNullOrEmpty(conteudo) || String.IsNullOrEmpty(fonte))
                        throw new Exception("Campos nulos ou inválidos.");
                    
                    //Inserção da Noticia
                    new NoticiasBU().InserirNoticia(titulo, descricao, conteudo, fonte, dtCriacao);
                }
                

                

                e.Result = "sucesso";
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvNoticias_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                gdvNoticias.DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
