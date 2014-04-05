using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;
using Access;

namespace Business
{
    public class LoginBU
    {
        public tbllogin RetornaUsuarioAcessoSistemaPorLoginESenha(string login, string senha)
        {
            try
            {
                if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(senha))
                    throw new Exception("Parâmetros nulos ou inválidos.");
                    
                return new LoginAC().RetornaUsuarioAcessoSistemaPorLoginESenha(login, senha);         
            }
            catch (Exception e)
            {
                throw e;
            }
        }
    }
}
