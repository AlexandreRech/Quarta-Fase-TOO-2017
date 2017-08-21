namespace ExpressoesLambdaApp
{
    internal class Nota
    {
        
        public Nota(double nota)
        {
            this.Valor = nota;

            if (nota > 5)
                Status = StatusEnum.Boa;

            else if (nota == 5)
                Status = StatusEnum.Media;

            else
                Status = StatusEnum.Ruim;
        }

        public double Valor { get; set; }

        public StatusEnum Status { get; set; }

        public override string ToString()
        {
            return Valor + " - " + Status;
        }
    }

    public enum StatusEnum
    {
        Boa,
        Media,
        Ruim
    }
}