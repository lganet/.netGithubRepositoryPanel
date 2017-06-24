using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace RepositoriosGithub.Model.Excecoes
{
    /// <summary>
    /// Objeto de exceção base para o sistema.
    /// </summary>
    public class RepositorioGitHubException : Exception
    {

        /// <summary>
        /// Construtor do objeto.
        /// </summary>
        /// <param name="mensagem">Mensagem contendo o erro.</param>
        public RepositorioGitHubException(string mensagem)
            : base(mensagem)
        {
            
        }


    }
}
