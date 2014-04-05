using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using Access;

namespace Business
{
    public class DicasBU
    {
        public IList<tbldica> RetornaTodasDicas()
        {
            try
            {
                  return new DicasAC().RetornaTodasDicas();
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
                return new DicasAC().Retorna4UltimasDicasAposUltima();
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
                return new DicasAC().RetornaDicaById(idDica);
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
                new DicasAC().InserirDica(titulo, descricao, conteudo, fonte, dtCriacao);
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
                new DicasAC().AtualizarDica(idDica, titulo, descricao, conteudo, fonte, dtCriacao);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
        
        public void RemoveDica(tbldica dica){
            try
            {
                new DicasAC().RemoveDica(dica); 
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
                return new DicasAC().RetornaUltimaDicaAtiva();
            }
            catch (Exception e)
            {
                throw e;
            }    
        }
    }
}
