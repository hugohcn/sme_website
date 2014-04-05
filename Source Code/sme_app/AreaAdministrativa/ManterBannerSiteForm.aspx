<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="ManterBannerSiteForm.aspx.cs" Inherits="AreaAdministrativa.ManterBannerSiteForm"
    Title="Oficina SME | Área Administrativa - Manter Banners do Site" %>

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
            alert("Foto adicionada ao álbum com sucesso!");
            popNovoAlbum.Hide();            
            ResetaCamposEntrada();
            dtFotosPagina.PerformCallback();
        }
        function Uploader_OnFilesUploadComplete(args) {
            alert("Foto adicionada ao álbum com sucesso!");
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
    
    <br />
    <div style="width: 100%; margin: 15px 0 0 0;">
        <dx:ASPxHiddenField ID="hdnTituloImagem" ClientInstanceName="hdnTituloImagem" runat="server">
        </dx:ASPxHiddenField>
        <dx:ASPxHiddenField ID="hdnDescricaoImagem" ClientInstanceName="hdnDescricaoImagem"
            runat="server">
        </dx:ASPxHiddenField>
        <dx:ASPxButton ID="btnInserirImagem" ClientInstanceName="btnInserirImagem" runat="server"
            Text="Novo Banner" AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
            CssPostfix="Aqua">
            <ClientSideEvents Click="function(s, e) {
	popNovoAlbum.Show();
}" />
        </dx:ASPxButton>
        <br />
        <dx:ASPxDataView ID="dtFotosPagina" runat="server" ClientInstanceName="dtFotosPagina"
            ColumnCount="5" LoadingPanelText="Carregando..." Width="100%" EmptyDataText="Não existem álbum de fotos registrados até o momento. Clique no botão &quot;Novo Álbum de Fotos&quot; para inserir."
            OnCustomCallback="dtFotosPagina_CustomCallback" DataSourceID="odsBanners">
            <ItemTemplate>
                <div style="text-align: center;">
                    
                        <img style="border: 1px solid #999999;" alt='<%# Eval("nome").ToString() + " - " + Eval("descricao").ToString() %>'
                            title='<%# Eval("nome").ToString() + " - " + Eval("descricao").ToString() %>' src='<%# Eval("path_thumb").ToString() + Eval("nome_arquivo_thumb").ToString() %>' />
                    <div style="margin: 5px 0 5px 0; line-height: 19px;">
                       <div style="text-decoration: none; font-family: Verdana; font-size: 12px; color: #000000;">
                            <%# Eval("nome") %>
                        </div>
                        <br />
                        <asp:Label ID="descricaoLabel" runat="server" Text='<%# Eval("descricao") %>' />
                        <br />
                        <a style="cursor: pointer; color: red;" onclick="<%# "cbSalvarDadosPagina.PerformCallback('" + Eval("id_banner").ToString() + "?D');" %>">
                            Remover Banner</a>
                    </div>
                </div>
            </ItemTemplate>
            <PagerSettings Position="Bottom">
                <Summary Text="Página {0} de {1}" />
            </PagerSettings>
        </dx:ASPxDataView>
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
        <asp:ObjectDataSource ID="odsBanners" runat="server" SelectMethod="RetornaTodosBanners"
            TypeName="Business.BannerSiteBU">
        </asp:ObjectDataSource>
        <dx:ASPxPopupControl ID="popNovoAlbum" runat="server" AllowDragging="True" ClientInstanceName="popNovoAlbum"
            CloseAction="CloseButton" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua"
            FooterText="" HeaderText="Inserir Banner" Modal="True" PopupHorizontalAlign="WindowCenter"
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
                                Título do Banner:
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
                                Capa do Banner:
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
                            <td style="padding: 10px;">
                                <dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Text="Tipos de imagens aceitos: jpeg, gif, png"
                                    Font-Size="8pt">
                                </dx:ASPxLabel>
                                <br />
                                <dx:ASPxLabel ID="lblMaxFileSize" runat="server" Text="Tamanho máximo permitido: 4Mb"
                                    Font-Size="8pt">
                                </dx:ASPxLabel>
                                <br />
                                <dx:ASPxLabel ID="lblTamanhoBanner" runat="server" Text="O tamanho ideal para o banner é de: 940x220 px."
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
		alert(&quot;Atenção: Título e Descrição da Capa do Banner são necessários.&quot;);
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
	alert(&quot;Banner inserido com sucesso!&quot;);
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
</asp:Content>
