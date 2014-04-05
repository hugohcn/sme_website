using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Common
{
    public class SecurityCommon
    {
        /// <summary>
        /// Método de geração de senhas randômicas
        /// </summary>
        /// <returns>Senha contendo o número de caracteres exigidos</returns>
        public string GerarHash(int tamanhoHash)
        {
            string senha = string.Empty;

            for (int i = 0; i < tamanhoHash; i++)
            {
                Random random = new Random();

                int codigo = Convert.ToInt32(random.Next(48, 122).ToString());

                if ((codigo >= 48 && codigo <= 57) || (codigo >= 97 && codigo <= 122))
                {
                    string _char = ((char)codigo).ToString();
                    if (!senha.Contains(_char))
                    {
                        senha += _char;
                    }
                    else
                    {
                        i--;
                    }
                }
                else
                {
                    i--;
                }
            }
            return senha;
        }

        /// <summary>
        /// Método para tratamento de strings.
        /// </summary>
        /// <param name="strValor"></param>
        /// <returns></returns>
        public string TratarString(string strValor)
        {
            string aux = strValor;
            aux = aux.Replace(")", "");
            aux = aux.Replace("(", "");
            aux = aux.Replace(".", "");
            aux = aux.Replace("'", "");
            aux = aux.Replace("/", "");
            aux = aux.Replace("#", "");
            aux = aux.Replace("-", "");
            aux = aux.Replace("ç", "c");
            aux = aux.Replace("<", "");
            aux = aux.Replace(">", "");
            aux = aux.Replace("?", "");
            aux = aux.Replace("^", "");
            aux = aux.Replace("~", "");
            aux = aux.Replace("`", "");
            aux = aux.Replace("´", "");
            aux = aux.Replace("[", "");
            aux = aux.Replace("]", "");
            aux = aux.Replace("{", "");
            aux = aux.Replace("}", "");
            aux = aux.Replace("ã", "a");
            aux = aux.Replace("õ", "o");
            aux = aux.Replace("á", "a");
            aux = aux.Replace("à", "a");
            aux = aux.Replace("ó", "o");


            return aux;
        }
    }
}
