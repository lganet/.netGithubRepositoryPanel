using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriosGithub.Model.Entidades
{
    /// <summary>
    /// Dados dos repositórios favoritos.
    /// </summary>
    public class Favoritos
    {
        /// <summary>
        /// Usuário do repositório.
        /// </summary>
        public string usuario { get; set; }
        /// <summary>
        /// Repositório.
        /// </summary>
        public string repositorio { get; set; }
        /// <summary>
        /// Identificador do Repositório.
        /// </summary>
        public long id { get; set; }
    }
}