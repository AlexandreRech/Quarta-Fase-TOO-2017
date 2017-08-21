using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsConsoleApp
{
    class ProgramControleChamada
    {        
        static void Main2(string[] args)
        {
           Console.WriteLine("Inicio Método Main");
            try
            {
                Metodo1();
            }
            catch { }
            Console.WriteLine("Fim Método Main");

            Console.ReadKey();
        }

        private static void Metodo1()
        {
            Console.WriteLine("Inicio Método1");
            Metodo2();
            Console.WriteLine("Fim Método1");
        }

        private static void Metodo2()
        {
            Console.WriteLine("Inicio Método2");

            int[] array = new int[] {
                1,2,3,4,5,6,7,8,9,10,11,12,13,14
            };

            for (int i = 0; i < 20; i++)
            {
                Console.WriteLine(array[i]);
            }

            Console.WriteLine("Fim Método2");
        }
    }
}
