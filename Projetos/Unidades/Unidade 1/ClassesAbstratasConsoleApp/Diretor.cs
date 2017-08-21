using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAbstratasConsoleApp
{
    public class Diretor : Funcionario
    {
        public override double Bonificar()
        {
            return Salario * 0.15;
        }
    }
}
