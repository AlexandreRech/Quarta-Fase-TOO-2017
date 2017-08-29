using System;
using System.Linq;
using System.Collections.Generic;
using eAgenda.Dominio.TarefaModule;

namespace eAgenda.ConsoleApp
{
    public class TarefaConsole : CadastroConsole
    {
        private static int _contador = 0;

        private static List<Tarefa> _tarefas = new List<Tarefa>();

        public TarefaConsole()
            : base("Cadastro de Tarefas")
        {
        }

        public override bool InserirRegistro()
        {
            Tarefa novaTarefa = MontarTarefa();

            try
            {
                novaTarefa.Validar();
            }
            catch (TarefaInvalidaException tarefaExc)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(tarefaExc.Message);

                Console.ResetColor();

                Console.ReadKey();

                return false;
            }

            #region inserção de subitens
            ConsoleKey opcao;

            Console.WriteLine();

            Console.WriteLine("Adicionado subitens...");

            Console.WriteLine();
            do
            {
                Subitem subitem = MontarSubitem();

                novaTarefa.AdicionarSubitem(subitem);

                MostrarSubMenuSubitens();

                opcao = Console.ReadKey().Key;

            } while (opcao != ConsoleKey.Enter);

            #endregion

            RegistrarNovaTarefa(novaTarefa);

            return true;
        }
        
        public override bool AtualizarRegistro()
        {
            bool temRegistros = MostrarRegistros("ATUALIZAÇÃO");

            if (!temRegistros)
                return false;          

            Tarefa tarefaEncontrada = Pesquisar(atualizando: true);

            MostrarDetalhesTarefa(tarefaEncontrada);

            #region atualização de subitens
            MostrarSubMenuDeAtualizacao();

            ConsoleKey opcao = Console.ReadKey().Key;

            do
            {
                switch (opcao)
                {
                    case ConsoleKey.F1:

                        Tarefa tarefa = MontarTarefa();

                        try
                        {
                            tarefa.Validar();
                        }
                        catch (TarefaInvalidaException tarefaExc)
                        {
                            Console.ForegroundColor = ConsoleColor.Red;

                            Console.WriteLine(tarefaExc.Message);

                            Console.ResetColor();

                            Console.ReadKey();

                            return false;
                        }

                        tarefa.Numero = tarefaEncontrada.Numero;

                        AtualizarTarefa(tarefa);

                        break;

                    case ConsoleKey.F2:

                        Console.WriteLine("Subitem: ");

                        foreach (Subitem subitem in tarefaEncontrada.Subitens)
                        {
                            if (subitem != null)
                                Console.WriteLine("\t ->" + subitem);
                        }

                        Console.Write("Digite o número do Subitem que gostaria de concluir: ");

                        int numero = int.Parse(Console.ReadLine());

                        tarefaEncontrada.ConcluirSubitem(numero);

                        break;

                }

                MostrarSubMenuDeAtualizacao();

                opcao = Console.ReadKey().Key;

            } while (opcao != ConsoleKey.Escape);
            #endregion

            AtualizarTarefa(tarefaEncontrada);

            return true;
        }
        
        public override bool ExcluirRegistro()
        {
            bool temRegistros = MostrarRegistros("EXCLUSÃO");

            if (!temRegistros)
                return false;

            Tarefa tarefaEncontrada = Pesquisar(atualizando: false);

            MostrarDetalhesTarefa(tarefaEncontrada);

            Console.WriteLine("Tem certeza que deseja excluir a tarefa: {0}", tarefaEncontrada.Titulo);

            Console.WriteLine("Digite 'S' para confirmar e 'N' para cancelar");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                if (tarefaEncontrada.EstaConcluida())
                {
                    _tarefas.Remove(tarefaEncontrada);
                    return true;
                }

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Esta tarefa não pode ser excluída");
                Console.ReadKey();
                Console.ResetColor();
            }

