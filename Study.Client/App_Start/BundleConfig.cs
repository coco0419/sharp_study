﻿using System.Web;
using System.Web.Optimization;

namespace Study.Client
{
    public class BundleConfig
    {
        // バンドルの詳細については、https://go.microsoft.com/fwlink/?LinkId=301862 を参照してください
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// 開発と学習には、Modernizr の開発バージョンを使用します。次に、実稼働の準備が
            //// 運用の準備が完了したら、https://modernizr.com のビルド ツールを使用し、必要なテストのみを選択します。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            //bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
            //          "~/Scripts/bootstrap.js"));

            //bundles.Add(new StyleBundle("~/Content/css").Include(
            //          "~/Content/bootstrap.css",
            //          "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/vue").Include("~/Scripts/vue.js", "~/Scripts/vue-resource.js"));
            bundles.Add(new ScriptBundle("~/bundles/js-cookie").Include("~/Scripts/js-cookie/js.cookie.js"));
            bundles.Add(new ScriptBundle("~/bundles/websocket").Include("~/Scripts/websocket.js"));
            bundles.Add(new ScriptBundle("~/bundles/home/index").Include("~/Scripts/Home/index.js"));
            bundles.Add(new ScriptBundle("~/bundles/signin/index").Include("~/Scripts/SignIn/index.js"));
        }
    }
}
