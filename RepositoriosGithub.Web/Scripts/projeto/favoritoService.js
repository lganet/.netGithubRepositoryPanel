"use strict";

angular.module('repositorioGithub').factory('favoritoService', function (config, $http) {

    var _adicionar = function (favorito) {
        return $http.post('Favorito/Adicionar', favorito);
    };

    var _remover = function (favorito) {
        return $http.delete('Favorito/Remover/' + favorito.id, { data: favorito });
    };

    return {
        adicionar: _adicionar,
        remover: _remover
    };
});