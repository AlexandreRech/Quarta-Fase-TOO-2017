using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassesAbstratasConsoleApp
{
    class ControladorBonificacao
    {
        public double TotalBonificacao = 0;
        public void Bonificar(Funcionario funcionario)
        {
            TotalBonificacao += funcionario.Bonificar();
        }


    }
}
