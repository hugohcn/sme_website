using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Access;
using SubSonic.Schema;

namespace Business
{
    public class PaginaConteudoBU
    {
        public void InserirConteudoPagina(string pagina, string conteudo)
        {
            try
            {
                new PaginaConteudoCA().InserirConteudoPagina(pagina, conteudo);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }

        public object RetornaConteudoPagina(string pagina)
        {
            try
            {
                return new PaginaConteudoCA().RetornaConteudoPagina(pagina);

            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
        
        public void AtualizarConteudoPagina(string pagina, string conteudo)
        {
            try
            {
                  new PaginaConteudoCA().AtualizarConteudoPagina(pagina, conteudo);
            }
            catch (Exception eX)
            {
                throw eX;
            }
        }
    }
}
