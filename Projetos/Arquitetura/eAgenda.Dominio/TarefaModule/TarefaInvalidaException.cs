using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.Dominio.TarefaModule
{
    public class TarefaInvalidaException : ApplicationException
    {
        public TarefaInvalidaException(string msg) : base(msg)
        {

        }
       

        public TarefaInvalidaException(string message, Exception innerException) : base(message, innerException)
        {
        }

       
    }
}
