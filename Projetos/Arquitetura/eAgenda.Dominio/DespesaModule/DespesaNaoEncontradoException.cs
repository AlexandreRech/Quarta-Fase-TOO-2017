using System;
using System.Runtime.Serialization;

namespace eAgenda.Dominio.DespesaModule
{
    public class RegistroNaoEncontradoException : Exception
    {    
        public RegistroNaoEncontradoException(string message) : base(message)
        {
        }        
    }
}