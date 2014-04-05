using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using Access;
using SubSonic.Schema;

namespace Business
{
    public class NoticiasBU
    {
        public IList<tblnoticia> RetornaTodasNoticias()
        {
            try
            {
                return new NoticiasAC().RetornaTodasNoticias();
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
                return new NoticiasAC().Retorna4UltimasNoticiasAposUltima();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InserirNoticia(string titulo, string descricao, string conteudo, string fonte, DateTime dtCriacao)
        {
            try
            {
                new NoticiasAC().InserirNoticia(titulo, descricao, conteudo, fonte, dtCriacao);
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
                new NoticiasAC().AtualizarNoticia(idNoticia, titulo, descricao, conteudo, fonte, dtCriacao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveNoticia(tblnoticia noticia)
        {
            try
            {
                new NoticiasAC().RemoveNoticia(noticia);
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
                return new NoticiasAC().RetornaUltimaNoticiaAtiva();
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
                return new NoticiasAC().RetornaNoticiaById(idNoticia);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
