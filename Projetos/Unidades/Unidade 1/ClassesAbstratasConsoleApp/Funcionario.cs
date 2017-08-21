using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAbstratasConsoleApp
{
    public abstract class Funcionario
    {
        public double Salario { get; set; }

        public string Nome { get; set; }

        public abstract double Bonificar();       

        public DateTime DataAdmissao { get; set; }
    }
}
