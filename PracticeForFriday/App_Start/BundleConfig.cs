using System.Web;
using System.Web.Optimization;

namespace PracticeForFriday
{
	public class BundleConfig
	{
		// For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
		public static void RegisterBundles(BundleCollection bundles)
		{
			bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
						"~/Scripts/jquery-{version}.js"));
			bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
						"~/Scripts/jquery.validate*"));
			bundles.Add(new ScriptBundle("~/bundles/angularjs").Include(
						"~/Script/angular.js"));
			bundles.Add(new ScriptBundle("~/bundles/angularMaterial").Include(
						"~/Script/angular-material.js"));
			bundles.Add(new ScriptBundle("~/bundles/angularAria").Include(
						"~/Script/angular-aria.js"));
			bundles.Add(new ScriptBundle("~/bundles/angularAnim").Include(
						"~/Script/angular-animate.js"));
			bundles.Add(new ScriptBundle("~/bundles/navbar").Include("~/Script/Navbarjs.js"));

			// Use the development version of Modernizr to develop with and learn from. Then, when you're
			// ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
			bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
						"~/Scripts/modernizr-*"));

			bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
					  "~/Scripts/bootstrap.js",
					  "~/Scripts/respond.js"));

			bundles.Add(new StyleBundle("~/Content/css").Include(
					  "~/Content/bootstrap.css",
					  "~/Content/site.css"));

			bundles.Add(new StyleBundle("~/Content/materialcss").Include(
					  "~/Content/angular-material.css"));
		}
	}
}
