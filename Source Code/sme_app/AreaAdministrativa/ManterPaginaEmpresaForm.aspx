<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="ManterPaginaEmpresaForm.aspx.cs" Inherits="AreaAdministrativa.ManterPaginaEmpresaForm"
    Title="Oficina SME | Área Administrativa - Manter Página 'Empresa'" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
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
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxCallback" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxLoadingPanel" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script>
        // <![CDATA[
        function ResetarCamposNovoAlbum(){
            txtDescricaoAlbumFotos.SetText("");
            txtDescricaoAlbumFotos.SetIsValid(true);
            txtTituloAlbum.SetIsValid(true);
            txtTituloAlbum.SetText("");
            
        } 
        
        function ResetaCamposEntrada(){
             txtDescricaoAlbumFotos.SetText("");
             txtDescricaoAlbumFotos.SetIsValid(true);
             txtTituloAlbum.SetText("");
             txtTituloAlbum.SetIsValid(true);
             btnUpload.SetEnabled(true);
        }
        function Uploader_OnUploadStart() {
            btnUpload.SetEnabled(false);
        }
        function Uploader_OnFileUploadComplete(args) {
            alert("Foto adicionada com sucesso!");
            popNovoAlbum.Hide();            
            ResetaCamposEntrada();
            dtFotosPagina.PerformCallback();
        }
        function Uploader_OnFilesUploadComplete(args) {
            alert("Foto adicionada com sucesso!");
            popNovoAlbum.Hide();            
            ResetaCamposEntrada();
            dtFotosPagina.PerformCallback();
        }
        
        function SetarNomeDescricaoImagem(){
            hdnTituloImagem.Set("titImagem", txtTituloAlbum.GetText());
            hdnDescricaoImagem.Set("descImagem", txtDescricaoAlbumFotos.GetText());
        }
    // ]]>    
    </script>

    <dx:ASPxHiddenField ID="hdnTituloImagem" ClientInstanceName="hdnTituloImagem" runat="server">
    </dx:ASPxHiddenField>
    <dx:ASPxHiddenField ID="hdnDescricaoImagem" ClientInstanceName="hdnDescricaoImagem"
        runat="server">
    </dx:ASPxHiddenField>
    <div style="width: 100%; margin: 15px 0 0 0;">
        <dx:ASPxHiddenField ID="hdnTipoOperacao" runat="server" ClientInstanceName="hdnTipoOperacao">
        </dx:ASPxHiddenField>
        <dx:ASPxPageControl ID="pop" runat="server" ActiveTabIndex="0" Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
            CssPostfix="Aqua" LoadingPanelText="" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css"
            TabSpacing="3px">
            <LoadingPanelImage Url="~/App_Themes/Aqua/Web/Loading.gif">
            </LoadingPanelImage>
            <ContentStyle>
                <Border BorderColor="#AECAF0" BorderStyle="Solid" BorderWidth="1px" />
            </ContentStyle>
            <TabPages>
                <dx:TabPage Text="Conteúdo da Página">
                    <ContentCollection>
                        <dx:ContentControl runat="server">
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
                <dx:TabPage Text="Fotos">
                    <ContentCollection>
                        <dx:ContentControl>
                            <br />
                            <dx:ASPxButton ID="btnInserirImagem" ClientInstanceName="btnInserirImagem" runat="server"
                                Text="Nova Foto" AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                CssPostfix="Aqua">
                                <ClientSideEvents Click="function(s, e) {
	popNovoAlbum.Show();
}" />
                            </dx:ASPxButton>
                            <br />
                            <dx:ASPxDataView ID="dtFotosPagina" runat="server" ClientInstanceName="dtFotosPagina"
                                ColumnCount="5" LoadingPanelText="Carregando..." Width="100%" EmptyDataText="Não existem álbum de fotos registrados até o momento. Clique no botão &quot;Novo Álbum de Fotos&quot; para inserir."
                                OnCustomCallback="dtFotosPagina_CustomCallback" DataSourceID="odsAlbumFotoEmpresa">
                                <ItemTemplate>
                                    <div style="text-align: center;">
                                        <a href='javascript:void(0);'
                                            style="text-decoration: none; border: 0;">
                                            <img style="border: 1px solid #999999;" alt='<%# Eval("nome").ToString() + Eval("descricao").ToString() %>'
                                                title='<%# Eval("nome").ToString() + Eval("descricao").ToString() %>' src='<%# Eval("capa_album_path").ToString() + Eval("capa_album_file").ToString() %>' />
                                        </a>
                                        <div style="margin: 5px 0 5px 0; line-height: 19px;">
                                            <a href="javascript:void(0);"
                                                style="text-decoration: none; font-family: Verdana; font-size: 12px; color: #000000;">
                                                <%# Eval("nome") %>
                                            </a>
                                            <br />
                                            <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                                            <br />
                                            <a style="cursor: pointer; color: #666666;" onclick="<%# "cbSalvarDadosPagina.PerformCallback('" + Eval("id_album_foto").ToString() + "?D');" %>">Remover Foto</a>
                                        </div>
                                    </div>
                                </ItemTemplate>
                                <PagerSettings Position="Bottom">
                                    <Summary Text="Página {0} de {1}" />
                                </PagerSettings>
                            </dx:ASPxDataView>
                            <asp:ObjectDataSource ID="odsAlbumFotoEmpresa" runat="server" SelectMethod="RecuperarFotosPagina"
                                TypeName="Business.AlbumFotosBU">
                                <SelectParameters>
                                    <asp:Parameter DefaultValue="pag_empresa" Name="pagina" Type="String" />
                                </SelectParameters>
                            </asp:ObjectDataSource>
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
	dtFotosPagina.PerformCallback();
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
        </div>
    </div>
    <dx:ASPxPopupControl ID="popNovoAlbum" runat="server" AllowDragging="True" ClientInstanceName="popNovoAlbum"
        CloseAction="CloseButton" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua"
        FooterText="" HeaderText="Inserir/Editar Fotos" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css"
        Width="600px">
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
                            Título:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxTextBox ID="txtTituloAlbum" ClientInstanceName="txtTituloAlbum" runat="server"
                                Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
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
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Descrição:
                        </td>
                    </tr>
                    <tr>
                        <dx:ASPxMemo ID="txtDescricaoAlbumFotos" runat="server" Height="71px" Width="100%"
                            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" ClientInstanceName="txtDescricaoAlbumFotos">
                            <ValidationSettings Display="Dynamic" ErrorText="" SetFocusOnError="True">
                                <ErrorFrameStyle ImageSpacing="4px">
                                    <ErrorTextPaddings PaddingLeft="4px" />
                                </ErrorFrameStyle>
                                <RequiredField ErrorText="" IsRequired="True" />
                            </ValidationSettings>
                        </dx:ASPxMemo>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            Capa:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxUploadControl ID="ucImagem" ClientInstanceName="uploader" runat="server"
                                OnFileUploadComplete="ucImagem_FileUploadComplete">
                                <ValidationSettings FileDoesNotExistErrorText="O arquivo do upload não existe." GeneralErrorText="O upload de arquivos falhou devido a um erro externo que não se relaciona com a funcionalidade do ASPxUploadControl."
                                    MaxFileSizeErrorText="Tamanho do arquivo excedeu o tamanho permitido." NotAllowedContentTypeErrorText="O tipo de conteúdo não é permitido."
                                    NotAllowedFileExtensionErrorText="A extensão deste arquivo não é válida." AllowedFileExtensions=".jpg, .jpeg, .jpe, .gif, .png"
                                    MaxFileSize="4194304">
                                </ValidationSettings>
                                <ClientSideEvents FilesUploadComplete="function(s, e) {
	Uploader_OnFilesUploadComplete(e);
}" FileUploadComplete="function(s, e) {
	//Uploader_OnFileUploadComplete(e);
}" FileUploadStart="function(s, e) {
	Uploader_OnUploadStart();
}" />
                                <UploadButton Text="Enviar Foto">
                                </UploadButton>
                                <CancelButton Text="Cancelar">
                                </CancelButton>
                            </dx:ASPxUploadControl>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Text="Tipos de imagens aceitos: jpeg, gif, png"
                                Font-Size="8pt">
                            </dx:ASPxLabel>
                            <br />
                            <dx:ASPxLabel ID="lblMaxFileSize" runat="server" Text="Tamanho máximo permitido: 4Mb"
                                Font-Size="8pt">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <div style="width: 120px; margin: 0 auto;">
                                <dx:ASPxButton ID="btnUpload" runat="server" AutoPostBack="False" Text="Enviar Arquivo"
                                    ClientInstanceName="btnUpload" Width="120px" ClientEnabled="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                    CssPostfix="Aqua">
                                    <ClientSideEvents Click="function(s, e) { 
	if(txtDescricaoAlbumFotos.GetIsValid() &amp;&amp; txtTituloAlbum.GetIsValid()){
		SetarNomeDescricaoImagem();
		uploader.Upload(); 
	}
	else{
		alert(&quot;Atenção: Título e Descrição da Capa do Álbum são necessários.&quot;);
	}
}" />
                                </dx:ASPxButton>
                            </div>
                        </td>
                    </tr>
                    <tr>
                        <td>
                            &nbsp;
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>
    <dx:ASPxCallback runat="server" ClientInstanceName="cpInserirAlbumFoto" ID="cpInserirAlbumFoto"
        OnCallback="cpInserirAlbumFoto_Callback">
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
</asp:Content>
