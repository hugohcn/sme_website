using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Sme.Data;

namespace Access
{
    public class LoginAC
    {
        public tbllogin RetornaUsuarioAcessoSistemaPorLoginESenha(string _login, string _senha)
        {
            try 
	        {	        
                return tbllogin.SingleOrDefault(x => x.login.Equals(_login) && x.senha.Equals(_senha));	            
	        }
	        catch (Exception e)
	        {
		        throw e;
	        }             
        }
    }
}
