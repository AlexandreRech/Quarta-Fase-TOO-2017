using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Secretario s = new Secretario();

            Diretor d = new Diretor();

            Cliente c = new Cliente();

            Autenticador autenticador = new Autenticador();

            autenticador.Autenticar(c, "123");
        }
    }
}
