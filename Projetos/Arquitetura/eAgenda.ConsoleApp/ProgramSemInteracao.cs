using eAgenda.Dominio.TarefaModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace eAgenda.ConsoleApp
{
    class ProgramSemInteracao
    {
        void Main(string[] args)
        {
            DateTime hoje = DateTime.Now;
            DateTime domingo = hoje.AddDays(6);

            Tarefa tarefa1 = new Tarefa("Preparar Segunda Aula de TOO", hoje, domingo, 10);
            
            tarefa1.AdicionarSubitem("Gravar Vídeo Aula");
            tarefa1.AdicionarSubitem("Pesquisar Bibliografias");
            tarefa1.AdicionarSubitem("Montar apostila da unidade 2");            

            tarefa1.ConcluirSubitem(1);
            tarefa1.ConcluirSubitem(2);

            Console.WriteLine(tarefa1);

            Console.ReadKey();

        }
    }
}
