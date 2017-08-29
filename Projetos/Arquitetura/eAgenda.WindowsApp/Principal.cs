using eAgenda.Dominio.ContatoModule;
using eAgenda.WindowsApp.Features.ContatoModule;
using eAgenda.WindowsApp.Features.TarefaModule;
using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace eAgenda.WindowsApp
{
    public partial class Principal : Form
    {
        private FormsManager _cadastro;

        public Principal()
        {
            InitializeComponent();
        }

        private void tarefasMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(new TarefaFormsManager());
        }

        private void contatosMenuItem_Click(object sender, EventArgs e)
        {
            CarregarCadastro(new ContatoFormsManager(new ControladorContato()));
        }

        private void btnAdicionar_Click(object sender, EventArgs e)
        {
            _cadastro.Adicionar();
        }

        private void CarregarCadastro(FormsManager cadastro)
        {
            _cadastro = cadastro;

            labelTipoCadastro.Text = _cadastro.ObtemTipo();
        }


    }
}
