<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="ManterPaginaValoresForm.aspx.cs" Inherits="AreaAdministrativa.ManterPaginaValoresForm"
    Title="Oficina SME | Área Administrativa - Manter Página 'Valores'" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxClasses" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxSpellChecker.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxSpellChecker" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxDataView" tagprefix="dx" %>
    
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
<script>
        function ResetarCamposNovoAlbum(){
            txtDescricaoAlbumFotos.SetText("");
            txtDescricaoAlbumFotos.SetIsValid(true);
            txtTituloAlbum.SetIsValid(true);
            txtTituloAlbum.SetText("");
            
        }    
    </script>
     <div style="width: 100%; margin: 15px 0 0 0;">
        <dx:ASPxHiddenField ID="hdnTipoOperacao" runat="server" ClientInstanceName="hdnTipoOperacao">
        </dx:ASPxHiddenField>
        <dx:ASPxPageControl ID="pagControl" runat="server" ActiveTabIndex="0" Width="100%"
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" LoadingPanelText=""
            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" TabSpacing="3px">
            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
            </LoadingPanelImage>
            <ContentStyle>
                <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            </ContentStyle>
            <TabPages>
                <dx:TabPage Text="Conteúdo da Página">
                    <ContentCollection>
                        <dx:ContentControl ID="ContentControl1" runat="server">
                            <dx:ASPxHtmlEditor ID="htmlConteudo" ClientInstanceName="htmlConteudo" Width="100%"
                                runat="server" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                    <ViewArea>
                                        <Border BorderColor="#A3C0E8" BorderStyle="Solid" BorderWidth="1px" />
                                    </ViewArea>
                                </Styles>
                                <StylesToolbars>
                                    <Toolbar ItemSpacing="2px">
                                    </Toolbar>
                                </StylesToolbars>
                                <StylesRoundPanel>
                                    <ControlStyle BackColor="White">
                                        <Border BorderStyle="None" />
                                    </ControlStyle>
                                </StylesRoundPanel>
                                <StylesStatusBar>
                                    <ActiveTab BackColor="White">
                                    </ActiveTab>
                                </StylesStatusBar>
                                <SettingsLoadingPanel Text="" />
                                <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                                    <LoadingPanel Url="~/App_Themes/Aqua/HtmlEditor/Loading.gif">
                                    </LoadingPanel>
                                </Images>
                                <ImagesEditors>
                                    <DropDownEditDropDown>
                                        <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                    </DropDownEditDropDown>
                                    <SpinEditIncrement>
                                        <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditIncrementImageHover_Aqua"
                                            PressedCssClass="dxEditors_edtSpinEditIncrementImagePressed_Aqua" />
                                    </SpinEditIncrement>
                                    <SpinEditDecrement>
                                        <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditDecrementImageHover_Aqua"
                                            PressedCssClass="dxEditors_edtSpinEditDecrementImagePressed_Aqua" />
                                    </SpinEditDecrement>
                                    <SpinEditLargeIncrement>
                                        <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeIncImageHover_Aqua"
                                            PressedCssClass="dxEditors_edtSpinEditLargeIncImagePressed_Aqua" />
                                    </SpinEditLargeIncrement>
                                    <SpinEditLargeDecrement>
                                        <SpriteProperties HottrackedCssClass="dxEditors_edtSpinEditLargeDecImageHover_Aqua"
                                            PressedCssClass="dxEditors_edtSpinEditLargeDecImagePressed_Aqua" />
                                    </SpinEditLargeDecrement>
                                </ImagesEditors>
                                <PartsRoundPanel>
                                    <HeaderLeftEdge>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpHeaderLeftEdge.gif"
                                            Repeat="NoRepeat" VerticalPosition="Top" />
                                    </HeaderLeftEdge>
                                    <HeaderContent>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpHeaderBackground.gif"
                                            Repeat="RepeatX" VerticalPosition="Top" />
                                    </HeaderContent>
                                    <HeaderRightEdge>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpHeaderRightEdge.gif"
                                            Repeat="NoRepeat" VerticalPosition="Top" />
                                    </HeaderRightEdge>
                                    <NoHeaderTopEdge BackColor="White">
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpNoHeaderTopEdge.gif"
                                            Repeat="RepeatX" VerticalPosition="Top" />
                                    </NoHeaderTopEdge>
                                    <TopEdge>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpTopEdge.gif"
                                            Repeat="RepeatX" VerticalPosition="Top" />
                                    </TopEdge>
                                    <RightEdge>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpRightEdge.gif"
                                            Repeat="RepeatY" VerticalPosition="Top" />
                                    </RightEdge>
                                    <BottomEdge>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpBottomEdge.gif"
                                            Repeat="RepeatX" VerticalPosition="Top" />
                                    </BottomEdge>
                                    <LeftEdge>
                                        <BackgroundImage ImageUrl="~/App_Themes/Aqua/HtmlEditor/RoundPanel/herpLeftEdge.gif"
                                            Repeat="RepeatY" VerticalPosition="Top" />
                                    </LeftEdge>
                                </PartsRoundPanel>
                            </dx:ASPxHtmlEditor>
                        </dx:ContentControl>
                    </ContentCollection>
                </dx:TabPage>
                
            </TabPages>
            <Paddings Padding="2px" PaddingLeft="5px" PaddingRight="5px" />
        </dx:ASPxPageControl>
        <br />
        <div style="width: 100%; text-align: center;">
            <dx:ASPxButton ID="btnSalvar" ClientInstanceName="btnSalvar" Width="130px" runat="server"
                Text="Salvar" AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                CssPostfix="Aqua">
                <ClientSideEvents Click="function(s, e) {
	cbSalvarDadosPagina.PerformCallback(hdnTipoOperacao.Get(&quot;tpOperacao&quot;));
}" />
            </dx:ASPxButton>
            <dx:ASPxCallback ID="cbSalvarDadosPagina" runat="server" ClientInstanceName="cbSalvarDadosPagina"
                OnCallback="cbSalvarDadosPagina_Callback">
                <ClientSideEvents BeginCallback="function(s, e) {
	lpCarregando.Show();
}" CallbackComplete="function(s, e) {
	alert(e.result);
	lpCarregando.Hide();
}" CallbackError="function(s, e) {
	e.handled = true;
	alert(e.message);
	lpCarregando.Hide();
}" EndCallback="function(s, e) {
	lpCarregando.Hide();
}" />
            </dx:ASPxCallback>
            <dx:ASPxLoadingPanel ID="lpCarregando" runat="server" ClientInstanceName="lpCarregando"
                HorizontalAlign="Center" Modal="True" Text="Carregando..." VerticalAlign="Middle">
            </dx:ASPxLoadingPanel>
    
      <dx:ASPxPopupControl ID="popNovoAlbum" runat="server" AllowDragging="True" 
                                ClientInstanceName="popNovoAlbum" CloseAction="CloseButton" 
                                CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" FooterText="" 
                                HeaderText="Inserir/Editar Álbum de Fotos" Modal="True" 
                                PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
                                SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="600px" 
                                ShowCloseButton="False">
                                <ContentStyle VerticalAlign="Top">
                                </ContentStyle>
                                <ModalBackgroundStyle BackColor="#333333" Opacity="60">
                                </ModalBackgroundStyle>
                                <ClientSideEvents CloseUp="function(s, e) {
	ResetarCamposNovoAlbum();
}" Closing="function(s, e) {
	ResetarCamposNovoAlbum();
}" />
                                <ContentCollection>
<dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
    <table width="100%" cellpadding="2" cellspacing="2" border="0">
        <tr>
            <td>
                Título do Álbum:
            </td>
        </tr>
        <tr>
            <td>
                <dx:ASPxTextBox ID="txtTituloAlbum" ClientInstanceName="txtTituloAlbum" 
                    runat="server" Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                    CssPostfix="Aqua">
                    <ValidationSettings Display="Dynamic" ErrorText="" SetFocusOnError="True">
                        <ErrorFrameStyle ImageSpacing="4px">
                            <ErrorTextPaddings PaddingLeft="4px" />
                        </ErrorFrameStyle>
                        <RequiredField ErrorText="" IsRequired="True" />
                    </ValidationSettings>
                </dx:ASPxTextBox>
            </td>
        </tr>
        <tr>
             <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                Descrição:
            </td>
        </tr>
        <tr>
            <dx:ASPxMemo ID="txtDescricaoAlbumFotos" runat="server" Height="71px" 
                Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                CssPostfix="Aqua" ClientInstanceName="txtDescricaoAlbumFotos">
                <ValidationSettings Display="Dynamic" ErrorText="" SetFocusOnError="True">
                    <ErrorFrameStyle ImageSpacing="4px">
                        <ErrorTextPaddings PaddingLeft="4px" />
                    </ErrorFrameStyle>
                    <RequiredField ErrorText="" IsRequired="True" />
                </ValidationSettings>
            </dx:ASPxMemo>
        </tr>
        <tr>
             <td>&nbsp;</td>
        </tr>
        <tr>
            <td>
                <div style="width: 250px; margin: 0 auto;">
            <div style="float: left; margin-right: 10px;">
                <dx:ASPxButton ID="btnEnviar" runat="server" Text="Enviar" Width="120px" 
                    AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                    CssPostfix="Aqua">
                    <ClientSideEvents Click="function(s, e) {
	if(txtTituloAlbum.GetIsValid() &amp;&amp; txtDescricaoAlbumFotos.GetIsValid()){
		cpInserirAlbumFoto.PerformCallback();
	}
	else{
		alert(&quot;Os campos 'Título do Álbum' e 'Descrição' são obrigatórios!&quot;);
	}
}" />
                </dx:ASPxButton>
            </div>
            <div style="float: left;">
                <dx:ASPxButton ID="btnCancelar" runat="server" Text="Cancelar" Width="120px" 
                    AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                    CssPostfix="Aqua" CausesValidation="False">
                    <ClientSideEvents Click="function(s, e) {
	              ResetarCamposNovoAlbum();
	popNovoAlbum.Hide();
}" />
                </dx:ASPxButton>
            </div>
        </div>
            </td>
        </tr>
        <tr>
             <td>&nbsp;</td>
        </tr>
    </table>
    <div>
        
    </div>
</dx:PopupControlContentControl>
</ContentCollection>
                            </dx:ASPxPopupControl>
        
        <dx:ASPxCallback runat="server" ClientInstanceName="cpInserirAlbumFoto" ID="cpInserirAlbumFoto" OnCallback="cpInserirAlbumFoto_Callback">
<ClientSideEvents CallbackComplete="function(s, e) {
	alert(&quot;Álbum inserido com sucesso!&quot;);
	popNovoAlbum.Hide();
	lpCarregando.Hide();
	dtFotosPagina.PerformCallback();
}" BeginCallback="function(s, e) {
	lpCarregando.Show();
}" EndCallback="function(s, e) {
	lpCarregando.Hide();
}" CallbackError="function(s, e) {
	e.handled = true;
	alert(e.message);
	lpCarregando.Hide();
}"></ClientSideEvents>
</dx:ASPxCallback>

        </div>
    </div>
</asp:Content>
