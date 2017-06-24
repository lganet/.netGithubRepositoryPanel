using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace RepositoriosGithub.Web.Controllers
{
    public class FavoritoController : Controller
    {
        //
        // GET: /Favorito/

        [HttpPost]
        public JsonResult Adicionar(Model.Entidades.Favoritos favorito)
        {
            object json;
            try { 
                Model.Pesquisas.Favoritos favoritos = new Model.Pesquisas.Favoritos(PegarArquivo());
                favoritos.Adicionar(favorito);
                json = new { sucesso = true };
            }
            catch (Exception ex)
            {
                json = new { sucesso = false, mensagem = ex.Message };
            }

            return Json(json);
        }

        [HttpDelete]
        public JsonResult Remover(long id)
        {
            object json;
            try
            {
                Model.Pesquisas.Favoritos favoritos = new Model.Pesquisas.Favoritos(PegarArquivo());
                favoritos.Remover(new Model.Entidades.Favoritos() { id = id });
                json = new { sucesso = true };
            }
            catch (Exception ex)
            {
                json = new { sucesso = false, mensagem = ex.Message };
            }

            return Json(json);
        }

        public ActionResult Listar(){
            try
            {
                Model.Pesquisas.Favoritos favoritos = new Model.Pesquisas.Favoritos(PegarArquivo());
                List<Model.Entidades.Favoritos> resultado = favoritos.Listar();
                return View(resultado);
            }
            catch (Exception ex)
            {
                TempData["Erro"] = ex.Message;
                return RedirectToAction("Erro", "Home");
            }
        }

        private string PegarArquivo()
        {
            string path = HttpContext.Server.MapPath("~/App_Data");
            return System.IO.Path.Combine(path, "favoritos.json");
        }

    }
}
