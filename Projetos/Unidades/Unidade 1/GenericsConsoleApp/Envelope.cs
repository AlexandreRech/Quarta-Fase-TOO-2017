using System.Collections.Generic;

namespace GenericsConsoleApp
{
    public class Envelope<T>
    {
        public T Conteudo { get; set; }

        //public static Dictionary<string, List<Correio>> Correios { get; set; }

        //public void Teste()
        //{
        //    List<Correio> correiosDeLages = new List<Correio>();

        //    correiosDeLages.Add(new Correio("Centro"));
        //    correiosDeLages.Add(new Correio("Coral"));
        //    correiosDeLages.Add(new Correio("Carah"));

        //    Correios.Add("Lages", correiosDeLages);
        //}
    }
}