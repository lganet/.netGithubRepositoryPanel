"use strict";

angular.module('repositorioGithub').controller('pesquisaCtrl', function ($scope, $location, config, utilService) {
     
    $scope.ExibirResultadoPesquisa = "/Home/ExibirTelaPesquisaNaoFeita";

    $scope.Pesquisar = function (pagina, keyEvent) {

        if (keyEvent) {
            if (keyEvent.which !== 13) {
                return;
            }
        }

        if (!pagina) {
            pagina = 1;
        }
        //$scope.ExibirResultadoPesquisa = "";
        //$scope.ExibirResultadoPesquisa = "/Home/ExibirResultadoPesquisa?repositorio=" + $scope.Repositorio + "&paginaAtual=" + $scope.PaginaAtual;
        $location.path("/Pesquisar/" + $scope.Repositorio + "/" + pagina);
    }
    $scope.ExibirNumerica = false;

    $scope.MostrarNumerica = function () {
        console.log("Mostrar númerica.");
        $scope.ExibirNumerica = !$scope.ExibirNumerica;
    }

    $scope.ExibirDetalhes = function (usuario, repositorio) {

        utilService.Redirecionar("/Detalhes/" + usuario + "/" + repositorio);
    }

});
