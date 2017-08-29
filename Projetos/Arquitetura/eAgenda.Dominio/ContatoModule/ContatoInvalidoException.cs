using System;
using System.Runtime.Serialization;

namespace eAgenda.Dominio.ContatoModule
{
    [Serializable]
    public class ContatoInvalidoException : Exception
    {
        public ContatoInvalidoException()
        {
        }

        public ContatoInvalidoException(string message) : base(message)
        {
        }

        public ContatoInvalidoException(string message, Exception innerException) : base(message, innerException)
        {
        }

        protected ContatoInvalidoException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }
    }
}