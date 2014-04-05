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
    public partial class ManterDicasForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbDica_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(e.Parameter))
                    throw new Exception("Parâmetro de Edição Nulo ou Inválido.");

                string tpOperacao = e.Parameter.ToString();

                string titulo = txtTituloDica.Text;
                string descricao = txtDescricaoDica.Text;
                string conteudo = txtConteudo.Html;
                string fonte = txtFonte.Text;

                DateTime dtCriacao = txtDataCriacao.Date.AddHours(DateTime.Now.Hour).AddMinutes(DateTime.Now.Minute).AddSeconds(DateTime.Now.Second).AddMilliseconds(DateTime.Now.Millisecond); ;

                if (tpOperacao.Equals("A"))
                {
                    //Atualçizacao da Dica
                    //Adiciona o Identificador
                    string idDica = hdnIdAtualizacao["id_dica"].ToString();

                    //Verifica o ID
                    if (string.IsNullOrEmpty(idDica))
                        throw new Exception("Falha ao recuperar ID da Notícia.");

                    //Verifica o restante dos dados
                    if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(descricao) || String.IsNullOrEmpty(conteudo) || String.IsNullOrEmpty(fonte))
                        throw new Exception("Campos nulos ou inválidos.");
                        
                    //Atualizando Dica
                    new DicasBU().AtualizarDica(idDica, titulo, descricao, conteudo, fonte, dtCriacao);
                }
                else
                {
                    //Inserção da Dica
                    if (String.IsNullOrEmpty(titulo) || String.IsNullOrEmpty(descricao) || String.IsNullOrEmpty(conteudo) || String.IsNullOrEmpty(fonte))
                        throw new Exception("Campos nulos ou inválidos.");

                    new DicasBU().InserirDica(titulo, descricao, conteudo, fonte, dtCriacao);
                }
                
                e.Result = "sucesso";
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void gdvDicas_CustomCallback(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewCustomCallbackEventArgs e)
        {
            try
            {
                gdvDicas.DataBind();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
