using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            CadastroConsole cadastroSelecionado = null;

            do
            {
                cadastroSelecionado = CadastroConsole.SelecionarCadastro();

                if (cadastroSelecionado != null)
                    cadastroSelecionado.MostrarMenu();

            } while (cadastroSelecionado != null);
        }
    }
}
