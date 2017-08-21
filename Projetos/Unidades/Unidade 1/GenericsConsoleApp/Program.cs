using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericsConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Envelope<string> novoEnvelope = new Envelope<string>();
            novoEnvelope.Conteudo = "Oi Mãe!";

            Envelope<double> segundoEnvelope = new Envelope<double>();
            segundoEnvelope.Conteudo =  10000;          

            Correio correio = new Correio();
            correio.Enviar<string>(novoEnvelope);
            correio.Enviar<double>(segundoEnvelope);

        }
    }
}