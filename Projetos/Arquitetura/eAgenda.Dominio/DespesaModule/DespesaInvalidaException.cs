using System;
using System.Runtime.Serialization;

namespace eAgenda.Dominio.DespesaModule
{
    public class DespesaInvalidaException : Exception
    {
        public DespesaInvalidaException(string message) : base(message)
        {
        }       
    }
}