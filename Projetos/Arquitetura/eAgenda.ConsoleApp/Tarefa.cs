using System;
using System.Collections.Generic;
using System.Text;

namespace eAgenda.ConsoleApp
{
    public class Tarefa 
    {
        private List<Subitem> _subitens;

        public Tarefa()
        {
            this.Titulo = "";
            this.DataInicializacao = DateTime.Now;
            this.DataConclusao = DateTime.Now;
            this.Prioridade = 0;
            _subitens = new List<Subitem>();
        }

        public Tarefa(string titulo, DateTime dataInicializacao, DateTime dataConclusao, int prioridade)
        {
            this.Titulo = titulo;
            this.DataInicializacao = dataInicializacao;
            this.DataConclusao = dataConclusao;
            this.Prioridade = prioridade;
            _subitens = new List<Subitem>();
        }

        public int Numero { get; set; }
        public string Titulo { get; set; }

        public DateTime DataInicializacao { get; set; }

        public DateTime DataConclusao { get; set; }

        public int Prioridade { get; set; }

        public List<Subitem> Subitens { get { return _subitens; } }
        public void AdicionarSubitem(Subitem novoSubitem)
        {
           _subitens.Add(novoSubitem);
        }

        public void AdicionarSubitem(string titulo)
        {
            Subitem novoSubitem = new Subitem(titulo);

            AdicionarSubitem(novoSubitem);
        }

        public override string ToString()
        {
            StringBuilder resultado = new StringBuilder();

            resultado.Append(Titulo)
                .Append(" - Percentual Concluído: ")                
                .Append(ObtemPercentualConcluido() + "%")                
                .Append(Environment.NewLine);

            foreach (Subitem subitem in _subitens)
            {
                resultado
                    .Append(subitem.Numero)
                    .Append("->")                    
                    .Append(subitem.Titulo)
                    .Append(Environment.NewLine);
            }

            

            return resultado.ToString();
        }

        public void Validar()
        {
            if (string.IsNullOrEmpty(Titulo))
                throw new TarefaInvalidaException("O Título da tarefa é obrigatório preenchimento");

            if (DataInicializacao > DataConclusao)
                throw new TarefaInvalidaException("A Data de Inicialização deve ser menor que a Data de Conclusão");

            if (Prioridade > 10 || Prioridade < 0)
                throw new TarefaInvalidaException("A Prioridade deve estar entre 1 - 10");
        }

        public void ConcluirSubitem(int numeroSubitem)
        {
            foreach (Subitem subitem in _subitens)
            {
                if (subitem.Numero == numeroSubitem)
                {
                    subitem.Concluir();                    
                    break;
                }
            }
        }

        public void RemoverSubitem(int numero)
        {
            for (int i = 0; i < _subitens.Count; i++)
            {
                Subitem item = _subitens[i];
                if (item.Numero == numero && item.EstaConcluido())
                {
                    _subitens.RemoveAt(i);
                }
            }
        }

        public decimal ObtemPercentualConcluido()
        {
            decimal totalSubitensConcluidos = ObtemQuantidadeSubitensConcluidos();

            decimal totalSubitens = ObtemQuantidadeTotalSubitens();

            decimal percentual = (totalSubitensConcluidos / totalSubitens) * 100;

            return Math.Round( percentual, 2);
        }

        public int ObtemQuantidadeTotalSubitens()
        {
            return _subitens.Count;
        }

        private int ObtemQuantidadeSubitensConcluidos()
        {
            int total = 0;

            foreach (Subitem subitem in _subitens)
            {
                if (subitem.EstaConcluido())
                    total++;
            }

            return total;
        }

        public bool EstaConcluida()
        {
            if ((int)ObtemPercentualConcluido() == 100)
                return true;

            return false;
        }

        public bool EstaPendente()
        {
            return !EstaConcluida();
        }
    }
}