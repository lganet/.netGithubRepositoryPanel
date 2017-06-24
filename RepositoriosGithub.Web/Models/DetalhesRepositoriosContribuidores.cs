using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriosGithub.Web.Models
{
    /// <summary>
    /// Objeto com detalhes do Repositório e seus contribuidores.
    /// </summary>
    public class DetalhesRepositoriosContribuidores
    {
        /// <summary>
        /// Construtor da classe.
        /// </summary>
        public DetalhesRepositoriosContribuidores()
        {
            Contribuidores = new List<Model.Entidades.Contribuidores>();
        }

        /// <summary>
        /// Objeto com o detalhes do repositório.
        /// </summary>
        public Model.Entidades.RootObject Repositorio { get; set; }

        /// <summary>
        /// Objeto com todos os contribuidores do repositório que está vendo os detalhes.
        /// </summary>
        public List< Model.Entidades.Contribuidores> Contribuidores { get; set; }



    }
}