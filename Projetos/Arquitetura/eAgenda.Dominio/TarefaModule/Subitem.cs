using System;

namespace eAgenda.Dominio.TarefaModule
{
    public class Subitem
    {
        private string _titulo;
        private int _numero;
        private bool _estaConcluido;

        private static int _contador = 0;       

        public Subitem(string titulo)
        {
            _contador++;
            _numero = _contador;
            this._titulo = titulo;
        }       

        public int Numero { get { return _numero; } }
        public string Titulo { get { return _titulo; } }

        public bool EstaConcluido()
        {
            return _estaConcluido;
        }

        public void Concluir()
        {
            _estaConcluido = true;
        }

        public override string ToString()
        {
            return Numero + " - " + Titulo;
        }
    }
}