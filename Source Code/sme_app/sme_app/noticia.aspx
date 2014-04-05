<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="noticia.aspx.cs" Inherits="sme_app.noticia" Title="Untitled Page" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Coluna da Esquerda -->
    <div id="lContent">
        <label class="titulo_bloco">
            Outros Tópicos</label>
        <ul id="lstOutrosTopicos">
            <li><a href="empresa.aspx">A Empresa</a></li>
            <li><a href="missao.aspx">Nossa Missão</a></li>
            <li><a href="visao.aspx">Visão</a></li>
            <li><a href="valores.aspx">Valores</a></li>
        </ul>
        <br />
        <label class="titulo_bloco">
            Qualidade e Tecnologia</label>
        <img alt="" id="imgBannerInovacao" src="UIImages/banner_bosch_inovacao.png" />
    </div>
    <div id="rContent">
        <label class="titulo_bloco" runat="server">Notícias</label>
        <br />
        <h4 runat="server" style="font-family: Verdana; color: #FF8C00; font-weight: normal;" id="tituloNoticia"></h4>
        <label style="display: block; margin: 3px 0 0 0; font-size: 11px; font-family: Verdana; color: #31547A;" runat="server" id="dtHoraNoticia"></label>
        <br />
        <div id="contentLoader" runat="server">
            <!-- conteudo da noticia -->
            
        </div>
        <br />
        <label runat="server" id="fonteNoticia" style="font-family: Verdana; font-size: 11px; color: #31547A;"></label>
    </div>
    <div class="clear" style="height: 20px;">
        &nbsp;</div>
</asp:Content>
