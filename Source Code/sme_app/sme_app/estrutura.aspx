<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="estrutura.aspx.cs" Inherits="sme_app.estrutura" Title="Oficina SME | Estrutura Organizacional" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="UIStyles/lightbox.css" rel="stylesheet" type="text/css" />

    <script src="UIScripts/prototype.js" type="text/javascript"></script>

    <script src="UIScripts/lightbox.js" type="text/javascript"></script>

    <script src="UIScripts/scriptaculous.js?load=effects,builder" type="text/javascript"></script>

    <!-- Coluna da Esquerda -->
    <div id="lContent">
        <label class="titulo_bloco">
            Área do Cliente</label>
        <label class="subTitulo_bloco">
            Placa do Veículo</label>
        <dx:ASPxTextBox ID="txtPlacaVeiculo" CssClass="txtBoxPadrao" EnableDefaultAppearance="false"
            runat="server" Width="183px">
        </dx:ASPxTextBox>
        <label class="subTitulo_bloco">
            Senha</label>
        <dx:ASPxTextBox ID="txtSenha" Password="true" CssClass="txtBoxPadrao" EnableDefaultAppearance="false"
            runat="server" Width="183px">
        </dx:ASPxTextBox>
        <div id="blocoLoginExec">
            <div style="float: left; width: 95px; position: relative; top: 7px;">
                <dx:ASPxHyperLink ID="lnkRecuperarSenha" runat="server" Text="Recuperar Senha" CssFilePath="~/App_Themes/Glass/{0}/styles.css"
                    CssPostfix="Glass" NavigateUrl="javascript:void(0);">
                </dx:ASPxHyperLink>
            </div>
            <div style="float: right;">
                <dx:ASPxButton ID="btnLogar" runat="server" Text="" BackgroundImage-ImageUrl="~/UIImages/btnLogar.jpg"
                    Cursor="pointer" EnableDefaultAppearance="false" Width="76px" Height="23px" Border-BorderStyle="None">
                </dx:ASPxButton>
            </div>
        </div>
        <div class="clear" style="height: 20px;">
            &nbsp;</div>
        <a href="javascript:void(0);" target="_self">
            <img alt="Nossa Localização" title="Nossa Localização" src="UIImages/banner_nossa_localizacao.jpg" />
        </a>
        <div class="clear" style="height: 12px;">
            &nbsp;</div>
        <a href="javascript:void(0);" target="_self">
            <img alt="Responsabilidade Social" title="Responsabilidade Social" src="UIImages/banner_responsabilidade_social.jpg" />
        </a>
    </div>
    <!-- Coluna da Direita -->
    <div id="rContent">
        <label class="titulo_bloco">
            Estrutura Organizacional</label>
        <div id="contentLoader" runat="server">
        </div>
        <!--
        <div id="contentEmpresa">
            <img id="imgEmpresa1" alt="" src="UIImages/img_estrutura_organizacional_1.jpg" />
            <p>
                A SME vem a cada dia investindo em equipamentos de alto custo com o objetivo de
                oferecer aos clientes maior qualidade e agilidade no serviço oferecido.
            </p>
            <br />
            <p>
                Contamos com uma oficina preparada para atender diversos tipos de reparos em automóveis,
                dispondo de excelentes instalações, infra-estrutura moderna e equipamentos de última
                geração.
            </p>
            <br />
            <p>
                Nossa oficina possui um rigoroso controle de qualidade para proporcionar o melhor atendimento. 
            </p>
            <br />
        </div>
        -->
        <div class="clear">
            &nbsp;</div>
        <label class="titulo_bloco">
            Nossa Estrutura
            <label id="lblInformativo">
                (Clique na imagem para ampliar a foto)</label></label>
        <br />
        <div id="contentAlbumEstrutura">
            <ul id="lstFotos">
                <asp:Repeater ID="rptAlbumFotos" runat="server" OnItemDataBound="rptAlbumFotos_ItemDataBound">
                    <ItemTemplate>
                        <li>
                            <asp:HiddenField ID="hdnIdAlbum" EnableViewState="true" runat="server" Value='<%# Eval("id_album_foto") %>' />
                            <a href='<%# "http://administracao.oficinasme.com.br/" + Eval("foto_album_path").ToString() + Eval("foto_album_file").ToString() %>' title=<%# Eval("nome") %> rel="lightbox[roadtrip]">
                                <img alt="Clique a foto para ampliá-la." title='<%# Eval("nome") %>' src='<%# "http://administracao.oficinasme.com.br/" + Eval("capa_album_path").ToString() + Eval("capa_album_file").ToString() %>' />
                            </a>
                            <asp:Repeater ID="rptFotos" runat="server">
                                <ItemTemplate>
                                    <a href='<%# "http://administracao.oficinasme.com.br/" + Eval("path").ToString() + Eval("arquivo").ToString() %>' title='<%# Eval("nome") %>' rel="lightbox[roadtrip]"></a>
                                </ItemTemplate>
                            </asp:Repeater>
                        </li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
        </div>
    </div>
   <div class="clear" style="height: 20px;">
        &nbsp;</div>
</asp:Content>
