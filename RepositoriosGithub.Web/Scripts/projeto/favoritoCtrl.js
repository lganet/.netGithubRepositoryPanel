"use strict";

angular.module('repositorioGithub').controller('favoritoCtrl', function ($scope, $location, $route, config, favoritoService, utilService) {

    $scope.ExibirDetalhes = function (usuario, repositorio) {
        utilService.Redirecionar("/Detalhes/" + usuario + "/" + repositorio);
    }
    
    $scope.RemoverFavorito = function (usuario, repositorio, id) {
        var favorito = { 'usuario': usuario, 'repositorio': repositorio, 'id': id };

        utilService.MensagemConfirmacao(               {
                   titulo: "Favoritos",
                   mensagem: "Deseja remover o repositório dos favoritos?",
                   tipo: config.tiposMensagem.informacao,
                   fecharNoConfirmar: false,
                   confirmacao: function () {
                       _remover(favorito);
                   }
               }
        );
    };

    function _remover(favorito) {
        favoritoService.remover(favorito).success(function (dados) {
            if (dados.sucesso === true) {
                utilService.MensagemSucesso('Removido do favoritos com sucesso.');
                $route.reload();
            }
        }).error(function (erro, status) {
            if (erro === null) {
                utilService.MensagemErro('Problemas ao remover dos favoritos.');
            } else {
                utilService.MensagemErro(erro.mensagem);
            }
        });
    };
});
