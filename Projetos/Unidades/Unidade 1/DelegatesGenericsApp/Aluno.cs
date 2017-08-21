namespace DelegatesGenericsApp
{
    internal class Aluno
    {
        private string _nome;
        private double _altura;

        public Aluno()
        {
        }

        public Aluno(string nome, double altura)
        {
            this._nome = nome;
            this._altura = altura;
        }

        public override string ToString()
        {
            return _nome + " - " + _altura;
        }

        //public delegate int Comparison<in T>(T x, T y);
        public static int CompararPorAlturaAsc(Aluno a, Aluno b)
        {
            if (a._altura > b._altura)
                return 1;

            else if (a._altura < b._altura)
                return -1;

            else
                return 0;
        }

        public static int CompararPorAlturaDesc(Aluno a, Aluno b)
        {
            if (a._altura < b._altura)
                return 1;

            else if (a._altura > b._altura)
                return -1;

            else
                return 0;
        }
    }
}