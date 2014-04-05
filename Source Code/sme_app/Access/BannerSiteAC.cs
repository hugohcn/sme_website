using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;

namespace Access
{
    public class BannerSiteAC
    {
        public IList<tblBanner> RetornaTodosBanners()
        {
            try
            {
                return tblBanner.Find(x => x.id_banner > -1);
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
                tblBanner banner = new tblBanner();
                banner.SetIsNew(true);
                banner.nome = nome;
                banner.dt_cadastro = dtCriacao;
                banner.is_ativo = true;
                banner.path = path;
                banner.nome_arquivo = nome_arquivo;
                banner.path_thumb = path_thumb;
                banner.nome_arquivo_thumb = nome_arquivo_thumb;
                banner.descricao = descricao;

                banner.Save();
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
                tblBanner bNew = new tblBanner();
                bNew.SetIsLoaded(true);
                bNew.SetIsNew(false);
                bNew.SetKeyValue(banner.id_banner);

                bNew.dt_cadastro = banner.dt_cadastro;
                bNew.is_ativo = banner.is_ativo;
                bNew.nome = banner.nome;
                bNew.nome_arquivo = banner.nome_arquivo;
                bNew.path = banner.path;
                bNew.path_thumb = banner.path_thumb;
                bNew.nome_arquivo_thumb = banner.nome_arquivo_thumb;
                bNew.descricao = banner.descricao;

                bNew.Update();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void DeletaBannerSite(tblBanner banner)
        {
            try
            {
                banner.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
