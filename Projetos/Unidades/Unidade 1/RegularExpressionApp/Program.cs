using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace RegularExpressionApp
{
    class Program
    {
        static void Main(string[] args)
        {
            bool resultado = IsValidPhone("(98) 9999-0000");

            resultado = IsValidPhone("(99) 9999-0000");

            resultado = IsValidMail("rech@ndd.com.");
        }

        /// <summary>
        ///   Para formatar a validação do telefone como (xx) xxxxx-xxxx podemos utilizar 
        ///   esta expressão regular: ^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$. 
        ///   Abaixo segue a explicação:
        ///
        ///       ^ - Início da string.
        ///       \( - Um abre parênteses.
        ///       [1-9]{2} - Dois dígitos de 1 a 9. Não existem códigos de DDD com o dígito 0.
        ///       \) - Um fecha parênteses.
        ///
        ///        - Um espaço em branco.
        ///       [2-9] - O primeiro dígito. Nunca será 0 ou 1.
        ///       [0-9]{3,4} - Os demais dígitos da primeira metade do número do telefone, perfazendo um total de 4 ou 5 dígitos na primeira metade.
        ///       \- - Um hífen.
        ///       [0-9]{4} - A segunda metade do número do telefone.
        ///       $ - Final da string.
        /// </summary>
        /// <param name="Phone"></param>
        /// <returns></returns>
        public static bool IsValidPhone(string Phone)
        {
            if (string.IsNullOrEmpty(Phone))
                return false;

            var r = new Regex(@"^\([1-9]{2}\) [2-9][0-9]{3,4}\-[0-9]{4}$");

            return r.IsMatch(Phone);
        }

        public static bool IsValidMail(string mail)
        {
            if (string.IsNullOrEmpty(mail))
                return false;
            
            var r = new Regex(@"^\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*$");

            return r.IsMatch(mail);
        }
             

        //ferramenta para validar: http://regexr.com/


    }
}
