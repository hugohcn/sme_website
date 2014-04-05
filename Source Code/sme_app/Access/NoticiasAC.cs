using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using SubSonic.Schema;
using SubSonic.Query;
using System.Diagnostics;

namespace Access
{
    public class NoticiasAC
    {
        public IList<tblnoticia> RetornaTodasNoticias()
        {
            try
            {
                return tblnoticia.Find(x => x.id_noticia > -1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IOrderedEnumerable<tblnoticia> Retorna4UltimasNoticiasAposUltima()
        {
            try
            {
                IOrderedEnumerable<tblnoticia> lstNoticias;
                tblnoticia ultNot = tblnoticia.Find(x => x.id_noticia > -1).OrderByDescending(z => z.dt_criacao).Take(1).ToList()[0];

                lstNoticias = tblnoticia.Find(x => x.id_noticia < ultNot.id_noticia).Take(4).ToList().OrderByDescending(y => y.dt_criacao);
                return lstNoticias;
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AtualizarNoticia(string idNoticia, string titulo, string descricao, string conteudo, string fonte, DateTime dtCriacao)
        {
            try
            {
                tblnoticia noticia = new tblnoticia();
                noticia.SetIsNew(false);
                noticia.SetIsLoaded(true); 
                noticia.SetKeyValue(idNoticia);
                
                noticia.conteudo = conteudo;
                noticia.descricao = descricao;
                noticia.dt_criacao = dtCriacao;
                noticia.fonte = fonte;
                noticia.titulo = titulo;
                
                noticia.Update();
                
                Debug.WriteLine("Notícia '" + idNoticia + "' foi atualizada com sucesso.");                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erro ao atualizar notícia '" + idNoticia + "': " + e.Message);
                throw e;
            }
        }

        public void InserirNoticia(string titulo, string descricao, string conteudo, string fonte, DateTime dtCriacao)
        {
            tblnoticia noticia = new tblnoticia();
            
            try
            {
                noticia.SetIsNew(true);
                noticia.SetIsLoaded(false);

                noticia.SetKeyValue(0);
                noticia.titulo = titulo;
                noticia.descricao = descricao;
                noticia.conteudo = conteudo;
                noticia.dt_criacao = dtCriacao;
                noticia.fonte = fonte;

                noticia.Save();

                Debug.WriteLine("Notícia '" + noticia.titulo + "' foi atualizada com sucesso.");                
            }
            catch (Exception e)
            {
                Debug.WriteLine("Erro ao inserir notícia '" + noticia.titulo+ "': " + e.Message);
                throw e;
            }
        }

        public void RemoveNoticia(tblnoticia noticia)
        {
            try
            {
                noticia.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<tblnoticia> RetornaUltimaNoticiaAtiva()
        {
            try
            {
                return tblnoticia.Find(x => x.id_noticia > -1).OrderByDescending(z => z.dt_criacao).Take(1).ToList();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        public tblnoticia RetornaNoticiaById(int idNoticia)
        {
            try
            {
                return tblnoticia.SingleOrDefault(x => x.id_noticia.Equals(idNoticia));
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
