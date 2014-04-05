using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using Access;

namespace Business
{
    public class BannerSiteBU
    {
        public IList<tblBanner> RetornaTodosBanners()
        {
            try
            {
                return new BannerSiteAC().RetornaTodosBanners();
            }
            catch (Exception e)
            {
               throw e;
            }
        }

        public void InserirBanner(string nome, string path, string nome_arquivo, DateTime dtCriacao, string path_thumb, string nome_arquivo_thumb, string descricao)
        {
            try
            {
                new BannerSiteAC().InserirBanner(nome, path, nome_arquivo, dtCriacao, path_thumb, nome_arquivo_thumb, descricao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void AtualizarBanner(tblBanner banner)
        {
            try
            {
                new BannerSiteAC().AtualizarBanner(banner);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void DeletaBannerSite(string idBanner)
        {
            try
            {
                tblBanner banner = new tblBanner();
                banner.id_banner = Convert.ToInt32(idBanner);
                banner.SetKeyValue(idBanner);
                
                new BannerSiteAC().DeletaBannerSite(banner);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
