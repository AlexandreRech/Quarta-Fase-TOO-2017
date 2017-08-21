using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionsConsoleApp
{
    public class ProgramExceptionsFramework
    {
        static void Main2(string[] args)
        {
            Console.WriteLine( "Digite o caminho do arquivo para visualizar" );

            string caminhoArquivo = Console.ReadLine();

            string conteudoArquivo = "";
            try
            {
                conteudoArquivo = File.ReadAllText(caminhoArquivo, Encoding.Default );

                File.Delete(caminhoArquivo);
            }
            catch (ArgumentException ae)
            {
                Console.WriteLine("o caminho do arquivo não pode ser em branco");
            }
            catch(IOException ioe)
            {

            }
           

            Console.WriteLine( "Conteúdo do Arquivo:" );

            Console.WriteLine( conteudoArquivo );

            Console.ReadKey();
        }
    }
}
