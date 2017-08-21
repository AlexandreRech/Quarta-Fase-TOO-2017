using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp
{
    public class Contato
    {
        public Contato(string nome, string email, string telefone, string empresa, string cargo)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Empresa = empresa;
            Cargo = cargo;
        }

        public string Nome { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Empresa { get; set; }

        public string  Cargo { get; set; }
        public int Numero { get; internal set; }

        internal void Validar()
        {
            if (string.IsNullOrEmpty(Nome))
                throw new ContatoInvalidoException("O Nome do Contato é obrigatório preenchimento");

            if (string.IsNullOrEmpty(Email))
                throw new ContatoInvalidoException("O Email do Contato é obrigatório preenchimento");

            if (string.IsNullOrEmpty(Telefone))
                throw new ContatoInvalidoException("O Telefone do Contato é obrigatório preenchimento");
        }

        public override string ToString()
        {
            StringBuilder resultado = new StringBuilder();

            resultado.Append("Número: ")
                .Append(Numero).Append(" - ")
                .Append(Nome).Append(" - ")
                .Append(Telefone).Append(" - ")
                .Append(Email);

            return resultado.ToString();
        }

        public static int CompararPeloNome(Contato a, Contato b)
        {
            return string.Compare(a.Nome, b.Nome);
        }
    }
}