"use strict";

angular.module('repositorioGithub').controller('detalhesRepositorioCtrl', function ($scope, $location, config, favoritoService, utilService) {

    $scope.Favorito = false;

    $scope.LabelFavoritos = function () {
        return !$scope.Favorito ? 'Adicionar ao Favoritos' : 'Remover do Favoritos';
    };

    $scope.ExibirResultadoPesquisa = "/Repositorio/ExibirTelaPesquisaNaoFeita";

    $scope.AdcionarAoFavoritos = function (usuario, repositorio, id) {
        var favorito = {'usuario': usuario, 'repositorio': repositorio, 'id': id};

        if (!$scope.Favorito) {
            _adicionar(favorito);
        } else {
            
            utilService.MensagemConfirmacao(
				{
				    titulo: "Favoritos",
				    mensagem: "Deseja remover o repositório dos favoritos?",
				    tipo: config.tiposMensagem.informacao,
				    fecharNoConfirmar: false,
				    confirmacao: function () {
				        _remover(favorito);
				        
				    }
				}
			);
        }
    };

    function _adicionar(favorito) {
        favoritoService.adicionar(favorito).success(function (dados) {
            if (dados.sucesso === true) {
                utilService.MensagemSucesso('Adicionado ao favoritos com sucesso.');
                $scope.Favorito = true;
            }
        }).error(function (erro, status) {
            if (erro === null) {
                utilService.MensagemErro('Problemas ao tentar adicionar favoritos.');
            } else {
                utilService.MensagemErro(erro.mensagem); 
            }
        });
    };

    function _remover(favorito) {
        favoritoService.remover(favorito).success(function (dados) {
            if (dados.sucesso === true) {
                utilService.MensagemSucesso('Removido dos favoritos com sucesso.');
                $scope.Favorito = false;
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
