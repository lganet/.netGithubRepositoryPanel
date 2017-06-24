using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

using git = RepositoriosGithub.Model.Pesquisas;
using RepositoriosGithub.Model.Excecoes;

namespace RepositoriosGithub.Testes
{
    [TestClass]
    public class Repositorios
    {
        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuandoInformadoUsuarioInvalidoDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            repositorios.PegarRepositorios(null);

        }

        [TestMethod]
        public void QuandoInformadoUmUsuarioValidoDeveUmValor()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.PegarRepositorios("lganet");

            Assert.IsNotNull(resultado);

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InformandoUmNomeDeRepositorioInvalidoNaPesquisaDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.ProcurarRepositorios(null, 10);
        }

        [TestMethod]
        [ExpectedException(typeof(IndexOutOfRangeException))]
        public void InformandoUmaPaginaDeRepositorioInvalidaDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.ProcurarRepositorios("lganet", 0);
        }


        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InformandoUmNomeDeUsuarioInvalidoNoDetalhesDeRepositorioDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.DetalharRepositorio(null, null);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InformandoUmNomeDeRepositorioInvalidoNoDetalhesDeRepositorioDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.DetalharRepositorio("lganet", null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositorioGitHubException))]
        public void InformandoUmRepositorioOuUsuarioInvalidoNoDetalhesDeRepositorioDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.DetalharRepositorio("lganet", "CDEMolhitosssas");
        }

        [TestMethod]
        public void InformandoUmRepositorioUmUsuarioValidoNoDetalhesDeRepositorioDeVirDados()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.DetalharRepositorio("lganet", "CDEMobile");

            Assert.IsNotNull(resultado);
        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void InformandoUmNomeDeRepositorioInvalidoNoContribuidoresDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.ContribuidoresRepositorio("lganet", null);
        }

        [TestMethod]
        [ExpectedException(typeof(RepositorioGitHubException))]
        public void InformandoUmRepositorioOuUsuarioInvalidoNoContribuidoresDeRepositorioDeveOcorrerUmErro()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.ContribuidoresRepositorio("lganet", "CDEMolhitosssas");
        }

        [TestMethod]
        public void InformandoUmRepositorioUmUsuarioValidoNoContribuidoresDeRepositorioDeVirDados()
        {
            git.Repositorios repositorios = new git.Repositorios();
            var resultado = repositorios.ContribuidoresRepositorio("scalyr", "angular");

            Assert.IsNotNull(resultado);
        }

    }
}
