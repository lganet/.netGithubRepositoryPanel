using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace RepositoriosGithub.Model.Entidades
{
    public class GitSearch
    {
        public int total_count { get; set; }
        public bool incomplete_results { get; set; }
        public List<RootObject> items { get; set; }
    }
}