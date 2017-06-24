"use strict";

angular.module("repositorioGithub").provider("utilService", function () {

    this.$get = function ($window, SweetAlert, config, $location, $rootScope) {
        return {
            ViewCorrenteEh: function (view) {
                var url = $location.path();
                var parametros = url.indexOf("?");

                if (parametros >= 0) {
                    url = url.substring(0, parametros);
                }

                return (url.indexOf(view) > 0);
            },
            Redirecionar: function (url) {
                $location.path(url);
                // $rootScope.$apply();
                return true;
            },
            RedirecionarComReload: function (url) {
                $window.location.href = url;
            },
            MensagemPadrao: function (parametros) {
                SweetAlert.swal(
					{
					    title: parametros.titulo,
					    text: parametros.mensagem,
					    type: parametros.tipo,
					    confirmButtonText: "OK",
					    closeOnConfirm: true
					}
				);
            },
            Mensagem: function (mensagem) {
                this.MensagemPadrao({
                    titulo: "Unidade Centralizadora",
                    mensagem: mensagem,
                    tipo: config.tiposMensagem.informacao
                });
            },
            MensagemErro: function (titulo, mensagem) {
                this.MensagemPadrao({
                    titulo: titulo,
                    mensagem: mensagem,
                    tipo: config.tiposMensagem.erro
                });
            },
            MensagemSucesso: function (titulo, mensagem) {
                this.MensagemPadrao({
                    titulo: titulo,
                    mensagem: mensagem,
                    tipo: config.tiposMensagem.sucesso
                });
            },
            MensagemConfirmacao: function (parametros) {
                SweetAlert.swal(
					{
					    title: parametros.titulo,
					    text: parametros.mensagem,
					    type: parametros.tipo,
					    showCancelButton: true,
					    cancelButtonText: "Cancelar",
					    confirmButtonColor: "#DD6B55",
					    confirmButtonText: "Sim",
					    closeOnConfirm: (parametros.fecharNoConfirmar !== null ? parametros.fecharNoConfirmar : false)
					},
					function (isConfirm) {
					    if (isConfirm) {
					        parametros.confirmacao();
					    }
					}
				);
            }
        };
    };
});