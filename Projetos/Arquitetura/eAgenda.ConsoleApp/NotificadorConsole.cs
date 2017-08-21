using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp
{
    public class NotificadorConsole
     {
         public static void MostrarMensagem(string tipo, string mensagem)
         {
             if (tipo == "SUCESSO")
                 Console.ForegroundColor = ConsoleColor.Green;
 
             else if (tipo == "ERRO")
                 Console.ForegroundColor = ConsoleColor.Red;
 
             Console.WriteLine();
 
             Console.WriteLine(mensagem);
 
             Console.ReadKey();
 
             Console.Clear();
 
             Console.ResetColor();
         }
     }
}
