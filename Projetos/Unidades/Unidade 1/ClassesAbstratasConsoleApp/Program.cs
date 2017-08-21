using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAbstratasConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Funcionario dev = new Desenvolvedor();
            dev.Nome = "Luis";
            dev.Salario = 1000;

            Funcionario dir = new Diretor();
            dir.Nome = "Marco";
            dir.Salario = 2000;

            ControladorBonificacao bonificador = new ControladorBonificacao();

            bonificador.Bonificar(dev);
            bonificador.Bonificar(dir);
        }
    }
}
