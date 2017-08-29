using eAgenda.WindowsApp.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.WindowsApp.Features.TarefaModule
{
    public class TarefaFormsManager : FormsManager
    {
        internal override void Adicionar()
        {
            TarefaDialog dialog = new TarefaDialog();
            dialog.ShowDialog();
        }

        internal override string ObtemTipo()
        {
            return "Cadastro de Tarefas";
        }
    }
}
