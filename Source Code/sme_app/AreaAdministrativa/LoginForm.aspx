<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="LoginForm.aspx.cs" Inherits="AreaAdministrativa.LoginForm" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxRoundPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
    
<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Área Administrativa | Oficina SME</title>
    <link href="UIStyles/LoginForm.css" rel="stylesheet" type="text/css" />

    <script src="UIScripts/LoginForm.js" type="text/javascript"></script>

</head>
<body>
    <form id="form1" runat="server">
    <dx:ASPxPopupControl ID="popRecuperarSenha" runat="server" AllowDragging="True" AppearAfter="200"
        ClientInstanceName="popRecuperarSenha" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
        CssPostfix="Aqua" HeaderText="Recuperar Senha" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css"
        Width="550px" DisappearAfter="300">
        <ContentStyle VerticalAlign="Top">
        </ContentStyle>
        <ModalBackgroundStyle BackColor="#333333" Opacity="60">
        </ModalBackgroundStyle>
        <ClientSideEvents Closing="function(s, e) {
	ClosePopUpRecuperarSenha();
}" />
        <ContentCollection>
            <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                <div id="blocoAvisoRecuperacao">
                    Atenção: Por questões de segurança, informe os seus dados cadastrais e em seguida
                    verifique o seu e-mail. Você receberá uma mensagem contendo uma nova senha de acesso
                    para o sistema.
                </div>
                <table cellpadding="2" cellspacing="2" width="100%" border="0">
                    <tr>
                        <td style="width: 275px;">
                            <dx:ASPxLabel ID="lblLoginRecuperacaoSenha" ClientInstanceName="lblLoginRecuperacaoSenha"
                                runat="server" Text="Login:" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                            </dx:ASPxLabel>
                        </td>
                        <td style="width: 275px;">
                            <dx:ASPxLabel ID="lblEmailRecuperacaoSenha" ClientInstanceName="lblEmailRecuperacaoSenha"
                                runat="server" Text="E-mail de Cadastro:" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                CssPostfix="Aqua">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 275px;">
                            <dx:ASPxTextBox ID="txtLoginRecuperacaoSenha" ClientInstanceName="txtLoginRecuperacaoSenha"
                                runat="server" Width="205px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                CssPostfix="Glass">
                                <ValidationSettings ValidationGroup="recuperacao_senha" Display="Dynamic" ErrorText=""
                                    SetFocusOnError="True">
                                    <ErrorFrameStyle ImageSpacing="4px">
                                        <ErrorTextPaddings PaddingLeft="4px" />
                                    </ErrorFrameStyle>
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td style="width: 275px;">
                            <dx:ASPxTextBox ID="txtEmailRecuperacaoSenha" ClientInstanceName="txtEmailRecuperacaoSenha"
                                runat="server" Width="205px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                CssPostfix="Glass">
                                <ValidationSettings ValidationGroup="recuperacao_senha" Display="Dynamic" ErrorText=""
                                    SetFocusOnError="True">
                                    <ErrorFrameStyle ImageSpacing="4px">
                                        <ErrorTextPaddings PaddingLeft="4px" />
                                    </ErrorFrameStyle>
                                    <RegularExpression ErrorText="E-mail inválido!" ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" />
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="lblCPFRecuperacaoSenha" ClientInstanceName="lblCPFRecuperacaoSenha"
                                runat="server" Text="C.P.F.:" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                CssPostfix="Aqua">
                            </dx:ASPxLabel>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxTextBox ID="txtCPFRecuperacaoSenha" ClientInstanceName="txtCPFRecuperacaoSenha"
                                runat="server" Width="205px" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                CssPostfix="Glass">
                                <MaskSettings Mask="000\.000\.000-00" />
                                <ValidationSettings ValidationGroup="recuperacao_senha" Display="Dynamic" ErrorText=""
                                    SetFocusOnError="True">
                                    <ErrorFrameStyle ImageSpacing="4px">
                                        <ErrorTextPaddings PaddingLeft="4px" />
                                    </ErrorFrameStyle>
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                        <td>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <div style="float: right;">
                                <dx:ASPxButton ID="btnCancelar" ClientInstanceName="btnCancelar" runat="server" AutoPostBack="False"
                                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Text="Cancelar"
                                    Width="100px">
                                    <ClientSideEvents Click="function(s, e) {
	popRecuperarSenha.Hide();
}" />
                                </dx:ASPxButton>
                            </div>
                            <div style="float: right; margin-right: 10px;">
                                <dx:ASPxButton ID="btnRecuperarSenha" ClientInstanceName="btnRecuperarSenha" runat="server"
                                    AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua"
                                    Text="Recuperar Senha" ValidationGroup="recuperacao_senha">
                                    <ClientSideEvents Click="function(s, e) {
	CallbackRecuperarSenha();
}" />
                                </dx:ASPxButton>
                            </div>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <a id="logotipo" title="Área de Administração | Oficina SME"
        href="Default.aspx">
        <img alt="Área de Administração | Oficina SME" src="UIImages/sme-logo.jpg" />
    </a>
    <div id="posicaoBox">
        <dx:ASPxRoundPanel ID="rpPainelLogin" ClientInstanceName="rpPainelLogin" runat="server"
            Width="350px" Height="250px" BackColor="White" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
            CssPostfix="Aqua" HeaderText="Login - Portal Administrativo" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
            <TopEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpTopEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </TopEdge>
            <LeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpLeftEdge.gif" Repeat="RepeatY"
                    VerticalPosition="Top" />
            </LeftEdge>
            <ContentPaddings Padding="14px" />
            <RightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpRightEdge.gif" Repeat="RepeatY"
                    VerticalPosition="Top" />
            </RightEdge>
            <HeaderRightEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </HeaderRightEdge>
            <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            <HeaderLeftEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </HeaderLeftEdge>
            <HeaderStyle BackColor="#E0EDFF">
                <BorderBottom BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            </HeaderStyle>
            <BottomEdge>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpBottomEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Bottom" />
            </BottomEdge>
            <HeaderContent>
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpHeaderBackground.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </HeaderContent>
            <NoHeaderTopEdge BackColor="White">
                <BackgroundImage ImageUrl="~/App_Themes/Aqua/Web/rpNoHeaderTopEdge.gif" Repeat="RepeatX"
                    VerticalPosition="Top" />
            </NoHeaderTopEdge>
            <PanelCollection>
                <dx:PanelContent ID="PanelContent1" runat="server">
                    <table width="100%" cellpadding="2" cellspacing="2" border="0">
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lblLogin" ClientInstanceName="lblLogin" runat="server" Text="Login:"
                                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxTextBox ID="txtLogin" ClientInstanceName="txtLogin" runat="server" Width="205px"
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                    <ValidationSettings ValidationGroup="login" Display="Dynamic" ErrorText="" SetFocusOnError="True">
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                        <RequiredField ErrorText="" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxLabel ID="lblSenha" ClientInstanceName="lblSenha" runat="server" Text="Senha:"
                                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                </dx:ASPxLabel>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxTextBox ID="txtSenha" ClientInstanceName="txtSenha" runat="server" Width="205px"
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass" Password="True">
                                    <ValidationSettings ValidationGroup="login" Display="Dynamic" ErrorText="">
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                        <RequiredField ErrorText="" IsRequired="True" />
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td>
                                &nbsp;
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <div style="float: left; position: relative; top: 5px;">
                                   <% 
                                        /*<dx:ASPxHyperLink ID="lnkRecuperarSenha" runat="server" Text="Recuperar Senha" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                                        CssPostfix="Glass" NavigateUrl="javascript:void(0);">
                                        <ClientSideEvents Click="function(s, e) {
	                                       OpenPopUpRecuperarSenha();
}" />
                                    </dx:ASPxHyperLink> */
                                   %>
                                </div>
                                <div style="float: right;">
                                    <dx:ASPxButton ID="btnLogin" runat="server" Text="Entrar" Width="100px" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                        CssPostfix="Aqua" AutoPostBack="False" ValidationGroup="login">
                                        <ClientSideEvents Click="function(s, e) {
	if(txtLogin.GetIsValid() &amp;&amp; txtSenha.GetIsValid()){
		//Chama o callback
		cbLoginSistema.PerformCallback(txtLogin.GetText() + &quot;#&quot; + txtSenha.GetText());
	}
	else {
		alert(&quot;Atenção: Verifique login e/ou senha e tente novamente!&quot;);
	}
}" />
                                    </dx:ASPxButton>
                                </div>
                            </td>
                        </tr>
                    </table>
                </dx:PanelContent>
            </PanelCollection>
        </dx:ASPxRoundPanel>
        <dx:ASPxCallback ID="cbLoginSistema" runat="server" ClientInstanceName="cbLoginSistema"
            OnCallback="cbLoginSistema_Callback">
            <ClientSideEvents BeginCallback="function(s, e) {
	lpCarregando.Show();
}" CallbackComplete="function(s, e) {
	lpCarregando.Hide();
}" CallbackError="function(s, e) {
	e.handled = true;
	alert(e.message);
	lpCarregando.Hide();
}" EndCallback="function(s, e) {
	lpCarregando.Hide();
}" />
        </dx:ASPxCallback>
        <dx:ASPxCallback ID="cbRecuperarSenhaSistema" runat="server" ClientInstanceName="cbRecuperarSenhaSistema"
            OnCallback="cbRecuperarSenhaSistema_Callback">
            <ClientSideEvents BeginCallback="function(s, e) {
	lpCarregando.Show();
}" CallbackComplete="function(s, e) {
	popRecuperarSenha.Hide();	
	lpCarregando.Hide();
	alert(&quot;Dados recuperados com sucesso! Verifique seu e-mail para visualizar sua nova senha.&quot;);
	
}" CallbackError="function(s, e) {
	e.handled = true;
	alert(e.message);
	lpCarregando.Hide();
}" EndCallback="function(s, e) {
	lpCarregando.Hide();
	popRecuperarSenha.Hide();
}" />
        </dx:ASPxCallback>
        <dx:ASPxLoadingPanel ID="lpCarregando" runat="server" ClientInstanceName="lpCarregando"
            CssFilePath="~/App_Themes/Office2003Blue/{0}/styles.css" CssPostfix="Office2003Blue"
            Modal="True" Text="Carregando...">
            <Image Url="~/App_Themes/Office2003Blue/Web/Loading.gif">
            </Image>
        </dx:ASPxLoadingPanel>
    </div>
    <div id="_rodape">
        <span>&copy; Copyright 2011 - Oficina SME| Todos os direitos reservados.</span>
    </div>
    </form>
</body>
</html>