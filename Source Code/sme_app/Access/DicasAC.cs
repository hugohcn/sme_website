using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;

namespace Access
{
    public class DicasAC
    {
        public IList<tbldica> RetornaTodasDicas()
        {
            try
            {
                 return tbldica.Find(x => x.id_dica > -1);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IOrderedEnumerable<tbldica> Retorna4UltimasDicasAposUltima()
        {
            try
            {
                tbldica ultDica = tbldica.Find(x => x.id_dica > -1).OrderByDescending(z => z.dt_criacao).Take(1).ToList()[0];

                return tbldica.Find(x => x.id_dica < ultDica.id_dica).Take(4).ToList().OrderByDescending(y => y.dt_criacao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public tbldica RetornaDicaById(int idDica)
        {
            try
            {
                return tbldica.SingleOrDefault(x => x.id_dica.Equals(idDica));
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void InserirDica(string titulo, string descricao, string conteudo, string fonte, DateTime dtCriacao)
        {
            try
            {
                tbldica dica = new tbldica();
                dica.SetIsNew(true);
                dica.SetIsLoaded(false);
                dica.SetKeyValue(0);                                
                dica.titulo = titulo;
                dica.descricao = descricao;
                dica.conteudo = conteudo;
                dica.dt_criacao = dtCriacao;
                dica.fonte = fonte;
                
                dica.Save();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AtualizarDica(string idDica, string titulo, string descricao, string conteudo, string fonte, DateTime dtCriacao)
        {
            try
            {
                tbldica dica = new tbldica();
                dica.SetIsNew(false);
                dica.SetIsLoaded(true);
                dica.SetKeyValue(idDica);
                
                dica.titulo = titulo;
                dica.descricao = descricao;
                dica.conteudo = conteudo;
                dica.dt_criacao = dtCriacao;
                dica.fonte = fonte;

                dica.Update();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void RemoveDica(tbldica dica)
        {
            try
            {
                dica.Delete();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public List<tbldica> RetornaUltimaDicaAtiva()
        {
            try
            {
                return tbldica.Find(x => x.id_dica > -1).OrderByDescending(z => z.dt_criacao).Take(1).ToList();
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
