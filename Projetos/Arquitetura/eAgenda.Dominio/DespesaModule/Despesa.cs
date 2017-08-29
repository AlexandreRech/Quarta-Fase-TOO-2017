using System;

namespace eAgenda.Dominio.DespesaModule
{
    public class Despesa
    {
        public Despesa()
        {
            Data = DateTime.Now;
        }       

        public string Descricao { get; set; }

        public string Categoria { get; set; }

        public DateTime Data { get; set; }

        public double Valor { get; set; }

        public string FormaPagamento { get; set; }

        public int Numero { get; set; }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Categoria))
                throw new DespesaInvalidaException("O preenchimento da categoria é obrigatório");

            if (string.IsNullOrEmpty(Descricao))
                throw new DespesaInvalidaException("O preenchimento da descricao é obrigatório");
        }

        public override string ToString()
        {
            return string.Format("{0} -> {1} {2} ({3})",
                Numero, Valor.ToString("C"), Descricao, Data.ToShortDateString());
        }
    }
}
