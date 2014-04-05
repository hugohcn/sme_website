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
using Common;

namespace sme_app
{
    public partial class contato : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            txtNomeUsuario.Focus();
        }

        protected void cbEnviarMensagem_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            //Começa a configuração do objeto de envio de e-mail.
            EmailConfig config = new EmailConfig();
            config.Nome = txtNomeUsuario.Text;
            config.Email1 = txtEmailusuario.Text;
            config.TelefoneContato = txtTelefone.Text;
            config.IsBodyHtml = true;
            string msgHtml = @"
                                                <h1>Novo Contato!</h1>
                                                <br/><br/><b>Remetente:</b> " + txtEmailusuario.Text + @"
                                                <br/><br/><b>Nome:</b> " + txtNomeUsuario.Text + @"
                                                <br/><br/><b>Telefone de Contato:</b> " + txtTelefone.Text + @"
                                                <br/><br/><b>Assunto:" + txtAssunto.Text + @"</b>
                                                <br/><br/><b>Mensagem:</b> " + txtMensagem.Text;

            config.Mensagem = msgHtml;
            config.Prioridade = PrioridadeEmail.Alta;
            
            try
            {
                //Envia e-mail.
                EmailSender.SendMail(config);
            }
            catch (Exception eX)
            {
                ScriptManager.RegisterStartupScript(Page, Page.GetType(), Guid.NewGuid().ToString(), "alert('Erro: Impossível enviar mensagem. Verifique os dados e tente novamente.');", true);
            }
        }
    }
}
