using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InterfacesConsoleApp
{
    public class Autenticador
    {
        public void Autenticar(IAutenticavel usuario, string senha)
        {
            try
            {
                usuario.Autenticar(senha);

                Console.WriteLine("Usuario autenticado");
            }
            catch (UsuarioSemPermissaoException exc)
            {
                EnviarEmailParaAdministrador();
            }

        }

        private void EnviarEmailParaAdministrador()
        {
            throw new NotImplementedException();
        }
    }
}
