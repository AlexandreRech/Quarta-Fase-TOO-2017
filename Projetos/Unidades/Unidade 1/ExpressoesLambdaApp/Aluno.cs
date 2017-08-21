using System;
using System.Collections.Generic;
using System.Linq;

namespace ExpressoesLambdaApp
{
    internal class Aluno
    {
        #region atributos
        private string _nome;
        private double _altura;

        private List<Nota> _notas = new List<Nota>();
        #endregion
        #region métodos constructores
        public Aluno()
        {
        }

        public Aluno(string nome, double altura)
        {
            this._nome = nome;
            this._altura = altura;
        }
        #endregion


        public void RegistrarNota(double nota)
        {
            Nota novaNota = new Nota(nota);

            _notas.Add(novaNota);
        }

        public double Altura { get { return _altura; } }

        internal void OrdenarNotasDecrescente()
        {
            _notas = _notas.OrderByDescending( n =>  n.Valor ).ToList();
        }

        internal double MaiorNota()
        {
            return _notas.Max(n => n.Valor);
        }

        internal double MenorNota()
        {
            return _notas.Min(n => n.Valor);
        }

        public override string ToString()
        {
            return _nome + " - " + _altura;
        }
    }
}