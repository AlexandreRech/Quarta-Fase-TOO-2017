using System;

namespace eAgenda.ConsoleApp
{
    public abstract class CadastroConsole 
    {
        private string _tituloTela;

        public CadastroConsole(string tituloTela)
        {
            _tituloTela = tituloTela;
        }

        public void MostrarMenu()
        {
            ConsoleKey opcao = MostrarMenuOperacoes();

            do
            {
                if (opcao == ConsoleKey.Escape)
                    break;

                Console.Clear();
                Console.WriteLine(_tituloTela);
                Console.WriteLine();

                switch (opcao)
                {
                    case ConsoleKey.F1:
                        Console.WriteLine("Inserindo registros...\n");
                        bool inseridoComSucesso = InserirRegistro();

                        if (inseridoComSucesso)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registro inserido com sucesso!");
                            Console.ResetColor();
                        }
                        break;

                    case ConsoleKey.F2:
                        Console.WriteLine("Atualizando registros...\n");
                        bool alteradoComSucesso = AtualizarRegistro();
                        if (alteradoComSucesso)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registro atualizado com sucesso!");
                            Console.ResetColor();
                        }
                        break;

                    case ConsoleKey.F3:
                        Console.WriteLine("Excluindo registros...\n");
                        bool excluidoComSucesso = ExcluirRegistro();
                        if (excluidoComSucesso)
                        {
                            Console.Clear();
                            Console.ForegroundColor = ConsoleColor.Green;
                            Console.WriteLine("Registro excluido com sucesso!");
                            Console.ResetColor();
                        }
                        break;

                    case ConsoleKey.F4:
                        Console.WriteLine("Mostrando todos os registros...\n");
                        MostrarRegistros("CONSULTA");
                        break;

                    default:
                        Console.WriteLine("Opção inválida...");
                        break;
                }

                Console.WriteLine();
                Console.WriteLine("Aperte uma tecla para continuar...");
                Console.ReadKey();

                opcao = MostrarMenuOperacoes();

            } while (opcao != ConsoleKey.Escape);
        }

        public static CadastroConsole SelecionarCadastro()
        {
            Console.Clear();

            MostrarMenuCadastros();

            ConsoleKey opcao = Console.ReadKey().Key;

            if (opcao == ConsoleKey.Escape)
                return null;

            CadastroConsole cadastroSelecionado = null;

            do
            {
                if (opcao == ConsoleKey.F1)
                {
                    cadastroSelecionado = new TarefaConsole();
                    return cadastroSelecionado;
                }
                if (opcao == ConsoleKey.F2)
                {
                    cadastroSelecionado = new ContatoConsole();
                    return cadastroSelecionado;
                }

                NotificadorConsole.MostrarMensagem("ERRO", "Opção inválida! Aperte uma tecla para continuar...");

                MostrarMenuCadastros();

                opcao = Console.ReadKey().Key;

            } while (opcao != ConsoleKey.Escape);

            return null;
        }

        #region métodos privados
        private static void MostrarMenuCadastros()
        {
            Console.WriteLine("Digite F1 para gerenciar Tarefas");

            Console.WriteLine("Digite F2 para gerenciar Contatos");

            Console.WriteLine();

            Console.WriteLine("Digite Esc para sair");
        }

        protected static void PararExecucaoAplicativo()
        {
            Console.WriteLine();

            Console.WriteLine("Aperte uma tecla para continuar...");

            Console.ReadKey();
        }

        private ConsoleKey MostrarMenuOperacoes()
        {
            Console.Clear();

            Console.WriteLine(_tituloTela);

            Console.WriteLine();

            Console.WriteLine("Digite F1 para Inserir um novo registro");
            Console.WriteLine("Digite F2 para Atualizar as informações");
            Console.WriteLine("Digite F3 para Excluir um registro");
            Console.WriteLine("Digite F4 para Consultar registros");

            Console.WriteLine("Digite Esc para Voltar");

            ConsoleKey opcao = Console.ReadKey().Key;

            return opcao;
        }

        #endregion

        #region métodos abstratos
        public abstract bool InserirRegistro();

        public abstract bool AtualizarRegistro();

        public abstract bool ExcluirRegistro();

        public abstract bool MostrarRegistros(string operacao);
        #endregion

    }

   
}