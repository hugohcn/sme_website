<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true"
    CodeBehind="noticias.aspx.cs" Inherits="sme_app.noticias" Title="Oficina SME | Notícias" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 10px;">
        <label class="titulo_bloco">
            Notícias</label>
        <br />
        <asp:Repeater ID="rptNoticias" runat="server" DataSourceID="odsNoticias">
            <ItemTemplate>
                <div style="margin-top: 10px;">
                    <a href='<%# "noticia.aspx?idNoticia=" + Eval("id_noticia").ToString() %>' target="_self">
                        <h6 style="display: block; height: 20px;">
                            <%# Eval("titulo") %>
                        </h6>
                    </a>
                    <div class="descNoticias" style="height: auto;">
                        <%# DataBinder.Eval(Container.DataItem, "descricao").ToString()%>
                    </div>
                    <hr style="border: 1px dotted #c3c3c3;" />
                </div>
            </ItemTemplate>
        </asp:Repeater>
        <asp:ObjectDataSource ID="odsNoticias" runat="server" SelectMethod="RetornaTodasNoticias"
            TypeName="Business.NoticiasBU"></asp:ObjectDataSource>
    </div>
</asp:Content>
