using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace InterfacesConsoleApp
{
    public class Gerente :Funcionario, IAutenticavel
    {
        public void Autenticar(string senha)
        {
            throw new NotImplementedException();
        }
    }
}