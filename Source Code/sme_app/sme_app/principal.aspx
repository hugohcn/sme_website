<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="principal.aspx.cs" Inherits="sme_app.principal" Title="Oficina SME | Página Principal" %>

<%@ Register Assembly="DevExpress.Web.ASPxEditors.v9.3, Version=9.3.2.0, Culture=neutral, PublicKeyToken=8d332da86fe888ab"
    Namespace="DevExpress.Web.ASPxEditors" TagPrefix="dx" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
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
        <a href="contato.aspx" target="_self">
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
        <div id="leftContentRContent">
            <label class="titulo_bloco">
                Notícias</label>
            <asp:Repeater ID="cc" runat="server" DataSourceID="odsUltimaNoticia">
                <ItemTemplate>
                    <a href='<%# "noticia.aspx?idNoticia=" + Eval("id_noticia").ToString() %>' target="_self">
                        <h6 style="display: block; height: 38px;">
                            <%# Eval("titulo") %>
                        </h6>
                    </a>
                    <div class="descNoticias">
                        <%# DataBinder.Eval(Container.DataItem, "descricao").ToString().Length < 140 ? DataBinder.Eval(Container.DataItem, "descricao").ToString() + " ... " : DataBinder.Eval(Container.DataItem, "descricao").ToString().Substring(0, 140) + " ... " %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsUltimaNoticia" runat="server" SelectMethod="RetornaUltimaNoticiaAtiva"
                TypeName="Business.NoticiasBU"></asp:ObjectDataSource>
            <ul id="lstOutrasNoticias">
                <!-- repeater -->
                <asp:Repeater ID="rptUltimasNoticias" runat="server">
                    <ItemTemplate>
                        <li><a href='<%# "noticia.aspx?idNoticia=" + Eval("id_noticia").ToString() %>'><%# Eval("titulo") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
           <a class="lnkLeiaMais" id="lnkLeiaMais" href="noticias.aspx">[+] Ver Todos</a>
        </div>
        <div id="rightContentRContent">
            <label class="titulo_bloco">
                Dicas para o seu carro</label>
            <asp:Repeater ID="rptUltimaDica" runat="server" DataSourceID="odsUltimaDica">
                <ItemTemplate>
                    <a href='<%# "dica.aspx?idDica=" + Eval("id_dica").ToString() %>' target="_self">
                        <h6 style="display: block; height: 38px;">
                            <%# Eval("titulo") %>
                        </h6>
                    </a>
                    <div class="descNoticias">
                        <%# DataBinder.Eval(Container.DataItem, "descricao").ToString().Length < 140 ? DataBinder.Eval(Container.DataItem, "descricao").ToString() + " ... " : DataBinder.Eval(Container.DataItem, "descricao").ToString().Substring(0, 140) + " ... " %>
                    </div>
                </ItemTemplate>
            </asp:Repeater>
            <asp:ObjectDataSource ID="odsUltimaDica" runat="server" 
                SelectMethod="RetornaUltimaDicaAtiva" TypeName="Business.DicasBU">
            </asp:ObjectDataSource>
            <ul id="lstDicas">
                <asp:Repeater ID="rptUltimasDicas" runat="server">
                    <ItemTemplate>
                        <li><a href='<%# "dica.aspx?idDica=" + Eval("id_dica").ToString() %>''><%# Eval("titulo") %></a></li>
                    </ItemTemplate>
                </asp:Repeater>
            </ul>
            <a class="lnkLeiaMais" id="A1" href="dicas.aspx">[+] Ver Todos</a> 
        </div>
        <div id="blocoMidiasSociais">
            <label class="titulo_bloco">
                Mídias Sociais // SME</label>
            <div id="containerMidiasSociais" class="containerBottomBlocks">
                <div style="margin: 0 0 0 6px;" class="divLinksContentBottomBlocks">
                    <!-- Repeater de midias sociais -->
                    <asp:Repeater ID="rptMidiasSociais" runat="server" DataSourceID="odsParametros">
                        <ItemTemplate>
                            <a href='<%# DataBinder.Eval(Container.DataItem, "valor") %>' target="_blank">
                                <img alt='<%# DataBinder.Eval(Container.DataItem, "title") %>' title='<%# DataBinder.Eval(Container.DataItem, "title") %>'
                                    src='<%# DataBinder.Eval(Container.DataItem, "src") %>' /></a>
                        </ItemTemplate>
                    </asp:Repeater>
                    <asp:ObjectDataSource ID="odsParametros" runat="server" SelectMethod="RetornaTodosParametrosAtivos"
                        TypeName="Business.ParametrosBU"></asp:ObjectDataSource>
                </div>
            </div>
        </div>
        <div id="blocoFormasPagamento">
            <label class="titulo_bloco">
                Formas de Pagamento</label>
            <div id="containerFormasPagamentos" class="containerBottomBlocks">
                <div style="margin: 0 0 0 6px;" class="divLinksContentBottomBlocks">
                    <a href="javascript:void(0);" target="_blank">
                        <img alt="Cartão de Crédito/Débito Mastercard." title="Cartão de Crédito/Débito Mastercard."
                            src="UIImages/button_mastercard.jpg" /></a> <a href="javascript:void(0);" target="_blank">
                                <img alt="Cartão de Crédito/Débito Banescard." title="Cartão de Crédito/Débito Banescard."
                                    src="UIImages/button_banescard.jpg" /></a> <a href="javascript:void(0);" target="_blank">
                                        <img alt="Cartão de Crédito/Débito Visa." title="Cartão de Crédito/Débito Visa."
                                            src="UIImages/button_visa.jpg" /></a>
                </div>
            </div>
        </div>
        <div id="blocoInovacaoQualidade">
            <label class="titulo_bloco">
                Inovação e Qualidade</label>
            <a style="margin-top: 1px; display: block;">
                <img alt="Inovação e Qualidade" title="Inovação e Qualidade" src="UIImages/banner_bosch_inovacao.jpg" />
            </a>
        </div>
    </div>
    <div class="clear">
        &nbsp;</div>
</asp:Content>
