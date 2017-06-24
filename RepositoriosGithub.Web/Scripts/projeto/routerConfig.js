"use strict";

angular.module('repositorioGithub').config(['$routeProvider', '$locationProvider',
  function ($routeProvider, $locationProvider, viewService) {
      $routeProvider.
        when('/', {
            templateUrl: 'Home/Welcome',
            resolve: {
                trocaTitulo: function () {
                    document.title = 'Reposit' + '\u00F3' + 'rio Github - Bem-vindo';
                }
            }
        }).
        when('/MeusRepositorios', {
            templateUrl: function (params) {
                return 'Repositorio/MeusRepositorios';
            },
            resolve: {
                trocaTitulo: function () {
                    document.title = 'Reposit' + '\u00F3' + 'rio Github - Meus Reposi' + '\u00F3' + 'rios';
                }
            }
        }).
        when('/Pesquisar', {
            templateUrl: 'Repositorio/PesquisarRepositorios?termoPesquisado=&pagina=',
            resolve: {
                trocaTitulo: function () {
                    document.title = 'Reposit' + '\u00F3' + 'rio Github - Pesquisa';
                }
            }
        }).
        when('/Pesquisar/:termo/:pagina', {
            templateUrl: function (params) {
                return 'Repositorio/PesquisarRepositorios?termoPesquisado=' + params.termo + '&pagina=' + params.pagina;
            },
            resolve: {
                trocaTitulo: function () {
                    document.title = 'Reposit' + '\u00F3' + 'rio Github - Pesquisa';
                }
            }
        }).
        when('/Detalhes/:usuario/:repositorio', {
            templateUrl: function (params) {
                return 'Repositorio/DetalhesRepositorio?usuario=' + params.usuario + '&repositorio=' + params.repositorio;
            },
            resolve: {
                trocaTitulo: function () {
                    document.title = 'Reposit' + '\u00F3' + 'rio Github - Detalhes Repososit' + '\u00F3' + 'rio';
                }
            }

        }).
        when('/Favoritos', {
            templateUrl: 'Favorito/Listar',
            resolve: {
                trocaTitulo: function () {
                    document.title = 'Reposit' + '\u00F3' + 'rio Github - Favoritos';
                }
            }
        }).

        otherwise({
            redirectTo: '/'
        });


      $locationProvider.html5Mode(true);
      $locationProvider.hashPrefix('!');
  }]);