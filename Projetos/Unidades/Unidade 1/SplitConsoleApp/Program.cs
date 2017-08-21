namespace SplitConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] numeros = "1-2-3-4-5-6-7-8-9".Split('-') ;

            string[] nomeEsenha = "Alexandre Rech - 123456".Split('-');

            //string nome = nomeEsenha[0];

            int senha = int.Parse(nomeEsenha[1]);

            string usuario = "1rech3";

            char[] usuarioCaracteres = usuario.ToCharArray();

            string usuarioCorreto = "";

            foreach (char caracter in usuarioCaracteres)
            {
                if (char.IsLetter(caracter))
                    usuarioCorreto += caracter;
            }
        }
    }
}
