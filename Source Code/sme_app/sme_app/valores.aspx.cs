using System;
using System.Collections;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.UI.WebControls.WebParts;
using System.Web.UI.HtmlControls;
using System.Xml.Linq;
using Business;
using Sme.Data;
using System.Collections.Generic;

namespace sme_app
{
    public partial class valores : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                //Recupera conteudo da página
                object obj = new PaginaConteudoBU().RetornaConteudoPagina("valores");

                if (obj != null)
                    contentLoader.InnerHtml = ((tblvalore)obj).conteudo;
                else
                    throw new Exception("Falha ao carregar dados da página.");

                //Recupera o album de fotos da pagina
                IList<tblalbumfoto> lstAlbuns = new AlbumFotosBU().RecuperarFotosPagina("pag_valores");

                if (lstAlbuns != null)
                {
                    //rptAlbumFotos.DataSource = lstAlbuns;
                    //rptAlbumFotos.DataBind();
                }
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        protected void rptAlbumFotos_ItemDataBound(object sender, RepeaterItemEventArgs e)
        {
            if (!IsPostBack)
            {
                try
                {
                    RepeaterItem item = e.Item;

                    if (item.ItemType.Equals(ListItemType.Item) || item.ItemType.Equals(ListItemType.AlternatingItem))
                    {
                        Repeater child = (Repeater)item.FindControl("rptFotos");

                        if (child != null)
                        {
                            HiddenField hdnIdAlbum = (HiddenField)item.FindControl("hdnIdAlbum");

                            int idAlbum = Convert.ToInt32(hdnIdAlbum.Value);
                            child.DataSource = new AlbumFotosBU().RecuperarFotosPagina(idAlbum);
                            child.DataBind();
                        }
                    }
                }
                catch (Exception eX)
                {
                    throw eX;
                }
            }
        }
    }
}
