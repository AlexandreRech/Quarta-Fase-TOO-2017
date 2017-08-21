namespace DelegatesExampleApp
{
    class Program
    {
        public delegate int Operacao(int a, int b);

        public delegate void ApresentadorDelegate(string mensagem);

        static void Main(string[] args)
        {
            Operacao op;

            op = Somar;

            op += Subtrair;

            int resultado = op(10, 10);

            ApresentarMensagem(MostrarMensagemNoConsole, "Olá galera!");

            ApresentarMensagem(MostrarMensagemNoPopup, "Olá galera!");

            System.Console.ReadKey();
        }

        public static void ApresentarMensagem(ApresentadorDelegate apresentador, string mensagem)
        {
            System.Console.WriteLine("Iniciando o método...");

            apresentador(mensagem);

            System.Console.WriteLine("Método finalizado");
        }

        public static int Somar(int x, int y)
        {
            return x + y;
        }

        public static int Subtrair(int x, int y)
        {
            return x - y;
        }

        public static void MostrarMensagemNoConsole(string mensagem)
        {
            System.Console.WriteLine(mensagem);
        }

        public static void MostrarMensagemNoPopup(string mensagem)
        {
            System.Windows.Forms.MessageBox.Show(mensagem);
        }
    }
}
