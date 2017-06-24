using System.Web;
using System.Web.Optimization;

namespace RepositoriosGithub.Web
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
               
            bundles.Add(new ScriptBundle("~/bundles/terceiros").Include(
                        "~/Scripts/sweetalert.js",
                        "~/Scripts/angular.js",
                        "~/Scripts/angular-route.js",
                        "~/Scripts/angular-ui/ui-bootstrap-tpls.js",
                        "~/Scripts/i18n/angular-locale_pt-br.js",
                        "~/Scripts/pace.js",
                        "~/Scripts/ngSweetAlert/ngSweetAlert.js"));

            bundles.Add(new ScriptBundle("~/bundles/projeto").Include(
                "~/Scripts/projeto/app.js",
                "~/Scripts/projeto/routerConfig.js",
                "~/Scripts/projeto/utilService.js",
                "~/Scripts/projeto/headerCtrl.js",
                "~/Scripts/projeto/config.js",
                "~/Scripts/projeto/pesquisaCtrl.js",
                "~/Scripts/projeto/repositoriosCtrl.js",
                "~/Scripts/projeto/detalhesRepositorioCtrl.js",
                "~/Scripts/projeto/favoritoService.js",
                "~/Scripts/projeto/favoritoCtrl.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.css",
                "~/Content/pace/themes/red/pace-theme-corner-indicator.css",
                "~/Content/projeto/app.css",
                "~/Content/sweetalert/sweetalert.css"
                ));

        }
    }
}