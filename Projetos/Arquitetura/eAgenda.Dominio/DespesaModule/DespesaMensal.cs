using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.DespesaModule
{
    public class DespesaMensal
    {
        private string _mes;

        private double _subTotal;

        private List<Despesa> _despesas = new List<Despesa>();

        public DespesaMensal(int mes, List<Despesa> despesas)
        {
            _mes = new DateTimeFormatInfo().GetMonthName(mes);

            foreach (Despesa d in despesas)
            {
                if (d.Data.Month == mes)
                    _despesas.Add(d);
            }

            _subTotal = _despesas.Sum(x => x.Valor);
        }

        public string Mes { get { return _mes; } }

        public List<Despesa> Despesas { get { return _despesas; } }

        public override string ToString()
        {
            return string.Format("Despesas do mês de: {0}, Total {1}", _mes, _subTotal.ToString("C"));
        }
    }
}
