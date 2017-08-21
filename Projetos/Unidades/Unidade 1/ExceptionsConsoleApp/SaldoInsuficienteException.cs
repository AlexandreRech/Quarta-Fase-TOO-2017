using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsConsoleApp
{
    public class SaldoInsuficienteException : ApplicationException
    {
        private ContaCorrente contaCorrente;
        private double quantia;       

        public SaldoInsuficienteException(ContaCorrente contaCorrente, double quantia)
        {
            this.contaCorrente = contaCorrente;
            this.quantia = quantia;
        }

        public override string ToString()
        {
            return string.Format
                ("A quantia informada R$ {0} é maior que o saldo atual (R$ {1} )",
                quantia, contaCorrente.Saldo);
        }
    }
}
