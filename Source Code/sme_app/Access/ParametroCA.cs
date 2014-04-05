using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;

namespace Access
{
    public class ParametroCA
    {
        public IList<tblparametro> RetornaTodosParametros()
        {
            try
            {
                return tblparametro.Find(x => x.id_parametro > -1);
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
                return tblparametro.Find(x => x.id_parametro > -1 && x.is_habilitado != false);
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
                tblparametro newParametro = new tblparametro();
                newParametro.SetIsNew(false);
                newParametro.SetIsLoaded(true);
                newParametro.SetKeyValue(parametro.id_parametro);
                
                newParametro.chave = parametro.chave;
                newParametro.is_habilitado = parametro.is_habilitado;
                newParametro.src = parametro.src;
                newParametro.title = parametro.title;
                newParametro.valor = parametro.valor;
                
                newParametro.Update();
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
