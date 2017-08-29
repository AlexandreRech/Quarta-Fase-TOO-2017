using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using eAgenda.Dominio.ContatoModule;

namespace eAgenda.ConsoleApp
{
    public class ContatoConsole : CadastroConsole
    {
        private ControladorContato _controlador = new ControladorContato();
        
        public ContatoConsole() 
            : base("Cadastro de Contatos")
        {
        }

        public override bool InserirRegistro()
        {
            Contato novoContato = MontarContato();           

            try
            {
                novoContato.Validar();
            }
            catch (ContatoInvalidoException contatoInvalidoExc)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(contatoInvalidoExc.Message);

                Console.ResetColor();

                Console.ReadKey();

                return false;
            }

            _controlador.RegistrarNovoContato(novoContato);

            return true;
        }

        public override bool AtualizarRegistro()
        {
            bool temRegistros = MostrarRegistros("ATUALIZAÇÃO");

            if (!temRegistros)
                return false;

            Contato contatoEncontrado = Pesquisar(atualizando: true);

            MostrarDetalhesContato(contatoEncontrado);

            Contato contatoAtualizado = MontarContato();

            contatoAtualizado.Numero = contatoEncontrado.Numero;

            _controlador.AtualizarContato(contatoAtualizado);

            return true;
        }

        public override bool ExcluirRegistro()
        {
            bool temRegistros = MostrarRegistros("EXCLUSÃO");

            if (!temRegistros)
                return false;

            Contato contatoEncontrado = Pesquisar(atualizando: false);

            MostrarDetalhesContato(contatoEncontrado);

            Console.WriteLine("Tem certeza que deseja excluir o contato: {0}", contatoEncontrado.Nome);

            Console.WriteLine("Digite 'S' para confirmar e 'N' para cancelar");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                _controlador.ExcluirContato(contatoEncontrado);

                return true;
            }

            return false;
        }

        public override bool MostrarRegistros(string operacao)
        {
            Console.Clear();

            List<Contato> contatos = _controlador.SelecionarContatos();

            if (operacao == "ATUALIZAÇÃO" || operacao == "EXCLUSÃO")
            {                
                MostrarContatos(contatos);

                return contatos.Count > 0;
            }

            ConsoleKey opcao;

            do
            {
                MostrarSubMenuDeConsulta();

                opcao = Console.ReadKey().Key;

                switch (opcao)
                {
                    case ConsoleKey.F1:
                        Console.Clear();
                        Console.WriteLine("Visualizando Contatos Agrupados por Cargo: ");
                        Console.WriteLine();

                        MostrarContatosAgrupados();

                        break;

                    case ConsoleKey.F2:
                        Console.Clear();
                        Console.WriteLine("Visualizando Contatos por Ordem Alfabética: ");
                        Console.WriteLine();

                        MostrarContatosPorOrdemAlfabetica();

                        break;

                    case ConsoleKey.F3:
                        Console.Clear();
                        Console.WriteLine("Visualizando Todos Contatos: ");
                        Console.WriteLine();

                        MostrarContatos(contatos);

                        break;                  

                    case ConsoleKey.Escape:
                        return false;
                }

                PararExecucaoAplicativo();

            } while (opcao != ConsoleKey.Escape);

            return false;
        }

        private void MostrarContatosPorOrdemAlfabetica()
        {
            //List<Contato> contatosOrdenados = new List<Contato>(_contatos);

            /**ordenação utilizando delegates
            contatosOrdenados.Sort(Contato.OrdenarPeloNome);
            */

            /**métodos anônimos
            contatosOrdenados.Sort(delegate(Contato a, Contato b) 
            {
                return string.Compare(a.Nome, b.Nome);
            });
            */

            /**expressão lambda
            contatosOrdenados.Sort((a, b) => string.Compare(a.Nome, b.Nome));
            */

            List<Contato> contatos = _controlador.SelecionarContatos();

            //Extesion Methods + Collections + Generics + Expressão Lambda
            MostrarContatos(contatos.OrderBy(c => c.Nome).ToList());
        }
        
        #region métodos privados de tela

        private void MostrarContatosAgrupados()
        {
            HashSet<string> cargos = new HashSet<string>();

            List<Contato> contatos = _controlador.SelecionarContatos();

            foreach (Contato c in contatos)
            {
                cargos.Add(c.Cargo);
            }

            foreach (string cargo in cargos)
            {
                Console.WriteLine(cargo);

                foreach (Contato contato in contatos)
                {
                    if (contato.Cargo != cargo)
                        continue;

                    Console.WriteLine(contato);
                }
            }
        }

        private void MostrarSubMenuDeConsulta()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para visualizar Contatos Agrupados por Cargo");

            Console.WriteLine("Digite F2 para visualizar Contatos Ordenados por Ordem Alfabética");

            Console.WriteLine("Digite F3 para visualizar Todos Contatos");           

            Console.WriteLine("Digite Esc para Voltar");
        }

        private void MostrarDetalhesContato(Contato contatoEncontrado)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Nº: {0}", contatoEncontrado.Numero);

            Console.WriteLine("Nome: {0}", contatoEncontrado.Nome);

            Console.WriteLine("Telefone: {0}", contatoEncontrado.Telefone);

            Console.WriteLine("Email: {0}", contatoEncontrado.Email);

            Console.WriteLine("Empresa: {0}", contatoEncontrado.Empresa);

            Console.WriteLine("Cargo: {0}", contatoEncontrado.Cargo);

            Console.WriteLine();
        }

        private Contato Pesquisar(bool atualizando)
        {
            Contato registroSelecionado = null;

            do
            {
                Console.WriteLine();

                Console.Write("Digite o número do registro a ser {0} ", atualizando ? "atualizado" : "excluído");

                int numero = Convert.ToInt32(Console.ReadLine());

                try
                {
                    registroSelecionado = _controlador.SelecionarContatoPorNumero(numero);

                    Console.Clear();
                }
                catch (ContatoNaoEncontradoException registroNaoEncontrado)
                {
                    Console.WriteLine(registroNaoEncontrado);
                    Console.ReadKey();
                }

            } while (registroSelecionado == null);

            return registroSelecionado;
        }

        private Contato MontarContato()
        {
            Console.Write("Digite o Nome do Contato: ");
            string nome = Console.ReadLine();

            Console.Write("Digite o Email do Contato: ");
            string email = Console.ReadLine();

            Console.Write("Digite o Telefone do Contato: ");
            string telefone = Console.ReadLine();

            Console.Write("Digite a Empresa do Contato: ");
            string empresa = Console.ReadLine();

            Console.Write("Digite o Cargo do Contato: ");
            string cargo = Console.ReadLine();

            Contato contato = new Contato(nome, email, telefone, empresa, cargo);

            return contato;
        }

        private void MostrarContatos(List<Contato> contatos)
        {
            if (contatos.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma contato encontrado!");
                Console.ResetColor();
            }

            foreach (Contato contato in contatos)
            {
                if (contato == null)
                    continue;

                Console.WriteLine(contato);
            }
        }

        #endregion

    }
}
