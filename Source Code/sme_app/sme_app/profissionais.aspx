<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="profissionais.aspx.cs" Inherits="sme_app.profissionais" Title="Oficina SME | Profissionais Modelos" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <link href="UIStyles/lightbox.css" rel="stylesheet" type="text/css" />
    <script src="UIScripts/prototype.js" type="text/javascript"></script>
    <script src="UIScripts/lightbox.js" type="text/javascript"></script>
    <script src="UIScripts/scriptaculous.js?load=effects,builder" type="text/javascript"></script>

    <!-- Coluna da Esquerda -->
    <div id="lContent">
        <label class="titulo_bloco">
            Outros Tópicos</label>
        <div style="margin-top: 15px;">
            <a href="contato.aspx" style="margin-top: 12px; display: block;">
                <img alt="Nossos Contatos" title="Nossos Contatos" src="UIImages/bloco_contato_servicos_1.jpg" />
            </a><a href="contato.aspx" style="margin-top: 12px; display: block;">
                <img alt="Nossos Contatos" title="Nossos Contatos" src="UIImages/bloco_contato_servicos_2.jpg" />
            </a><a href="contato.aspx" style="margin-top: 12px; display: block;">
                <img alt="Nossa Localização" title="Nossa Localização" src="UIImages/bloco_contato_servicos_3.jpg" />
            </a><a href="javascript:void(0);" style="margin-top: 12px; display: block;">
                <img alt="Mídias Sociais" title="Mídias Sociais" src="UIImages/bloco_contato_servicos_4.jpg" />
            </a>
        </div>
        <div class="clear">&nbsp;</div>
    </div>
    <div id="rContent">
        <label class="titulo_bloco">
            Profissionais Modelos</label>
        <div id="contentLoader" runat="server">
        
        </div>
        <!--
        <div id="contentProfissionaisModelos">
            <a href="UIImages/Fotos/Empresa/0003.jpg" title="Estrutura Organizacional" rel="lightbox[roadtrip]">
                <img alt="Profissionais Modelos - Clique aqui para conhecer mais sobre nós!" src="UIImages/img_prof_modelos_1.jpg"
                    style="float: right;" /></a>
            <p>
                A SME entende que a comunicação interna é fator estratégico da gestão empresarial.
                Os colaboradores da empresa desempenham um papel fundamental na formação e manutenção
                de uma imagem positiva da organização.
            </p>
            <br />
            <p>
                Contar com um bom mecânico e funcionários preparados para oferecer qualidade e rapidez
                são fundamentais, por isso, a SME vem aperfeiçoando seus serviços de reparação automotiva
                acompanhando a evolução tecnológica do mercado investindo em mão de obra qualificada
                e treinamentos constantes com sua equipe. Todos os nossos profissionais são atualizados
                com cursos de especialização, treinados e certificados.
            </p>
            <br />
            <p>
                A oficina conta com 15 colaboradores distribuídos da seguinte maneira: oito especializados
                em mecânica, um no atendimento ao cliente, um no estoque de peças, dois em serviços
                gerais e três pessoas no administrativo, financeiro e recursos humanos.
            </p>
        </div>   -->
    </div>
    <div class="clear" style="height: 20px;">
        &nbsp;</div>
</asp:Content>
