using System.Web;
using System.Web.Optimization;

namespace Diplom
{
    public class BundleConfig
    {
        // Дополнительные сведения об объединении см. на странице https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.unobtrusive-ajax.js",
                        "~/Content/assets/js/jquery.scrollTo.min.js",
                        "~/Content/assets/js/metisMenu.min.js",
                        "~/Content/assets/js/popper.min.js",
                        "~/Content/assets/js/wow.min.js",
                        "~/Content/assets/js/switchery.min.js",
                        "~/Content/assets/js/select2.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").IncludeDirectory(
                        "~/Content/assets/js", "*.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Используйте версию Modernizr для разработчиков, чтобы учиться работать. Когда вы будете готовы перейти к работе,
            // готово к выпуску, используйте средство сборки по адресу https://modernizr.com, чтобы выбрать только необходимые тесты.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Content/assets/js/modernizr.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.min.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/assets/css/select2.min.css",
                      "~/Content/assets/css/switchery.min.css",
                      "~/Content/assets/css/bootstrap.min.css",
                      "~/Content/assets/css/icons.css",
                      "~/Content/assets/css/style.css"));
        }
    }
}
