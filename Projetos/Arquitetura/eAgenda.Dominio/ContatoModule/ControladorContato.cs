using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.ContatoModule
{
    public class ControladorContato
    {
        private static List<Contato> _contatos = new List<Contato>();
        private static int _contador = 0;
        
        public Contato SelecionarContatoPorNumero(int numero)
        {
            Contato contatoEncontrado = null;

            foreach (Contato t in _contatos)
            {
                if (t.Numero == numero)
                {
                    contatoEncontrado = t;
                    break;
                }
            }

            return contatoEncontrado;
        }

        public void AtualizarContato(Contato contatoAtualizado)
        {
            Contato c = SelecionarContatoPorNumero(contatoAtualizado.Numero);

            c.Nome = contatoAtualizado.Nome;
            c.Telefone = contatoAtualizado.Telefone;
            c.Email = contatoAtualizado.Email;
            c.Empresa = contatoAtualizado.Empresa;
            c.Cargo = contatoAtualizado.Cargo;
        }

        public void RegistrarNovoContato(Contato novoContato)
        {
            _contador++;

            novoContato.Numero = _contador;

            _contatos.Add(novoContato);
        }

        public void ExcluirContato(Contato contatoEncontrado)
        {
            _contatos.Remove(contatoEncontrado);
        }

        public List<Contato> SelecionarContatos()
        {
            return _contatos;
        }
    }
}
