using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.DespesaModule
{
   public class DespesaMensalPorCategoria
    {
        private string _categoria;

        private double _subTotal;

        private List<Despesa> _despesas;

        public DespesaMensalPorCategoria(string categoria, List<Despesa> despesas)
        {
            _categoria = categoria;
            _despesas = despesas;
            _subTotal = despesas.Sum(x => x.Valor);
        }

        public List<Despesa> Despesas { get { return _despesas; } }

        public override string ToString()
        {
            return string.Format("{0}: {1}", _categoria, _subTotal.ToString("C"));
        }
    }
}
