using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Net;

namespace RepositoriosGithub.Model.Pesquisas
{
 
    /// <summary>
    /// Classe responsável por pesquisar repositórios de um determinado usuário.
    /// </summary>
    public class Repositorios
    {

#region Métodos publicos

        /// <summary>
        /// Busca todos os repositórios de um determinado usuário.
        /// </summary>
        /// <returns>Todos os repositórios do usuário informado.</returns>
        /// <exception cref="NullReferenceException">Quando nome do repositório informado é inválido.</exception>
        /// <exception cref="RepositorioGitHubException">Ocorre quando ocorre algum erro na consulta da API do GitHub.</exception>
        public List<Entidades.RootObject> PegarRepositorios(string usuario)
        {
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrWhiteSpace(usuario)){
                throw new NullReferenceException("Usuário informado é inválido.");
            }

            List<Entidades.RootObject> resultado = null;
            var client = new RestSharp.RestClient("https://api.github.com/");
            var request = new RestSharp.RestRequest("users/{user}/repos", RestSharp.Method.GET);

            request.AddUrlSegment("user", usuario);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Entidades.RootObject>>(response.Content);
            }
            else
            {
                throw new Excecoes.RepositorioGitHubException(String.Format("Ocorreu erro no momento da consulta. Código: {0} com a mensagem: {1}.", response.StatusCode, response.ErrorMessage));
            }

            return resultado;
           
        }

        /// <summary>
        /// Faz uma pesquisa no Github buscandos todos os repositórios publicos.
        /// </summary>
        /// <param name="termpoPesquisa">Nome ou parte do repositório que deseja pesquisar.</param>
        /// <param name="pagina">Página atual de pesquisa.</param>
        /// <returns>Retorna um objeto com o resultado da consulta ao Github.</returns>
        /// <exception cref="NullReferenceException">Quando o termo da pesquisa informado é inválido.</exception>
        /// <exception cref="IndexOutOfRangeException">Quando o número da página é menor ou igual a zero.</exception>
        /// <exception cref="RepositorioGitHubException">Ocorre quando ocorre algum erro na consulta da API do GitHub.</exception>
        public Entidades.GitSearch ProcurarRepositorios(string termpoPesquisa, int pagina)
        {
            
            if (String.IsNullOrEmpty(termpoPesquisa) || String.IsNullOrWhiteSpace(termpoPesquisa))
            {
                throw new NullReferenceException("Termo utilizado na pesquisa é inválido.");
            }

            if (pagina <= 0){
                throw new IndexOutOfRangeException("Página inválida, ela deve ser um número maior que zero.");
            }

            Entidades.GitSearch resultado = null;
            var client = new RestSharp.RestClient("https://api.github.com/");
            var request = new RestSharp.RestRequest("search/repositories?q={repositorio}&page={pagina}&per_page=20", RestSharp.Method.GET);

            request.AddUrlSegment("repositorio", termpoPesquisa);
            request.AddUrlSegment("pagina", pagina.ToString());

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Entidades.GitSearch>(response.Content);
            }
            else
            {
                throw new Excecoes.RepositorioGitHubException(String.Format("Ocorreu erro no momento da consulta. Código: {0} com a mensagem: {1}.", response.StatusCode, response.ErrorMessage));
            }

            return resultado;
        }

        /// <summary>
        /// Detalha um determinado repositorio.
        /// </summary>
        /// <param name="usuario">Nome do usuário, dono do repositório.</param>
        /// <param name="repositorio">Repositório que será pegos os detalhes.</param>
        /// <returns>Retorna um objeto com detalhes do repositório do Github.</returns>
        /// <exception cref="NullReferenceException">Quando nome do repositório informado é inválido.</exception>
        /// <exception cref="IndexOutOfRangeException">Quando o número da página é menor ou igual a zero.</exception>
        /// <exception cref="RepositorioGitHubException">Ocorre quando ocorre algum erro na consulta da API do GitHub.</exception>
        public Entidades.RootObject DetalharRepositorio(string usuario, string repositorio)
        {
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrWhiteSpace(usuario))
            {
                throw new NullReferenceException("Usuário informado é inválido.");
            }

            if (String.IsNullOrEmpty(repositorio) || String.IsNullOrWhiteSpace(repositorio))
            {
                throw new NullReferenceException("Nome do repositório é inválido.");
            }

            Entidades.RootObject resultado = null;
            var client = new RestSharp.RestClient("https://api.github.com/");
            var request = new RestSharp.RestRequest("repos/{usuario}/{repositorio}", RestSharp.Method.GET);

            request.AddUrlSegment("usuario", usuario);
            request.AddUrlSegment("repositorio", repositorio);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<Entidades.RootObject>(response.Content);
            }
            else
            {
                throw new Excecoes.RepositorioGitHubException(String.Format("Ocorreu erro no momento da consulta. Código: {0} com a mensagem: {1}.", response.StatusCode, response.ErrorMessage));
            }

            return resultado;
        }

        /// <summary>
        /// Retorna todos os contribuidores de um determiando repositório.
        /// </summary>
        /// <param name="usuario">Nome do usuário, dono do repositório.</param>
        /// <param name="repositorio">Repositório que será pegos os detalhes.</param>
        /// <returns>Retorna um objeto com todos os contribuidores do repositório do Github.</returns>
        /// <exception cref="NullReferenceException">Quando nome do repositório informado é inválido.</exception>
        /// <exception cref="IndexOutOfRangeException">Quando o número da página é menor ou igual a zero.</exception>
        /// <exception cref="RepositorioGitHubException">Ocorre quando ocorre algum erro na consulta da API do GitHub.</exception>
        public List<Entidades.Contribuidores> ContribuidoresRepositorio(string usuario, string repositorio)
        {
            if (String.IsNullOrEmpty(usuario) || String.IsNullOrWhiteSpace(usuario))
            {
                throw new NullReferenceException("Usuário informado é inválido.");
            }

            if (String.IsNullOrEmpty(repositorio) || String.IsNullOrWhiteSpace(repositorio))
            {
                throw new NullReferenceException("Nome do repositório é inválido.");
            }

            List<Entidades.Contribuidores> resultado = null;
            var client = new RestSharp.RestClient("https://api.github.com/");
            var request = new RestSharp.RestRequest("repos/{usuario}/{repositorio}/contributors", RestSharp.Method.GET);

            request.AddUrlSegment("usuario", usuario);
            request.AddUrlSegment("repositorio", repositorio);

            var response = client.Execute(request);

            if (response.StatusCode == HttpStatusCode.OK)
            {
                resultado = Newtonsoft.Json.JsonConvert.DeserializeObject<List<Entidades.Contribuidores>>(response.Content);
            }
            else
            {
                throw new Excecoes.RepositorioGitHubException(String.Format("Ocorreu erro no momento da consulta. Código: {0} com a mensagem: {1}.", response.StatusCode, response.ErrorMessage));
            }

            return resultado;
        }

#endregion

    }
}