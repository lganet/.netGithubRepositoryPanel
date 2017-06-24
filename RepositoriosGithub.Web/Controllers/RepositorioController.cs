using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using RepositoriosGithub.Model.Pesquisas;

namespace RepositoriosGithub.Web.Controllers
{
    public class RepositorioController : Controller
    {

        public ActionResult MeusRepositorios()
        {
            string usuario;
            List<Model.Entidades.RootObject> resultado;
            try {
                usuario = System.Configuration.ConfigurationManager.AppSettings["MeusRepositorios"];
                Repositorios repositorios = new Repositorios();
                resultado = repositorios.PegarRepositorios(usuario);

                ViewBag.Usuario = usuario;
                }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Erro", "Home");
            }
            return View(resultado);
        }

        public ActionResult PesquisarRepositorios(string termoPesquisado, int? pagina)
        {
            Models.PesquisaGithub pesquisa;
            try { 
                if (String.IsNullOrEmpty(termoPesquisado) || !pagina.HasValue || pagina.Value == 0)
                {
                    pesquisa = new Models.PesquisaGithub()
                    {
                        Paginacao = new Models.Paginacao()
                        {
                            Pesquisou = false
                        }
                    };
                }
                else
                {
                    var resultado = FazerPesquisa(termoPesquisado, pagina.Value);

                    // github não deixa vir mais de 1000 resultado, mesmo paginado, se olhar no Search do site ele também é limitado nisso.

                    pesquisa = new Models.PesquisaGithub()
                    {
                        ResultadoPesquisa = resultado,
                        Paginacao = new Models.Paginacao()
                        {
                            Pesquisou = true,
                            PaginaAtual = pagina.Value,
                            QuantidadePaginas = (resultado.total_count > 1000 ? 1000 : resultado.total_count) / 20,
                            TermoPesquisado = termoPesquisado

                        }
                    };
                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Erro", "Home");
            }
            return View(pesquisa);
        }

        private RepositoriosGithub.Model.Entidades.GitSearch FazerPesquisa(string repositorio, int paginaAtual)
        {
            RepositoriosGithub.Model.Entidades.GitSearch gitSearch = null;

            Repositorios repositorios = new Repositorios();
            gitSearch = repositorios.ProcurarRepositorios(repositorio, paginaAtual);

            return gitSearch;
        }

        public ActionResult ExibirResultadoPesquisa(string repositorio, int? paginaAtual)
        {

            RepositoriosGithub.Model.Entidades.GitSearch gitSearch = null;
            try
            {
                if (!paginaAtual.HasValue)
                {
                    paginaAtual = 1;
                }

                // Irei tratar como a primeira consulta.
                if (!String.IsNullOrEmpty(repositorio))
                {
                    Repositorios repositorios = new Repositorios();
                    gitSearch = repositorios.ProcurarRepositorios(repositorio, paginaAtual.Value);

                }
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Erro", "Home");
            }

            return View(gitSearch);
        }


        public ActionResult DetalhesRepositorio(string usuario, string repositorio)
        {
            Model.Entidades.RootObject detalhes;

            try { 
                Repositorios repositorios = new Repositorios();
                detalhes = repositorios.DetalharRepositorio(usuario, repositorio);

                Model.Pesquisas.Favoritos favoritos = new Favoritos(PegarArquivo());

                ViewBag.Favorito = favoritos.EstaNoFavoritos(detalhes.id);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Erro", "Home");
            }
            return View(detalhes);
        }

        public ActionResult ContribuidoresRepositorio(string usuario, string repositorio)
        {
            List<Model.Entidades.Contribuidores> contribuidores;
            try { 
                Repositorios repositorios = new Repositorios();
                contribuidores = repositorios.ContribuidoresRepositorio(usuario, repositorio);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Erro", "Home");
            }
            return View(contribuidores);
        }

        private string PegarArquivo()
        {
            string path = HttpContext.Server.MapPath("~/App_Data");
            return System.IO.Path.Combine(path, "favoritos.json");
        }
    }
}
