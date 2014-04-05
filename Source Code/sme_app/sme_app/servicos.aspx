<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="servicos.aspx.cs" Inherits="sme_app.servicos" Title="Oficina SME | Nossos Serviços" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <!-- Coluna da Esquerda -->
    <div id="lContent">
        <label class="titulo_bloco">
            Entre em Contato</label>
        <div style="margin-top: 15px;">
            <a href="contato.aspx" style="margin-top: 12px; display: block;">
                <img alt="E-mail Oficina SME" title="E-mail Oficina SME" src="UIImages/bloco_contato_servicos_1.jpg" />
            </a><a href="javascript:void(0);" style="margin-top: 12px; display: block;">
                <img alt="Entre em contato!" title="Entre em contato!" src="UIImages/bloco_contato_servicos_2.jpg" />
            </a><a href="javascript:void(0);" style="margin-top: 12px; display: block;">
                <img alt="Nossa Localização" title="Nossa Localização" src="UIImages/bloco_contato_servicos_3.jpg" />
            </a><a href="javascript:void(0);" style="margin-top: 12px; display: block;">
                <img alt="Mídias Sociais" title="Mídias Sociais" src="UIImages/bloco_contato_servicos_4.jpg" />
            </a>
        </div>
        <div class="clear">&nbsp;</div>
    </div>
    <!-- Coluna da Direita -->
    <div id="rContent">
        <label class="titulo_bloco">
            Nossos Serviços</label>
            
            <div id="contentLoader" runat="server">
        
        </div>
            <!--
        <div id="contentServicos">
            <p>
                A SME preocupada em proporcionar comodidade, segurança e praticidade vem aprimorando
                ainda mais os serviços oferecidos aos seus clientes.
            </p>
            <br />
            <p>
                Você não precisa mais ir a várias oficinas para ter todos os serviços que seu carro
                necessita. Agora a SME oferece para você e seu veículo:
            </p>
            <ul id="lstEsq">
                <li>» Venda e troca de óleo e filtro de motor</li>
                <li>» Fluido de freio</li>
                <li>» Filtros de ar, combustível, óleo e ar condicionado</li>
                <li>» Bateria Bosch</li>
                <li>» Troca de escapamento</li>
                <li>» Alinhamento e balanceamento</li>
                <li>» Lubrificantes em geral (aditivo para radiadores, anti-ferrugem, graxa, silicone
                    spray, querosene, thinner e outros)</li>
            </ul>
            <ul id="lstDir">
                <li>» Palhetas dianteiras e traseiras</li>
                <li>» Lâmpadas e extintores</li>
                <li>» Revisão e manutenção preventiva4</li>
                <li>» Suspensão e freios</li>
                <li>» Elétrica, regulagem de motor e injeção eletrônica</li>
            </ul>
            <div class="clear">&nbsp;</div>
            <br />
            <p>
                Realizamos as manutenções em veículos nacionais e importados.
            </p>
            <img alt="Oficina SME" src="UIImages/sme_logo_bg_servicos.png" id="imgLogoSme" />               
        </div>
        -->
    </div>
    <div class="clear">&nbsp;</div>
    <br />
</asp:Content>
