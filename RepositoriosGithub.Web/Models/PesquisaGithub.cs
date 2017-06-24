using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriosGithub.Web.Models
{
    public class PesquisaGithub
    {
        public Paginacao Paginacao { get; set; }
        public Model.Entidades.GitSearch ResultadoPesquisa { get; set; }
    }
}