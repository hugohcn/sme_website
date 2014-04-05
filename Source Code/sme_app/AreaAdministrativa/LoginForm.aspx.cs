using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.HtmlControls;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Xml.Linq;
using Business;
using DevExpress.Web.ASPxClasses;

namespace AreaAdministrativa
{
    public partial class LoginForm : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void cbLoginSistema_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            //Login no sistema
            try
            {
                if (string.IsNullOrEmpty(e.Parameter))
                    throw new Exception("Erro: Falha ao realizar operação de login - Parâmetro é nulo ou inválido.");

                string[] parameters = e.Parameter.Split('#');

                string _login = parameters[0];
                string senha = parameters[1];

                ////Verifica se o usuário está na base de dados.
                var login = new LoginBU().RetornaUsuarioAcessoSistemaPorLoginESenha(_login, senha);

                if (login == null)
                    throw new Exception("Erro: Usuário inválido. Verifique login e/ou senha e tente novamente!");

                //*Cria registro do relatorio de acesso */
                Session["UsuarioLogado"] = login;

                FormsAuthentication.SetAuthCookie(login.login, false);

                string redirect = FormsAuthentication.GetRedirectUrl(login.login, false);
                ASPxWebControl.RedirectOnCallback(redirect);
            }
            catch (Exception eX)
            {
                throw eX;
            } 
        }

        protected void cbRecuperarSenhaSistema_Callback(object source, DevExpress.Web.ASPxCallback.CallbackEventArgs e)
        {
            //Recuperação de Senha
            /*try
            {
                if (string.IsNullOrEmpty(e.Parameter))
                    throw new Exception("Erro: Falha ao executar operação de recuperação de senha - Parâmetros nulos ou inválidos.");

                string[] parameters = e.Parameter.Split('#');

                string login = parameters[0];
                string email = parameters[1];
                string cpf = parameters[2];

                //Busca pelo login do usuário
                var user = new UsuarioSistemaBU().RetornaUsuarioByLogin(login);

                if (user != null)
                {
                    //valida o usuário antes de efetuar a troca
                    var membro = new MembroBU().RetornaMembroPorCpfEEmail(cpf, email);

                    if (membro == null)
                        throw new Exception("Erro: Validação do membro incompleta. Verifique os dados e tente novamente!");

                    //Gera uma nova senha para o usuário
                    string nPass = new SecurityCommon().GerarHash(7);
                    user.senha = new SecurityCommon().EncriptarObjeto(nPass);

                    //Atualiza o usuário do membro
                    new UsuarioSistemaBU().AtualizarDadosUsuario(user);

                    //Envia o e-mail para o usuário
                    EmailConfig configMailCliente = new EmailConfig();

                    configMailCliente.Nome = "Portal Nova Aliança - SIG";
                    configMailCliente.Assunto = "Recuperação de Senha";
                    configMailCliente.Email1 = membro.email;
                    configMailCliente.IsBodyHtml = true;
                    configMailCliente.Prioridade = PrioridadeEmail.Alta;

                    StringBuilder sbEmailCliente = new StringBuilder();

                    sbEmailCliente.Append(@"
                                            <table width='100%' cellpadding='2' cellspacing='2' border='0'>
	                                            <tr>
		                                            <td>
			                                            <a>
				                                            <img alt='Portal Nova Aliança - www.portalnovaalianca.com' src='http://www.portalnovaalianca.com/images/logotipo_adna.png' />
			                                            </a>
		                                            </td>
		                                            <td style='line-height: 17px;'>
		                                                <div style='float: right;'>
			                                                <span style='font-family: Verdana; font-size: 11px; color: #7eacb1;'>
				                                                Assembléia de Deus Nova Aliança
			                                                </span>
			                                                <br/>
			                                                <span style='font-family: Verdana; font-size: 11px; color: #7eacb1;'>
				                                                Rua Duque de Caxias, nº 232, Centro de Vitória/ES
			                                                </span>
			                                                <br/>
			                                                <span style='font-family: Verdana; font-size: 11px; color: #7eacb1;'>
				                                                Telefone: (27) 3222.9132
			                                                </span>
			                                            </div>
		                                            </td>
	                                            </tr>
	                                            <tr>
		                                            <td colspan='2'>&nbsp;</td>
	                                            </tr>
	                                            <tr>
		                                            <td colspan='2' style='font-family: Verdana; font-size: 11px; color: #666666;'>
			                                            <span>
				                                            Olá " + membro.nome + @"!
			                                            </span>
			                                            <br/>
			                                            <br/>
			                                            <span>
				                                            Esta é uma mensagem automática gerada pelos nossos servidores. Favor não respondê-la!
			                                            </span>
			                                            <br/>
			                                            <br/>
			                                            <span>
				                                            Foi feita uma solicitação de recuperação de senha no Portal Administrativo da Igreja Assembléia de Deus Nova Aliança.
			                                            </span>
			                                            <br/>
			                                            <br/>
			                                            <span>
				                                            Sua nova senha é:
			                                            </span>
			                                            <br/>
			                                            <span>
				                                            " + nPass + @"
			                                            </span>
			                                            <br/>
			                                            <br/>
			                                            <span>
				                                            Caso não consiga acessar o sistema, entre em contato com o administrador do sistema através do e-mail webmaster@portalnovaalianca.com.
			                                            </span>
			                                            <br/>
			                                            <br/>
			                                            <span style='font-size: 9px;'>
				                                            Mensagem gerada automaticamente.
			                                            </span>
			                                            <br/>
			                                            <span style='font-size: 9px;'>
				                                            Sistema Integrado Administrativo / webmaster@portalnovaalianca.com / www.portalnovaalianca.com
			                                            </span>
                                        				
		                                            </td>
	                                            </tr>
                                            </table>
                                        ");

                    configMailCliente.Mensagem = sbEmailCliente.ToString();
                    EmailSender.SendMail(configMailCliente);
                }
                else
                {
                    throw new Exception("Erro: Usuário incorreto. Verifique os dados e tente novamente!");
                }
            }
            catch (Exception eX)
            {
                throw eX;
            } */
        }
    }
}
