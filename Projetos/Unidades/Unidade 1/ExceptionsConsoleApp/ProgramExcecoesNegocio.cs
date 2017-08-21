using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsConsoleApp
{
    class ProgramExcecoesNegocio
    {
        static void Main(string[] args)
        {
            ContaCorrente novaConta = new ContaCorrente();

            try
            {
                novaConta.Depositar(2000);
                novaConta.Sacar(1000, DateTime.Now);
                Console.WriteLine( "Saldo atualizado " + novaConta.Saldo );
            }
            catch (SaldoInsuficienteException sie)
            {
                Console.WriteLine(sie);                
            }
            catch (DataInvalidaException die)
            {
                Console.WriteLine(die);
            }

            Console.ReadKey();
        }
    }

    public class ContaCorrente
    {
        public double Saldo { get; private set; }

        public void Depositar(double quantia)
        {
            Saldo += quantia;
        }

        public void Sacar(double quantia, DateTime data)
        {
            if (quantia > Saldo)
                throw new SaldoInsuficienteException(this, quantia);

            if (data.DayOfWeek == DayOfWeek.Sunday || data.DayOfWeek == DayOfWeek.Saturday)
                throw new DataInvalidaException(data);

            Saldo -= quantia;
        }
    }
}
