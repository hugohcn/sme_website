<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="contato.aspx.cs" Inherits="sme_app.contato" Title="Oficina SME | Contato" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
    
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <link href="UIStyles/basic.css" rel="stylesheet" type="text/css" />
    <!-- IE6 "fix" for the close png image -->
    <!--[if lt IE 7]>
    <link type='text/css' href='css/basic_ie.css' rel='stylesheet' media='screen' />
    <![endif]-->

    <script src="UIScripts/jquery.simplemodal.js" type="text/javascript"></script>
    
    <script type="text/javascript">
        
        function resetFields(){
            txtNomeUsuario.SetText("");
	        txtEmailusuario.SetText("");
	        txtTelefone.SetText("");
	        txtCidadeEstado.SetText("");
	        txtAssunto.SetText("");
	        txtMensagem.SetText("");

	        txtNomeUsuario.SetIsValid(true);
	        txtEmailusuario.SetIsValid(true);
	        txtTelefone.SetIsValid(true);
	        txtCidadeEstado.SetIsValid(true);
	        txtAssunto.SetIsValid(true);
	        txtMensagem.SetIsValid(true);

	        txtNomeUsuario.Focus();
        }
    </script>
    
    <div id="lContentContato">
        <label class="titulo_bloco">
            Formulário de Contato</label>
            <div id="contatoForm">
                <table cellpadding="2" cellspacing="2" border="0">
                    <tr>
                        <td style="width: 341px;">Nome</td>
                        <td>E-mail</td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxTextBox ID="txtNomeUsuario" ClientInstanceName="txtNomeUsuario" CssClass="txtBoxPadrao" EnableDefaultAppearance="false" runat="server" Width="292px">
                                <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="contato">
                                    <ErrorFrameStyle ImageSpacing="3px">
                                        <Paddings PaddingLeft="3px" />
                                    </ErrorFrameStyle>
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtEmailusuario" ClientInstanceName="txtEmailusuario" 
                                CssClass="txtBoxPadrao" EnableDefaultAppearance="false" runat="server" 
                                Width="282px">
                                <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="contato">
                                    <RegularExpression ErrorText="" 
                                        ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td style="width: 341px;">Telefone</td>
                        <td>Cidade/Estado</td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxTextBox ID="txtTelefone" ClientInstanceName="txtTelefone" CssClass="txtBoxPadrao" EnableDefaultAppearance="false" runat="server" Width="292px">
                                <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="contato">
                                    <RequiredField ErrorText="" />
                                </ValidationSettings>
                                <MaskSettings Mask="(00) 0000-0000" />
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                            <dx:ASPxTextBox ID="txtCidadeEstado" ClientInstanceName="txtCidadeEstado" 
                                CssClass="txtBoxPadrao" EnableDefaultAppearance="false" runat="server" 
                                Width="282px">
                                <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="contato">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                     </tr>
                     <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                     <tr>
                        <td colspan="2">
                            Assunto
                        </td>
                     </tr>
                     <tr>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtAssunto" ClientInstanceName="txtAssunto" 
                                CssClass="txtBoxPadrao" EnableDefaultAppearance="false" runat="server" 
                                Width="623px">
                                <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="contato">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                     </tr>
                     <tr>
                        <td colspan="2">&nbsp;</td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Mensagem
                        </td>
                     </tr>
                     <tr>
                        <td colspan="2">
                            <dx:ASPxMemo ID="txtMensagem" ClientInstanceName="txtMensagem" 
                                CssClass="txtBoxPadrao" runat="server" Height="130px"  Width="623px">
                                <ValidationSettings Display="Dynamic" ErrorText="" ValidationGroup="contato">
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxMemo>
                        </td>
                     </tr>
                </table>  
                <br />
                <div style="width: 623px;">
                    <!-- botão da direita -->
                    <div style="float: right;">
                        <dx:ASPxButton ID="btnEnviar" runat="server" 
                            BackgroundImage-ImageUrl="~/UIImages/btnEnviar.jpg" Cursor="pointer" 
                            EnableDefaultAppearance="False" Width="76px" Height="23px" 
                            Border-BorderStyle="None" AutoPostBack="False" ValidationGroup="contato">
                            <ClientSideEvents Click="function(s, e) {
	if(
	txtNomeUsuario.GetIsValid() &amp;&amp; 
	txtEmailusuario.GetIsValid() &amp;&amp;
	txtTelefone.GetIsValid() &amp;&amp;
	txtCidadeEstado.GetIsValid() &amp;&amp;
	txtAssunto.GetIsValid() &amp;&amp;
	txtMensagem.GetIsValid()
	){
		cbEnviarMensagem.PerformCallback();
	}
	else{
		alert(&quot;Dados incorretos: Valide todos os campos e tente novamente.&quot;);
	}
}" />
<BackgroundImage ImageUrl="~/UIImages/btnEnviar.jpg"></BackgroundImage>

<Border BorderStyle="None"></Border>
                        </dx:ASPxButton>                        
                    </div>                    
                    <div style="float: right; margin-right: 10px;">
                        <dx:ASPxButton ID="btnLimpar" runat="server" 
                            BackgroundImage-ImageUrl="~/UIImages/btnLimpar.jpg" Cursor="pointer" 
                            EnableDefaultAppearance="False" Width="76px" Height="23px" 
                            Border-BorderStyle="None" AutoPostBack="False" CausesValidation="False">
                            <ClientSideEvents Click="function(s, e) {
	resetFields();
}" />
<BackgroundImage ImageUrl="~/UIImages/btnLimpar.jpg"></BackgroundImage>

