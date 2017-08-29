using System;
using System.Runtime.Serialization;

namespace eAgenda.Dominio.ContatoModule
{
    [Serializable]
    public class ContatoNaoEncontradoException : Exception
    {
        public ContatoNaoEncontradoException()
        {
        }

        public ContatoNaoEncontradoException(string message) : base(message)
        {
        }

        public ContatoNaoEncontradoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContatoNaoEncontradoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}