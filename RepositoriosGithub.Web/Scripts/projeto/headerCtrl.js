"use strict";

angular.module('repositorioGithub').controller('headerCtrl', function ($scope, $location, config, utilService) {

    $scope.EhAtual = function (view) {
        return utilService.ViewCorrenteEh(view);
    }

    $scope.Home = function () {
        utilService.Redirecionar("/");
    };

    $scope.ExibirMeusRepositorios = function () {
        utilService.Redirecionar("/MeusRepositorios/");
    };

    $scope.PesquisaRepositorios = function () {
        utilService.Redirecionar("/Pesquisar/");
    };

    $scope.Favoritos = function () {
        utilService.Redirecionar("/Favoritos/");
    };

});
