using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using git = RepositoriosGithub.Model.Pesquisas;
using RepositoriosGithub.Model.Excecoes;
using RepositoriosGithub.Model.Entidades;

namespace RepositoriosGithub.Testes.CasoDeTestes
{
    [TestClass]
    public class FavoritosTestes
    {


        private static string caminhoValido;
        private TestContext testContextInstance;

        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [ClassInitialize()]
        public static void Inicializar(TestContext a)
        {
            caminhoValido = System.IO.Path.Combine(Environment.CurrentDirectory, "favoritosTestes.json");

            if (System.IO.File.Exists(caminhoValido))
            {
                System.IO.File.Delete(caminhoValido);
            }

        }

        [TestMethod]
        [ExpectedException(typeof(NullReferenceException))]
        public void QuandoInformadoArquivoInvalidoDeveOcorrerUmErro()
        {
            git.Favoritos repositorios = new git.Favoritos(null);
        }

        [TestMethod]
        [ExpectedException(typeof(System.IO.DirectoryNotFoundException))]
        public void QuandoInformadoArquivoComCaminhoInvalidoDeveOcorrerUmErro()
        {
            git.Favoritos repositorios = new git.Favoritos(@"c:\-rre+=\iv\");

        }
        
        [TestMethod]
        public void SucessoAoIncluirUmNovoFavorito()
        {
            Favoritos favorito = new Favoritos()
            {
                id = 1,
                repositorio = "cde",
                usuario = "lganet"
            };

            git.Favoritos favoritos = new git.Favoritos(caminhoValido);
            favoritos.Adicionar(favorito);

            Assert.IsTrue(favoritos.EstaNoFavoritos(1L));

        }

        [TestMethod]
        public void SucessoAoCarregarListaDeFavoritos()
        {
            Favoritos favorito = new Favoritos()
            {
                id = 1,
                repositorio = "cde",
                usuario = "lganet"
            };

            git.Favoritos favoritos = new git.Favoritos(caminhoValido);
            favoritos.Adicionar(favorito);

            Assert.IsTrue(favoritos.EstaNoFavoritos(1L));

            var listaFavoritos = favoritos.Listar();

            Assert.IsTrue(listaFavoritos.Count > 0);
        }

        [TestMethod]
        public void SucessoAoRemoverUmFavorito()
        {
            Favoritos favorito = new Favoritos()
            {
                id = 1,
                repositorio = "cde",
                usuario = "lganet"
            };
            git.Favoritos favoritos = new git.Favoritos(caminhoValido);

            favoritos.Adicionar(favorito);

            Assert.IsTrue(favoritos.EstaNoFavoritos(1L));

            favoritos.Remover(favorito);

            Assert.IsFalse(favoritos.EstaNoFavoritos(1L));
        }



    }
}
