"use strict";

angular.module('repositorioGithub').controller('repositoriosCtrl', function ($scope, utilService) {

    $scope.ExibirDetalhes = function (usuario, repositorio) {

        utilService.Redirecionar("/Detalhes/" + usuario + "/" + repositorio);
    }
});
