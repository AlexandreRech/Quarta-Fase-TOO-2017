using System;

namespace GenericsConsoleApp
{
    public class Correio
    {

        public Correio()
        {
        }

        internal void Enviar<T>(Envelope<T> envelope)
        {
            Console.WriteLine( "Enviando a carta com o seguinte conteúdo: " + envelope.Conteudo );

            Console.WriteLine(  "Enviado com sucesso");
        }
    }
}