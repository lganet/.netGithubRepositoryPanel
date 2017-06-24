using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriosGithub.Web.Models
{
    public class Paginacao
    {
        public bool Pesquisou { get; set; }
        public int PaginaAtual { get; set; }
        public int QuantidadePaginas { get; set; }
        public string TermoPesquisado { get; set; }
    }
}