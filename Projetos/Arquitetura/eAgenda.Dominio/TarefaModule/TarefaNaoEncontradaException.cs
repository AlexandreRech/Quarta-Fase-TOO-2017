using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.TarefaModule
{
    public class TarefaNaoEncontradaException : Exception
    {
        public TarefaNaoEncontradaException(string message) : base(message)
        {

        }
    }
}
