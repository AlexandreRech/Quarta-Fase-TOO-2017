using eAgenda.Dominio.DespesaModule;
using System;
using System.Linq;
using System.Collections.Generic;
using eAgenda.Dominio.ContatoModule;

namespace eAgenda.ConsoleApp
{
    public class DespesaConsole : CadastroConsole
    {
        List<Despesa> _despesas = new List<Despesa>();
        private static int _contador;

        public DespesaConsole()
          : base("Cadastro de Despesas")
        {
        }

        public override bool InserirRegistro()
        {
            Despesa despesa = MontarDespesa();

            try
            {
                despesa.Validar();
            }
            catch (DespesaInvalidaException despesaExc)
            {
                Console.ForegroundColor = ConsoleColor.Red;

                Console.WriteLine(despesaExc.Message);

                Console.ResetColor();

                Console.ReadKey();

                return false;
            }

            RegistrarNovaDespesa(despesa);

            return true;
        }

        public override bool AtualizarRegistro()
        {
            bool temRegistros = MostrarRegistros("ATUALIZAÇÃO");

            if (!temRegistros)
                return false;

            Despesa despesaEncontrada = Pesquisar(atualizando: true);

            MostrarDetalhesDespesa(despesaEncontrada);

            Despesa despesa = MontarDespesa();

            despesa.Numero = despesaEncontrada.Numero;

            AtualizarDespesa(despesa);

            return true;
        }

        public override bool ExcluirRegistro()
        {
            bool temRegistros = MostrarRegistros("EXCLUSÃO");

            if (!temRegistros)
                return false;

            Despesa despesaEncontrada = Pesquisar(atualizando: false);

            MostrarDetalhesDespesa(despesaEncontrada);

            Console.WriteLine("Tem certeza que deseja excluir a despesa: {0}", despesaEncontrada.Descricao);

            Console.WriteLine("Digite 'S' para confirmar e 'N' para cancelar");

            if (Console.ReadKey().Key == ConsoleKey.S)
            {
                ExcluirDespesa(despesaEncontrada);

                return true;
            }

            return false;
        }

        public override bool MostrarRegistros(string operacao)
        {
            List<Despesa> despesas = null;

            if (operacao == "ATUALIZAÇÃO" || operacao == "EXCLUSÃO")
            {                
                despesas = SelecionarTodasDespesas();

                MostrarDespesas(despesas);

                return despesas.Count > 0;
            }

            ConsoleKey opcao;

            do
            {
                opcao = MostrarSubMenuDeConsulta();

                if (opcao == ConsoleKey.Escape)
                    return false;

                if (opcao == ConsoleKey.F1)
                {
                    MostrarDespesas(SelecionarTodasDespesas());

                    return false;
                }

                Console.Write("Digite o mês: ");

                int mes = int.Parse(Console.ReadLine());

                Console.Clear();

                DespesaMensal despesaMensal = SelecionarDespesasPorMes(mes);

                Console.WriteLine(despesaMensal);

                Console.WriteLine("------------------------------------------");

                switch (opcao)
                {
                    case ConsoleKey.F2:

                        MostrarDespesas(despesaMensal.Despesas);

                        break;

                    case ConsoleKey.F3:

                        List<DespesaMensalPorCategoria> despesasAgrupadas = SelecionarDespesasPorCategoria(despesaMensal);

                        MostrarDespesasPorCategoria(despesasAgrupadas);

                        break;
                }

                PararExecucaoAplicativo();

            } while (opcao != ConsoleKey.Escape);

            return false;
        }
        
        #region métodos privados

        public Despesa RegistrarNovaDespesa(Despesa despesa)
        {
            _contador++;

            despesa.Numero = _contador;

            _despesas.Add(despesa);

            return despesa;
        }

        public void AtualizarDespesa(Despesa despesaAtualizada)
        {
            Despesa d = SelecionarDespesaPorNumero(despesaAtualizada.Numero);

            d.Data = despesaAtualizada.Data;
            d.Categoria = despesaAtualizada.Categoria;
            d.Descricao = despesaAtualizada.Descricao;
            d.FormaPagamento = despesaAtualizada.FormaPagamento;
            d.Valor = despesaAtualizada.Valor;
        }

        public void ExcluirDespesa(Despesa despesaEncontrada)
        {
            _despesas.Remove(despesaEncontrada);
        }


        public List<Despesa> SelecionarTodasDespesas()
        {
            return _despesas;
        }

        public DespesaMensal SelecionarDespesasPorMes(int mes)
        {
            return new DespesaMensal(mes, _despesas);
        }

        public List<DespesaMensalPorCategoria> SelecionarDespesasPorCategoria(DespesaMensal despesaMensal)
        {
            return despesaMensal.Despesas.GroupBy(x => x.Categoria)
                   .Select(d => new DespesaMensalPorCategoria(d.Key, d.ToList()))
                   .ToList();
        }

