using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using Access;

namespace Business
{
    public class ParametrosBU
    {
        public IList<tblparametro> RetornaTodosParametros()
        {
            try
            {
                return new ParametroCA().RetornaTodosParametros();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public IList<tblparametro> RetornaTodosParametrosAtivos()
        {
            try
            {
                return new ParametroCA().RetornaTodosParametrosAtivos();
            }
            catch (Exception e)
            {
                throw e;
            }
        }

        public void AtualizarParametro(tblparametro parametro)
        {
            try
            {
                new ParametroCA().AtualizarParametro(parametro);
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
