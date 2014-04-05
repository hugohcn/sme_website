<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="visao.aspx.cs" Inherits="sme_app.visao" Title="Oficina SME | Visão" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
  <link href="UIStyles/lightbox.css" rel="stylesheet" type="text/css" />

    <script src="UIScripts/prototype.js" type="text/javascript"></script>
    <script src="UIScripts/lightbox.js" type="text/javascript"></script>
    <script src="UIScripts/scriptaculous.js?load=effects,builder" type="text/javascript"></script>
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
        <label class="titulo_bloco">
            Visão</label>
            <div id="contentLoader" runat="server">
        
        </div>
            <!--
        <div id="contentEmpresa">
            <img id="imgEmpresa1" alt="" src="UIImages/img_empresa_1.jpg" />
            <p>
                A empresa SME – Serviços Mecânicos Especiais foi fundada em março de 1983 com três
                sócios igualitários. A idéia de montar uma oficina mecânica surgiu do conhecimento
                adquirido no mercado de trabalho por ambos os sócios que atuavam em áreas como compra
                e venda de veículos, jurídica, contábil, além da vasta experiência de um dos sócios
                em mecânica automotiva.
            </p>
            <br />
            <p>
                A empresa teve suas portas abertas em um galpão alugado na Avenida Vitória, onde
                permaneceu por quatro anos. Após dois anos de fundação, dois sócios decidiram por
                vender as partes, ficando assim, um único proprietário, João Carlos Freitas.
            </p>
            <img id="imgEmpresa2" alt="" src="UIImages/img_empresa_2.jpg" />
            <br />
            <p>
                Para atender a necessidade de mercado e o grande crescimento que a SME obteve em
                pouco tempo, a empresa se mudou para o Bairro Consolação, onde permanece até os
                dias atuais.
            </p>
            <br />
            <p>
                A oficina também conta com a parceria da Bosch Car Service que exige um padrão mundial
                de logomarca, padronização de uniformes, ferramentas especializadas (eletro/eletrônica)
                oferecendo apoio técnico e treinamentos no ramo de atuação.
            </p>
        </div>
        -->
        <div class="clear">
        &nbsp;</div>
        
    </div>
    <div class="clear" style="height: 20px;">
        &nbsp;</div>
</asp:Content>