            return false;
        }

        public override bool MostrarRegistros(string operacao)
        {
            Console.Clear();

            List<Tarefa> tarefas = null;

            if (operacao == "ATUALIZAÇÃO" || operacao == "EXCLUSÃO")
            {               
                MostrarTarefas(_tarefas);

                return _tarefas.Count > 0;
            }

            ConsoleKey opcao;

            do
            {
                MostrarSubMenuDeConsulta();

                opcao = Console.ReadKey().Key;

                switch (opcao)
                {
                    case ConsoleKey.F1:
                        Console.ReadKey();
                        Console.WriteLine("Visualizando as tarefas pendentes: ");
                        Console.WriteLine();
                        tarefas = SelecionarTarefasPendentes();
                        break;

                    case ConsoleKey.F2:
                        Console.ReadKey();
                        Console.WriteLine("Visualizando as tarefas concluídas: ");
                        Console.WriteLine();
                        tarefas = SelecionarTarefasConcluidas();
                        break;

                    case ConsoleKey.F3:
                        Console.ReadKey();
                        Console.WriteLine("Visualizando todas as tarefas: ");
                        Console.WriteLine();
                        tarefas = SelecionarTodasTarefas();
                        break;

                    case ConsoleKey.Escape:
                        return false;
                }

                MostrarTarefas(tarefas);

                PararExecucaoAplicativo();

            } while (opcao != ConsoleKey.Escape);

            return false;
        }
        
        #region métodos privados

        private void RegistrarNovaTarefa(Tarefa novaTarefa)
        {
            _contador++;

            novaTarefa.Numero = _contador;

            _tarefas.Add(novaTarefa);
        }

        private void AtualizarTarefa(Tarefa tarefaAtualizada)
        {
            Tarefa t = SelecionarTarefaPorNumero(tarefaAtualizada.Numero);

            t.DataInicializacao = tarefaAtualizada.DataInicializacao;
            t.DataConclusao = tarefaAtualizada.DataConclusao;
            t.Titulo = tarefaAtualizada.Titulo;
        }
        
        private List<Tarefa> SelecionarTodasTarefas()
        {
            return _tarefas;
        }

        private List<Tarefa> SelecionarTarefasConcluidas()
        {
            List<Tarefa> tarefasConcluidas = new List<Tarefa>();

            foreach (Tarefa t in _tarefas)
            {
                if (t.EstaConcluida())
                    tarefasConcluidas.Add(t);
            }

            return tarefasConcluidas;
        }

        private List<Tarefa> SelecionarTarefasPendentes()
        {
            List<Tarefa> tarefasPendentes = new List<Tarefa>();

            foreach (Tarefa t in _tarefas)
            {
                if (t.EstaPendente())
                    tarefasPendentes.Add(t);
            }

            return tarefasPendentes;
        }

        public Tarefa SelecionarTarefaPorNumero(int numero)
        {
            Tarefa tarefaEncontrada = null;

            foreach (Tarefa t in _tarefas)
            {
                if (t.Numero == numero)
                {
                    tarefaEncontrada = t;
                    break;
                }
            }

            return tarefaEncontrada;

        }

        #endregion
        
        #region métodos privados de tela
        private Tarefa Pesquisar(bool atualizando)
        {
            Tarefa registroSelecionado = null;

            do
            {
                Console.WriteLine();

                Console.Write("Digite o número do registro a ser {0} ", atualizando ? "atualizado" : "excluído");

                int numero = Convert.ToInt32(Console.ReadLine());

                try
                {
                    registroSelecionado = SelecionarTarefaPorNumero(numero);

                    Console.Clear();
                }
                catch (TarefaNaoEncontradaException registroNaoEncontrado)
                {
                    Console.WriteLine(registroNaoEncontrado);
                    Console.ReadKey();
                }

            } while (registroSelecionado == null);

            return registroSelecionado;
        }


        private void MostrarSubMenuDeConsulta()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para visualizar as tarefas pendentes");

            Console.WriteLine("Digite F2 para visualizar as tarefas concluídas");

            Console.WriteLine("Digite F3 para visualizar todas as tarefas");

            Console.WriteLine("Digite Esc para Voltar");
        }

        private void MostrarSubMenuDeAtualizacao()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para atualizar os dados básicos da tarefa");

            Console.WriteLine("Digite F2 para atualizar os percentuais dos subitens");

            Console.WriteLine("Digite Esc para Voltar");          
        }

        private void MostrarSubMenuSubitens()
        {
            Console.WriteLine();

            Console.WriteLine("Digite F1 para Inserir um novo subitem");

            Console.WriteLine("Aperte Enter para confirmar");

            Console.WriteLine();
           
            Console.SetCursorPosition(0, Console.CursorTop);           
        }

        private void MostrarDetalhesTarefa(Tarefa tarefaEncontrada)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Nº: {0}", tarefaEncontrada.Numero);

            Console.WriteLine("Título da tarefa: {0}", tarefaEncontrada.Titulo);

            Console.WriteLine("Percentual de Conclusão: {0}", tarefaEncontrada.ObtemPercentualConcluido());

            Console.WriteLine("Data de Conclusão: {0}", tarefaEncontrada.DataConclusao);

            Console.WriteLine();

            if (tarefaEncontrada.Subitens == null)
                return;

            Console.WriteLine("Subitens: ");

            foreach (Subitem subitem in tarefaEncontrada.Subitens)
            {
                if (subitem != null)
                {
                    Console.WriteLine("Nº: {0}", subitem.Numero);

                    Console.WriteLine("Título do subitem: {0}", subitem.Titulo);

                    Console.WriteLine("Concluído? {0}", subitem.EstaConcluido() ? "Sim" : "Não");
                }

            }

            Console.WriteLine();
        }

        private void MostrarTarefas(List<Tarefa> tarefas)
        {
            if (tarefas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma tarefa encontrada!");
                Console.ResetColor();
            }

            foreach (Tarefa tarefa in tarefas)
            {
                if (tarefa == null)
                    continue;

                Console.WriteLine(tarefa);

                if (tarefa.Subitens == null)
                {
                    continue;
                }              
            }
        }
        
        private Tarefa MontarTarefa()
        {
            Console.Write("Digite o título da Tarefa: ");
            string titulo = Console.ReadLine();

            Console.Write("Digite a data de inicialização da Tarefa: ");
            string dataInicializacao = Console.ReadLine();

            Console.Write("Digite a data de conclusão da Tarefa: ");
            string dataConclusao = Console.ReadLine();

            Console.Write("Digite a prioridade da Tarefa: ");
            int prioridade = int.Parse( Console.ReadLine() );

            Tarefa tarefa = new Tarefa(titulo, Convert.ToDateTime(dataInicializacao), Convert.ToDateTime(dataConclusao), prioridade);

            return tarefa;
        }

        private Subitem MontarSubitem()
        {
            Console.Write("Digite o título do Subitem: ");

            string titulo = Console.ReadLine();

            Subitem subitem = new Subitem(titulo);

            return subitem;
        }
        
        #endregion

    }
}