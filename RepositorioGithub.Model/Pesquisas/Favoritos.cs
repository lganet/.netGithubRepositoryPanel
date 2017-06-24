using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.IO;

namespace RepositoriosGithub.Model.Pesquisas
{
    /// <summary>
    /// Responsável pela manutenção dos favoritos.
    /// </summary>
    public class Favoritos
    {

#region Variáveis

        /// <summary>
        /// Caminho junto ao nome do arquivo.
        /// </summary>
        private string arquivo;

#endregion

#region Métodos publicos

        /// <summary>
        /// Construtror da classe.
        /// </summary>
        /// <param name="arquivo">Caminho junto ao nome do arquivo.</param>
        /// <exception cref="NullReferenceException">Ocorre quando nome do arquivo é inváido.</exception>
        /// <exception cref="DirectoryNotFoundException">Ocorre quando o caminho informado é inválido.</exception>
        public Favoritos(string arquivo)
        {
            if (String.IsNullOrEmpty(arquivo) || String.IsNullOrWhiteSpace(arquivo))
            {
                throw new NullReferenceException("Nome informado para o arquivo é inváido.");
            }

            if (! System.IO.Directory.Exists(System.IO.Path.GetDirectoryName(arquivo)))
            {
                throw new System.IO.DirectoryNotFoundException("O caminho especificado para o repositório dos favoritos não é válido.");
            }

            this.arquivo = arquivo;
        }

        /// <summary>
        /// Adiciona junto ao repositórios de favoritos um novo favorito.
        /// </summary>
        /// <param name="favorito">Entidade de favoritos.</param>
        public void Adicionar(Entidades.Favoritos favorito)
        {
            List<Entidades.Favoritos> lista = Listar();

            if (!lista.Exists(l => l.id == favorito.id)){
                lista.Add(favorito);
            }
            
            Salvar(lista);

        }

        /// <summary>
        /// Remove junto ao repositórios de favoritos um favorito.
        /// </summary>
        /// <param name="favorito">Entidade de favoritos.</param>
        public void Remover(Entidades.Favoritos favorito)
        {
            List<Entidades.Favoritos> lista = Listar();

            lista.RemoveAll(l => l.id == favorito.id);

            Salvar(lista);
        }

        /// <summary>
        /// Retorna todos os favoritos salvos.
        /// </summary>
        /// <returns>Todos os favoritos salvos.</returns>
        public List<Entidades.Favoritos> Listar()
        {
            string conteudoArquivo = CarregarArquivo();
            var resultado = new List<Entidades.Favoritos>();

            if (!String.IsNullOrEmpty(conteudoArquivo))
            {
                resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Entidades.Favoritos>>(conteudoArquivo);
            }

            return resultado;
        }

        /// <summary>
        /// Identifica pelo código se um determinado repositório está nos favoritos.
        /// </summary>
        /// <param name="codigo">Identificador do repositório.</param>
        /// <returns>Verdadeiro caso o repositório esteja nos favoritos.</returns>
        public bool EstaNoFavoritos(long codigo)
        {
            List<Entidades.Favoritos> lista = Listar();

            return lista.Exists(l => l.id == codigo);
        }
#endregion
#region Métodos privados
        /// <summary>
        /// Carrega o repositório de favoritos.
        /// </summary>
        /// <returns>Uma string com todos os repositórios.</returns>
        private string CarregarArquivo()
        {
            if (System.IO.File.Exists(arquivo))
            {
                return System.IO.File.ReadAllText(arquivo);
            }

            return null;
        }

        /// <summary>
        /// Salva no repositórios uma lista de favoritos.
        /// </summary>
        /// <param name="lista">Lista de favoritos.</param>
        private void Salvar(List<Entidades.Favoritos> lista)
        {
            var conteudo = Newtonsoft.Json.JsonConvert.SerializeObject(lista);
            System.IO.File.WriteAllText(arquivo, conteudo);

        }
#endregion

    }
}