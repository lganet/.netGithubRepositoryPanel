"use strict";
angular.module('repositorioGithub', ['ngRoute', 'oitozero.ngSweetAlert']).run(function ($rootScope, $templateCache) {
    $rootScope.$on('$viewContentLoaded', function () {
        $templateCache.removeAll();
    });
});