        public Despesa SelecionarDespesaPorNumero(int numero)
        {
            foreach (Despesa despesa in _despesas)
            {
                if (despesa.Numero == numero)
                    return despesa;
            }

            return null;
        }

        #endregion

        #region métodos privados de tela

        private Despesa Pesquisar(bool atualizando)
        {
            Despesa registroSelecionado = null;

            do
            {
                Console.WriteLine();

                Console.Write("Digite o número do registro a ser {0} ", atualizando ? "atualizado" : "excluído");

                int numero = Convert.ToInt32(Console.ReadLine());

                try
                {
                    registroSelecionado = SelecionarDespesaPorNumero(numero);

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

        private void MostrarDespesasPorCategoria(List<DespesaMensalPorCategoria> despesasPorCategoria)
        {
            if (despesasPorCategoria.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma Despesa encontrada!");
                Console.ResetColor();
            }

            foreach (DespesaMensalPorCategoria despesaAgrupada in despesasPorCategoria)
            {
                Console.WriteLine(despesaAgrupada);

                MostrarDespesas(despesaAgrupada.Despesas);

                Console.WriteLine();
            }
        }

        private ConsoleKey MostrarSubMenuDeConsulta()
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Digite F1 para visualizar todas as despesas");

            Console.WriteLine("Digite F2 para visualizar as despesas mensais");

            Console.WriteLine("Digite F3 para visualizar as despesas de um mês agrupadas por categoria ");

            Console.WriteLine("Digite Esc para Voltar");

            ConsoleKey opcao = Console.ReadKey().Key;

            return opcao;
        }

        private void MostrarDespesas(List<Despesa> despesas)
        {
            if (despesas.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("Nenhuma Despesa encontrada!");
                Console.ResetColor();
                return;
            }

            Console.WriteLine("Despesas: ");

            foreach (Despesa despesa in despesas)
            {
                Console.WriteLine(despesa);
            }
        }

        private Despesa MontarDespesa()
        {
            Console.WriteLine("Digite o tipo da Despesa: ");

            Console.WriteLine();

            Console.WriteLine("Digite \"F1\" para Habitação");
            Console.WriteLine("Digite \"F2\" para Transporte");
            Console.WriteLine("Digite \"F3\" para Alimentação");
            Console.WriteLine("Digite \"F4\" para Saúde");
            Console.WriteLine("Digite \"F5\" para Cuidados Pessoais");

            Console.WriteLine();

            ConsoleKey opcao = Console.ReadKey().Key;

            string categoria = "";

            switch (opcao)
            {
                case ConsoleKey.F1:
                    categoria = "Habitação";
                    break;
                case ConsoleKey.F2:
                    categoria = "Transporte";
                    break;
                case ConsoleKey.F3:
                    categoria = "Alimentação";
                    break;
                case ConsoleKey.F4:
                    categoria = "Saúde";
                    break;
                case ConsoleKey.F5:
                    categoria = "Cuidados Pessoais";
                    break;

                default:
                    break;
            }

            Console.Write("Digite a descrição do Despesa: ");
            string descricao = Console.ReadLine();

            Console.Write("Digite a data da Despesa: ");
            string strData = Console.ReadLine();

            Console.Write("Digite o valor da Despesa: ");
            string strValor = Console.ReadLine();

            Console.Write("Digite a forma de pagamento da Despesa: ");

            Console.WriteLine();

            Console.WriteLine("Digite \"F1\" para Cartão de Crédito");
            Console.WriteLine("Digite \"F2\" para Dinheiro");

            opcao = Console.ReadKey().Key;

            string formaPgto = "";

            switch (opcao)
            {
                case ConsoleKey.F1:
                    formaPgto = "Cartão de Crédito";
                    break;
                case ConsoleKey.F2:
                    formaPgto = "Dinheiro";
                    break;

                default:
                    break;
            }

            Despesa despesa = new Despesa();

            despesa.Descricao = descricao;
            despesa.Categoria = categoria;
            despesa.Data = Convert.ToDateTime(strData);
            despesa.Valor = Convert.ToDouble(strValor);
            despesa.FormaPagamento = formaPgto;

            return despesa;
        }
        
        private void MostrarDetalhesDespesa(Despesa despesaEncontrada)
        {
            Console.Clear();

            Console.WriteLine();

            Console.WriteLine("Nº: {0}", despesaEncontrada.Numero);

            Console.WriteLine("Descrição: {0}", despesaEncontrada.Descricao);

            Console.WriteLine("Categoria: {0}", despesaEncontrada.Categoria);

            Console.WriteLine("Data: {0}", despesaEncontrada.Data);

            Console.WriteLine("Valor: {0}", despesaEncontrada.Valor);

            Console.WriteLine("Forma de pagamento: {0}", despesaEncontrada.FormaPagamento);

            Console.WriteLine();
        }

        #endregion

    }
}
