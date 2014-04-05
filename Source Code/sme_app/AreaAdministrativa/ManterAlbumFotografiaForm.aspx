<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="ManterAlbumFotografiaForm.aspx.cs" Inherits="AreaAdministrativa.ManterAlbumFotografiaForm"
    Title="Oficina SME | Área Administrativa - Manter Fotos" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxHiddenField" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxUploadControl" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxDataView" TagPrefix="dx" %>
<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxPopupControl" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    
    <script src="UIScripts/prototype.js" type="text/javascript"></script>
    <script src="UIScripts/lightbox.js" type="text/javascript"></script>
    <script src="UIScripts/scriptaculous.js?load=effects,builder" type="text/javascript"></script>
    
    <div style="width: 100%; margin: 15px 0 0 0;">
        <br />
        <dx:ASPxHiddenField ID="hdnTituloImagem" ClientInstanceName="hdnTituloImagem" runat="server">
        </dx:ASPxHiddenField>
        <dx:ASPxHiddenField ID="hdnDescricaoImagem" ClientInstanceName="hdnDescricaoImagem"
            runat="server">
        </dx:ASPxHiddenField>
        <dx:ASPxButton ID="btnInserirFoto" runat="server" Text="Inserir Foto" Width="120px"
            AutoPostBack="False" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
            <ClientSideEvents Click="function(s, e) {
	popInserirFoto.Show();
}" />
        </dx:ASPxButton>
        <br />
        <dx:ASPxDataView ID="dtFotosAlbum" runat="server" Width="100%" DataSourceID="odsFotosAlbum"
            EmptyDataText="Não existem fotos registradas até o momento." LoadingPanelText="Carregando.."
            ClientInstanceName="dtFotosAlbum" OnCustomCallback="dtFotosAlbum_CustomCallback"
            ColumnCount="5">
            <ItemStyle BackColor="White">
                <Border BorderStyle="None" />
            </ItemStyle>
            <ItemTemplate>
                <div style="border: 1px solid #c3c3c3; text-align: center; padding: 10px;">
                    <div style="width: 150px; margin: 0 auto;">
                        <a href='<%# Eval("path_thumb").ToString() + Eval("arquivo").ToString() %>'
                            title='<%# Eval("nome")%>' rel="lightbox[roadtrip]" style="border: 0; text-decoration: none;">
                            <img width="150px" height="150px" style="border: 0;" alt='<%# Eval("nome")+ " - " +  Eval("descricao") %>'
                                src='<%# Eval("path_thumb").ToString() + Eval("arquivo_thumb").ToString() %>' />
                        </a>
                    </div>
                    <div style="display: block; margin: 10px 0 0 0;">
                        <dx:ASPxLabel ID="lblNome" runat="server" Text='<%# Eval("nome")%>'>
                        </dx:ASPxLabel>
                    </div>
                    <br />
                    <dx:ASPxLabel ID="ASPxLabel1" runat="server" Text='<%# Eval("descricao")%>'>
                    </dx:ASPxLabel>
                    <br />
                    <a style="cursor: pointer; color: #666666;" onclick="<%# "dtFotosAlbum.PerformCallback('" + Eval("id_foto").ToString() + "?D');" %>">Remover Foto</a>
                </div>
            </ItemTemplate>
            <PagerSettings Position="Bottom">
                <Summary Text="Página {0} de {1}" />
            </PagerSettings>
        </dx:ASPxDataView>
        <asp:ObjectDataSource ID="odsFotosAlbum" runat="server" SelectMethod="RecuperarFotosPagina"
            TypeName="Business.AlbumFotosBU">
            <SelectParameters>
                <asp:QueryStringParameter Name="idAlbum" QueryStringField="idAlbum" Type="Int32" />
            </SelectParameters>
        </asp:ObjectDataSource>
    </div>
    <dx:ASPxPopupControl ID="popInserirFoto" runat="server" AllowDragging="True" ClientInstanceName="popInserirFoto"
        CloseAction="CloseButton" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua"
        FooterText="" HeaderText="Inserir Foto" Modal="True" PopupHorizontalAlign="WindowCenter"
        PopupVerticalAlign="WindowCenter" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css"
        Width="500px">
        <ContentStyle VerticalAlign="Top">
        </ContentStyle>
        <ModalBackgroundStyle BackColor="#333333" Opacity="60">
        </ModalBackgroundStyle>
        <ContentCollection>
            <dx:PopupControlContentControl runat="server">
                <table width="100%" cellpadding="2" cellspacing="2" border="0">
                    <tr>
                        <td colspan="2">
                            Título da Imagem:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtTituloImagem" ClientInstanceName="txtTituloImagem" runat="server"
                                Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                <ValidationSettings Display="Dynamic" ErrorText="">
                                    <ErrorFrameStyle ImageSpacing="4px">
                                        <ErrorTextPaddings PaddingLeft="4px" />
                                    </ErrorFrameStyle>
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Descrição da Imagem:
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxTextBox ID="txtDescricaoImagem" ClientInstanceName="txtDescricaoImagem" runat="server"
                                Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                <ValidationSettings Display="Dynamic" ErrorText="">
                                    <ErrorFrameStyle ImageSpacing="4px">
                                        <ErrorTextPaddings PaddingLeft="4px" />
                                    </ErrorFrameStyle>
                                    <RequiredField ErrorText="" IsRequired="True" />
                                </ValidationSettings>
                            </dx:ASPxTextBox>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            &nbsp;
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            Upload da Imagem:
                        </td>
                    </tr>
                    <tr>
                        <td>
                            <dx:ASPxUploadControl ID="ucImagem" ClientInstanceName="uploader" runat="server"
                                CancelButtonHorizontalPosition="Right" Size="40" OnFileUploadComplete="ucImagem_FileUploadComplete">
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
                        <td>
                            <dx:ASPxButton ID="btnUpload" runat="server" AutoPostBack="False" Text="Enviar Arquivo"
                                ClientInstanceName="btnUpload" Width="120px" ClientEnabled="True" CssFilePath="~/App_Themes/Aqua/{0}/styles.css"
                                CssPostfix="Aqua">
                                <ClientSideEvents Click="function(s, e) { 
	if(txtDescricaoImagem.GetIsValid() &amp;&amp; txtTituloImagem.GetIsValid()){
		SetarNomeDescricaoImagem();
		uploader.Upload(); 
	}
	else{
		alert(&quot;Atenção: Título e Descrição da Imagem são necessários.&quot;);
	}
}" />
                            </dx:ASPxButton>
                        </td>
                    </tr>
                    <tr>
                        <td colspan="2">
                            <dx:ASPxLabel ID="lblAllowebMimeType" runat="server" Text="Tipos de imagens aceitos: jpeg, gif, png"
                                Font-Size="8pt">
                            </dx:ASPxLabel>
                            <br />
                            <dx:ASPxLabel ID="lblMaxFileSize" runat="server" Text="Tamanho máximo permitido: 4Mb"
                                Font-Size="8pt">
                            </dx:ASPxLabel>
                        </td>
                    </tr>
                </table>
            </dx:PopupControlContentControl>
        </ContentCollection>
    </dx:ASPxPopupControl>

    <script type="text/javascript">
    // <![CDATA[
        function ResetaCamposEntrada(){
             txtDescricaoImagem.SetText("");
             txtDescricaoImagem.SetIsValid(true);
             txtTituloImagem.SetText("");
             txtTituloImagem.SetIsValid(true);
             btnUpload.SetEnabled(true);
        }
        function Uploader_OnUploadStart() {
            btnUpload.SetEnabled(false);
        }
        function Uploader_OnFileUploadComplete(args) {
            alert("Foto adicionada ao álbum com sucesso!");
            popInserirFoto.Hide();            
            ResetaCamposEntrada();
            dtFotosAlbum.PerformCallback();
        }
        function Uploader_OnFilesUploadComplete(args) {
            alert("Foto adicionada ao álbum com sucesso!");
            popInserirFoto.Hide();            
            ResetaCamposEntrada();
            dtFotosAlbum.PerformCallback();
        }
        
        function SetarNomeDescricaoImagem(){
            hdnTituloImagem.Set("titImagem", txtTituloImagem.GetText());
            hdnDescricaoImagem.Set("descImagem", txtDescricaoImagem.GetText());
        }
    // ]]> 
    </script>

</asp:Content>
