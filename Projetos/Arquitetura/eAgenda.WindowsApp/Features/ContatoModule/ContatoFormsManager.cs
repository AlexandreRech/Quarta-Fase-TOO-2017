using eAgenda.Dominio.ContatoModule;
using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp.Features.ContatoModule
{
    public class ContatoFormsManager : FormsManager
    {
        private ControladorContato _controlador;

        public ContatoFormsManager(ControladorContato controlador)
        {
            _controlador = controlador;
        }
        internal override void Adicionar()
        {
            ContatoDialog dialog = new ContatoDialog();
            DialogResult resultado = dialog.ShowDialog();

            if (resultado == DialogResult.OK)
            {
                Contato contato = new Contato("Robinho","rob@ndd.com","987", "ndd", "ts");

                _controlador.RegistrarNovoContato(contato);
            }
        }

        internal override string ObtemTipo()
        {
            return "Cadastro de Contatos";
        }
    }
}
