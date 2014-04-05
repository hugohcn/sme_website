<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="ManterConfiguracoesSiteForm.aspx.cs" Inherits="AreaAdministrativa.ManterConfiguracoesSiteForm" Title="Oficina SME | Área Administrativa - Manter Configurações do Site" %>

<%@ Register Assembly="DevExpress.Web.ASPxGridView.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxGridView" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <br />
    <dx:ASPxGridView ID="gdvParametros" runat="server" 
    ClientInstanceName="gdvParametros" DataSourceID="odsParametrosSite" 
        Width="100%" AutoGenerateColumns="False" 
        CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua" 
        KeyFieldName="id_parametro">
        <Styles CssFilePath="~/App_Themes/Aqua/{0}/styles.css" CssPostfix="Aqua">
        </Styles>
        <SettingsLoadingPanel Text="Carregando..." />
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
        <SettingsText EmptyDataRow="Não existem parâmetros registrados até o momento." />
        <Columns>
            <dx:GridViewDataTextColumn Caption="ID" FieldName="id_parametro" 
                ReadOnly="True" VisibleIndex="0" Width="50px">
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Chave de Configuração" FieldName="chave" 
                ReadOnly="True" VisibleIndex="1">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Valor" FieldName="valor" VisibleIndex="2">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Título do Objeto" FieldName="title" 
                VisibleIndex="3">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataTextColumn Caption="Path do Objeto" FieldName="src" 
                VisibleIndex="4">
            </dx:GridViewDataTextColumn>
            <dx:GridViewDataCheckColumn Caption="Habilitar?" FieldName="is_habilitado" 
                VisibleIndex="5" Width="50px">
                <CellStyle HorizontalAlign="Center">
                </CellStyle>
            </dx:GridViewDataCheckColumn>
            <dx:GridViewCommandColumn Caption=" " VisibleIndex="6">
                <EditButton Text="Editar" Visible="True">
                </EditButton>
                <CancelButton Text="Cancelar">
                </CancelButton>
                <UpdateButton Text="Atualizar">
                </UpdateButton>
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
    <asp:ObjectDataSource ID="odsParametrosSite" runat="server" 
        DataObjectTypeName="Sme.Data.tblparametro" 
        SelectMethod="RetornaTodosParametros" TypeName="Business.ParametrosBU" 
        UpdateMethod="AtualizarParametro"></asp:ObjectDataSource>
    &#39;
</asp:Content>
