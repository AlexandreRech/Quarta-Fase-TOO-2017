namespace MetodosAnonimosApp
{
    internal class Aluno
    {
        #region atributos
        private string _nome;
        private double _altura;
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

        public double Altura { get { return _altura; } }
        public override string ToString()
        {
            return _nome + " - " + _altura;
        }
             
    }
}