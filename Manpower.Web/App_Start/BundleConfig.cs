using System.Web;
using System.Web.Optimization;

namespace Manpower.Web.App_Start
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
               "~/Scripts/vendors/modernizr.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendors").Include(
                "~/Scripts/vendors/jquery.easing.min.js",
                "~/Scripts/vendors/bootstrap.min.js",
                "~/Scripts/vendors/toastr.js",
                "~/Scripts/vendors/jquery-1.9.1.min.js",
                "~/Scripts/vendors/respond.src.js",
                "~/Scripts/vendors/angular.js",
                "~/Scripts/vendors/angular-route.js",
                "~/Scripts/vendors/angular-animate.js",
                "~/Scripts/vendors/angular-cookies.js",
                "~/Scripts/vendors/angular-validator.js",
                "~/Scripts/vendors/angular-base64.js",
                "~/Scripts/vendors/angular-file-upload.js",
                "~/Scripts/vendors/angucomplete-alt.min.js",
                "~/Scripts/vendors/angular-scrollable-table.min.js",
                "~/Scripts/vendors/angular-scroll-table.min.js",
              "~/Scripts/spa/layout/customPager.directive.js",
                "~/Scripts/vendors/underscore.js",
                "~/Scripts/vendors/raphael.js",
                "~/Scripts/vendors/morris.js",
                "~/Scripts/vendors/scrolling-nav.js",
                "~/Scripts/vendors/modernizr-2.6.2-respond-1.1.0.min.js",

                "~/Scripts/vendors/loading-bar.js",
                "~/Scripts/vendors/superfish.js",
                "~/Scripts/vendors/common.js",                 
                "~/Scripts/vendors/angular-sanitize.js",
               
                "~/Scripts/vendors/script.js"
                
                ));

            bundles.Add(new ScriptBundle("~/bundles/spa").Include(
                "~/Scripts/spa/modules/common.core.js",
                "~/Scripts/spa/modules/common.ui.js",
                "~/Scripts/spa/app.js",
                "~/Scripts/spa/services/apiService.js",
                "~/Scripts/spa/services/notificationService.js",
                "~/Scripts/spa/services/mySharedService.js",
                "~/Scripts/spa/services/membershipService.js",
                "~/Scripts/spa/layout/topBar.directive.js",
                "~/Scripts/spa/layout/floatingLabel.directive.js",
                "~/Scripts/spa/layout/footBar.directive.js",
                "~/Scripts/spa/layout/customPager.directive.js",
                   "~/Scripts/spa/layout/dataDetails.directive.js",
                 "~/Scripts/spa/data/dataCtrl.js",
                  "~/Scripts/spa/data/dataAddCtrl.js",
                "~/Scripts/spa/account/loginCtrl.js",
                "~/Scripts/spa/account/registerCtrl.js",
                "~/Scripts/spa/home/indexCtrl.js",
                "~/Scripts/spa/about/aboutCtrl.js",
                 "~/Scripts/spa/service/servicesCtrl.js",
                 "~/Scripts/spa/service/contactCtrl.js",
                "~/Scripts/spa/home/rootCtrl.js",    
                "~/Scripts/spa/admin/userCtrl.js",
                "~/Scripts/spa/admin/userAddCtrl.js",
                "~/Scripts/spa/admin/userDetailsCtrl.js",
                "~/Scripts/spa/admin/userEditCtrl.js"
           
                
                ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/content/css/bootstrap.css",
                 "~/content/css/toastr.css",
                "~/content/css/custom.css",
                 "~/content/css/font-awesome.min.css",
                "~/content/css/main.css",
                 "~/content/css/icomoon-social.css"
                 ));

            BundleTable.EnableOptimizations = false;
        }
    }
}
