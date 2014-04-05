<%@ Page Language="C#" MasterPageFile="~/Principal.Master" AutoEventWireup="true" CodeBehind="dicas.aspx.cs" Inherits="sme_app.dicas" Title="Oficina SME | Dicas" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div style="margin: 10px;">
        <label class="titulo_bloco">
            Dicas</label>
        <br />
        <asp:Repeater ID="rptNoticias" runat="server" DataSourceID="odsDicas">
            <ItemTemplate>
                <div style="margin-top: 10px;">
                    <a href='<%# "dica.aspx?idDica=" + Eval("id_dica").ToString() %>' target="_self">
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
      
        <asp:ObjectDataSource ID="odsDicas" runat="server" 
            SelectMethod="RetornaTodasDicas" TypeName="Business.DicasBU">
        </asp:ObjectDataSource>
      
    </div>
</asp:Content>
