﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosAnonimosApp
{
    class Program
    {
        static void Main(string[] args)
        {
            Aluno aluno1 = new Aluno("Alberto", 1.78);

            Aluno aluno2 = new Aluno("David", 2.02);

            Aluno aluno3 = new Aluno("Dienisson", 1.68);

            Aluno aluno4 = new Aluno("Rodrigo", 1.82);

            List<Aluno> classe = new List<Aluno>();


                        
            classe.Add(aluno1);
            classe.Add(aluno2);
            classe.Add(aluno3);
            classe.Add(aluno4);

            MostrarAlunos(classe);

            //ordenar crescente utilizando métodos anônimos
            classe.Sort(delegate(Aluno a, Aluno b) {

                if (a.Altura > b.Altura)
                    return 1;

                else if (a.Altura < b.Altura)
                    return -1;

                else
                    return 0;
            });

            MostrarAlunos(classe);

            //ordenar decrescente
            classe.Sort(delegate(Aluno a, Aluno b) {

                if (a.Altura < b.Altura)
                    return 1;

                else if (a.Altura > b.Altura)
                    return -1;

                else
                    return 0;
            } );

            MostrarAlunos(classe);

            //invocando
            //Aluno.CompararPorAlturaDesc(aluno1, aluno2);

            Console.ReadKey();
        }

        private static void MostrarAlunos(List<Aluno> classe)
        {
            foreach (Aluno a in classe)
            {
                Console.WriteLine(a);
            }

            Console.WriteLine("-----------------------");
        }
    }
}
