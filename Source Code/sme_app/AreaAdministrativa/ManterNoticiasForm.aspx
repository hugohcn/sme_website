<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ManterNoticiasForm.aspx.cs" Inherits="AreaAdministrativa.ManterNoticiasForm" Title="Oficina SME | Área Administrativa - Cadastro de Notícias" %>
<%@ Register Assembly="DevExpress.Web.ASPxHtmlEditor.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxHtmlEditor" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxTabControl" TagPrefix="dx" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxGridView" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxPopupControl" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.ASPxSpellChecker.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxSpellChecker" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxCallback" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxLoadingPanel" tagprefix="dx" %>
<%@ Register assembly="DevExpress.Web.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab" namespace="DevExpress.Web.ASPxHiddenField" tagprefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

    <script type="text/javascript">
        function LimpaCampos(){
         txtTituloDica.SetText("");  
         txtFonte.SetText("");       
         txtDescricaoDica.SetText("");
         txtConteudo.SetHtml("");
         txtDataCriacao.SetText("");
        }
        
        function CallBackGetRowValues(values){
            btnEnviar.SetText("Atualizar");
            //Começa a popular os itens do POPUP.
            hdnIdAtualizacao.Set("id_noticia", values[0]);  
            hdnTipoOperacao.Set("tpOperacao", "A");  
            
            txtTituloDica.SetText(values[1]);  
            txtDescricaoDica.SetText(values[2]);    
            txtFonte.SetText(values[4]);
            txtConteudo.SetHtml(values[3]);
            txtDataCriacao.SetDate(values[5]);
        }
    </script>
    <div style="width: 100%; margin: 15px 0 0 0;">
        <dx:ASPxButton ID="btnCriarNovaNoticia" runat="server" AutoPostBack="False" 
            Text="Nova Notícia" Width="130px" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
            <ClientSideEvents Click="function(s, e) {
	//Indica que o tipo de operação será uma inserção.
	hdnTipoOperacao.Set(&quot;tpOperacao&quot;, &quot;I&quot;); 
	popAddEditDica.Show();
}" />
        </dx:ASPxButton>      
    </div>
    <br />
    <div style="width: 100%;">
        <dx:ASPxGridView ID="gdvNoticias" runat="server" AutoGenerateColumns="False" 
            ClientInstanceName="gdvNoticias" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
            CssPostfix="Aqua" DataSourceID="odsNoticias" Width="100%" 
            oncustomcallback="gdvNoticias_CustomCallback" KeyFieldName="id_noticia">
            <SettingsBehavior AllowFocusedRow="True" ConfirmDelete="True" 
                EnableRowHotTrack="True" />
            <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
            </Styles>
            <SettingsLoadingPanel Text="" />
            <SettingsPager>
                <Summary AllPagesText="Páginas: {0} - {1} ({2} itens)" 
                    Text="Página {0} de {1} ({2} itens)" />
            </SettingsPager>
            <ImagesFilterControl>
                <LoadingPanel Url="~/App_Themes/Aqua/Editors/Loading.gif">
                </LoadingPanel>
            </ImagesFilterControl>
            <Images SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                <LoadingPanelOnStatusBar Url="~/App_Themes/Aqua/GridView/gvLoadingOnStatusBar.gif">
                </LoadingPanelOnStatusBar>
                <LoadingPanel Url="~/App_Themes/Aqua/GridView/Loading.gif">
                </LoadingPanel>
            </Images>
            <SettingsText EmptyDataRow="Não existem notícias registradas até o momento. Clique no botão &quot;Nova Notícia&quot; para efetuar uma inserção." />
            <ClientSideEvents CustomButtonClick="function(s, e) {

	e.processOnServer = false; 

	if(e.buttonID == &quot;btnEditarNoticia&quot;)
	{
		s.GetRowValues(gdvNoticias.GetFocusedRowIndex(), 'id_noticia;titulo;descricao;conteudo;fonte;dt_criacao', CallBackGetRowValues)
		popAddEditDica.Show();
	}
}" />
            <Columns>
                <dx:GridViewDataTextColumn Caption="ID" FieldName="id_noticia" VisibleIndex="0" 
                    Width="50px">
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Título" FieldName="titulo" VisibleIndex="1">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Descrição" FieldName="descricao" 
                    VisibleIndex="2">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn FieldName="conteudo" 
                    VisibleIndex="3" Visible="False">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataTextColumn Caption="Fonte" FieldName="fonte" VisibleIndex="3">
                </dx:GridViewDataTextColumn>
                <dx:GridViewDataDateColumn Caption="Data Criação" FieldName="dt_criacao" 
                    VisibleIndex="4" Width="100px">
                    <PropertiesDateEdit EditFormat="Custom" EditFormatString="dd/MM/yyyy hh:mm:ss">
                    </PropertiesDateEdit>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewDataDateColumn>
                <dx:GridViewCommandColumn VisibleIndex="5" Caption=" " Width="70px">
                    <DeleteButton Visible="True" Text="Excluir">
                    </DeleteButton>
                    <EditButton Text="Editar">
                    </EditButton>
                    <CancelButton Text="Cancelar">
                    </CancelButton>
                    <UpdateButton Text="Atualizar">
                    </UpdateButton>
                    <CustomButtons>
                        <dx:GridViewCommandColumnCustomButton ID="btnEditarNoticia" Text="Editar">
                        </dx:GridViewCommandColumnCustomButton>
                    </CustomButtons>
                    <CellStyle HorizontalAlign="Center">
                    </CellStyle>
                </dx:GridViewCommandColumn>
            </Columns>
            <StylesEditors>
                <CalendarHeader Spacing="1px">
                </CalendarHeader>
                <ProgressBar Height="25px">
                </ProgressBar>
            </StylesEditors>
            <ImagesEditors>
                <DropDownEditDropDown>
                    <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                        PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
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
        </dx:ASPxGridView>
        <asp:ObjectDataSource ID="odsNoticias" runat="server" 
            DataObjectTypeName="Sme.Data.tblnoticia" DeleteMethod="RemoveNoticia" 
            SelectMethod="RetornaTodasNoticias" TypeName="Business.NoticiasBU">
        </asp:ObjectDataSource>
                
        <dx:ASPxPopupControl ID="popAddEditDica" runat="server" AllowDragging="True" 
            AppearAfter="200" ClientInstanceName="popAddEditDica" CloseAction="None" 
            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
            DisappearAfter="300" FooterText="" HeaderText="Adicionar/Editar Notícia" 
            Modal="True" PopupHorizontalAlign="WindowCenter" PopupVerticalAlign="WindowCenter" 
            SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css" Width="650px" 
            ShowCloseButton="False">
            <ContentStyle VerticalAlign="Top">
            </ContentStyle>
            <ClientSideEvents PopUp="function(s, e) {
	txtTituloDica.Focus();
}" Closing="function(s, e) {
	btnEnviar.SetText(&quot;Salvar&quot;);
}" />
            <ContentCollection>
                <dx:PopupControlContentControl ID="PopupControlContentControl1" runat="server">
                    <table width="100%" cellpadding="0" cellspacing="0">
                        <tr>
                            <td colspan="2">
                                 Título:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxTextBox ID="txtTituloDica" ClientInstanceName="txtTituloDica" 
                                    runat="server" Width="100%" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                                    CssPostfix="Aqua">
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td>
                                Fonte:</td>
                                
                            <td style="padding-left: 20px;">
                                Data de Criação:
                            </td>
                        </tr>
                        <tr>
                            <td>
                                <dx:ASPxTextBox ID="txtFonte" runat="server" ClientInstanceName="txtFonte" 
                                    CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" Width="100%">
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxTextBox>
                            </td>
                            <td style="padding-left: 20px;">
                                <dx:ASPxDateEdit ID="txtDataCriacao" ClientInstanceName="txtDataCriacao" 
                                    runat="server" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
                                    ShowShadow="False" SpriteCssFilePath="~/App_Themes/Aqua/{0}/sprite.css">
                                    <CalendarProperties>
                                        <HeaderStyle Spacing="1px" />
                                        <FooterStyle Spacing="17px" />
                                    </CalendarProperties>
                                    <DropDownButton>
                                        <Image>
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                                                PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
                                        </Image>
                                    </DropDownButton>
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxDateEdit>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Descrição:

                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxMemo ID="txtDescricaoDica" ClientInstanceName="txtDescricaoDica" 
                                    runat="server" Height="71px" Width="100%" 
                                    CssFilePath="~/App_Themes/Glass/{0}/styles.css" CssPostfix="Glass">
                                    <ValidationSettings>
                                        <ErrorFrameStyle ImageSpacing="4px">
                                            <ErrorTextPaddings PaddingLeft="4px" />
                                        </ErrorFrameStyle>
                                    </ValidationSettings>
                                </dx:ASPxMemo>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                 &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                Conteúdo:
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxHtmlEditor ID="txtConteudo" ClientInstanceName="txtConteudo" 
                                    Width="100%" runat="server" CssFilePath="~/App_Themes/Aqua/{0}/styles.css" 
                                    CssPostfix="Aqua" Height="240px">
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
                                            <SpriteProperties HottrackedCssClass="dxEditors_edtDropDownHover_Aqua" 
                                                PressedCssClass="dxEditors_edtDropDownPressed_Aqua" />
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
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                &nbsp;</td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <dx:ASPxCallback ID="cbDica" runat="server" ClientInstanceName="cbDica" 
                                    OnCallback="cbDica_Callback">
                                    <ClientSideEvents BeginCallback="function(s, e) {
	lpCarregando.Show();
}" CallbackComplete="function(s, e) {
	if(e.result == &quot;sucesso&quot;){

		if(hdnTipoOperacao.Get(&quot;tpOperacao&quot;) == &quot;A&quot;){
			alert(&quot;Notícia atualizada com sucesso!&quot;);
		}
		else
		{
			alert(&quot;Notícia inserida com sucesso!&quot;);
		}

		lpCarregando.Hide();	
		LimpaCampos();
		popAddEditDica.Hide();
		gdvNoticias.PerformCallback();
	}
}" CallbackError="function(s, e) {
	e.handled = true;
	alert(e.message);
	lpCarregando.Hide();
	LimpaCampos();
	popAddEditDica.Hide();
}" />
                                </dx:ASPxCallback>
                                <dx:ASPxLoadingPanel ID="lpCarregando" runat="server" 
                                    ClientInstanceName="lpCarregando" HorizontalAlign="Center" Modal="True" 
                                    Text="Carregando..." VerticalAlign="Middle">
                                </dx:ASPxLoadingPanel>
                                <dx:ASPxHiddenField ID="hdnIdAtualizacao" runat="server" 
                                    ClientInstanceName="hdnIdAtualizacao">
                                </dx:ASPxHiddenField>
                                <dx:ASPxHiddenField ID="hdnTipoOperacao" runat="server" 
                                    ClientInstanceName="hdnTipoOperacao">
                                </dx:ASPxHiddenField>
                            </td>
                        </tr>
                        <tr>
                            <td colspan="2">
                                <div style="width: 260px; margin: 0 auto;">
                                    <div style="float: left; margin-right: 10px;">
                                        <dx:ASPxButton ID="btnEnviar" ClientInstanceName="btnEnviar" runat="server" 
                                            Text="Enviar" Width="120px" AutoPostBack="False" 
                                            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                            <ClientSideEvents Click="function(s, e) {
	cbDica.PerformCallback(hdnTipoOperacao.Get(&quot;tpOperacao&quot;));
}" />
                                        </dx:ASPxButton>
                                    </div>   
                                    <div style="float: left;">
                                        <dx:ASPxButton ID="btnCancelar" ClientInstanceName="btnCancelar" runat="server" 
                                            Text="Cancelar" Width="120px" AutoPostBack="False" 
                                            CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
                                            <ClientSideEvents Click="function(s, e) {
	popAddEditDica.Hide();
	LimpaCampos();
}" />
                                        </dx:ASPxButton>                                                                
                                    </div>                                    
                                </div>
                            </td>
                        </tr>
                    </table>
                </dx:PopupControlContentControl>
            </ContentCollection>
        </dx:ASPxPopupControl>
    </div>
</asp:Content>