<Border BorderStyle="None"></Border>
                        </dx:ASPxButton>                        
                    </div> 
                    <dx:ASPxLoadingPanel ID="lpCarregando" runat="server" 
                        ClientInstanceName="lpCarregando" HorizontalAlign="Center" Modal="True" 
                        Text="Enviando mensagem..." VerticalAlign="Middle">
                        <LoadingDivStyle BackColor="#000000">
                        </LoadingDivStyle>
                    </dx:ASPxLoadingPanel>
                    <dx:ASPxCallback ID="cbEnviarMensagem" runat="server" 
                        ClientInstanceName="cbEnviarMensagem" oncallback="cbEnviarMensagem_Callback">
                        <ClientSideEvents BeginCallback="function(s, e) {
	lpCarregando.Show();
}" CallbackComplete="function(s, e) {
	resetFields();
	alert(&quot;Sua mensagem foi enviada com sucesso!&quot;);
	lpCarregando.Hide();
}" CallbackError="function(s, e) {
	e.handled = true;
	alert(&quot;Erro:&quot; + e.message);
	lpCarregando.Hide();
}" EndCallback="function(s, e) {
	lpCarregando.Hide();
}" />
                    </dx:ASPxCallback>
                </div>          
            </div>
    </div>
    <div id="rContentContato">
        <label class="titulo_bloco">
            Nosso Endereço</label>
        <div id="blocoEndereco">
            <span>Rua Antônio Aleixo, nº 705</span>
            <br />
            <span>Consolação - Vitória / ES</span>
            <br />
            <span>CEP: 29.045-660</span>
        </div>
        <br />
        <label class="titulo_bloco">
            Outros Contatos</label>
        <div id="blocoOutrosContatos">
            <div>
                <img alt="" src="UIImages/btnTelephone.png" style="float: left;" />
                &nbsp; <span>(27) 3222.6166 / (27) 9316.5150</span></div>
            <div class="clear">
                &nbsp;</div>
            <div style="margin-top: 10px;">
                <img alt="" src="UIImages/btnEmail.png" style="float: left;" />
                &nbsp; <span style="position: relative; top: 2px;">contato@oficinasme.com.br</span></div>
            <div id="blocoMidiasSociaisContato">
                <a href="javascript:void(0);" target="_blank">
                    <img alt="Facebook da Oficina SME." title="Facebook da Oficina SME." src="UIImages/button_facebook.jpg" /></a>
                <a href="javascript:void(0);" target="_blank">
                    <img alt="Siga-nos no Twitter." title="Siga-nos no Twitter." src="UIImages/button_twitter.jpg" /></a>
                <a href="javascript:void(0);" target="_blank">
                    <img alt="Assista o nosso canal no Youtube." title="Assista o nosso canal no Youtube."
                        src="UIImages/button_youtube.jpg" /></a> <a href="javascript:void(0);" target="_blank">
                            <img alt="Nos adicione no orkut." title="Nos adicione no orkut." src="UIImages/button_orkut.jpg" /></a>
            </div>
        </div>
        <br />
        <label class="titulo_bloco">
            Nossa Localização</label>
        <a href="javascript:void(0);" id="lnkLocalizacao" target="_self" style="margin-top: 12px; display: block;">
            <img alt="Nossa Localização" title="Nossa Localização" src="UIImages/banner_nossa_localizacao_contato.jpg" />
        </a>
    </div>
    <div class="clear" >&nbsp;</div>
    <!-- modal box -->
    <div id="basic-modal-content">
        <iframe width="600" height="360" frameborder="0" scrolling="no" marginheight="0" marginwidth="0" src="http://www.google.com.br/maps?f=q&amp;source=s_q&amp;hl=pt-BR&amp;geocode=+&amp;q=Oficina+Sme&amp;ie=UTF8&amp;hq=Oficina+Sme&amp;hnear=Vit%C3%B3ria+-+Esp%C3%ADrito+Santo&amp;t=m&amp;vpsrc=0&amp;cid=16698599861151183699&amp;ll=-20.308811,-40.312271&amp;spn=0.028978,0.051413&amp;z=14&amp;iwloc=A&amp;output=embed"></iframe><br /><small><a href="http://www.google.com.br/maps?f=q&amp;source=embed&amp;hl=pt-BR&amp;geocode=+&amp;q=Oficina+Sme&amp;ie=UTF8&amp;hq=Oficina+Sme&amp;hnear=Vit%C3%B3ria+-+Esp%C3%ADrito+Santo&amp;t=m&amp;vpsrc=0&amp;cid=16698599861151183699&amp;ll=-20.308811,-40.312271&amp;spn=0.028978,0.051413&amp;z=14&amp;iwloc=A" style="color:#0000FF;text-align:left">Exibir mapa ampliado</a></small>
    </div>
    
    <!-- preload the images -->
	<div style='display:none'>
		<img src="UIImages/BasicModal/basic/x.png" alt="Fechar" />
	</div>
	<div class="clear" style="height: 20px;">
        &nbsp;</div>
</asp:Content>
