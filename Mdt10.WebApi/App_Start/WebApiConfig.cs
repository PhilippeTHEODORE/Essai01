using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Net.Http;
using System.Web.Http.WebHost;

namespace Mdt10.WebApi
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {

            config.Routes.MapHttpRoute(
                name: "GrilleGenerale",
                routeTemplate: "api/avion/grille/{cle}",
                defaults: new { cle = RouteParameter.Optional, controller = "Livre", action = "GrilleGenerale" }
            );

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{action}/{id}",
                    defaults: new
                    {
                        id = RouteParameter.Optional,
                        action = "GetIndex"
                    }
         );


            //config.Routes.MapHttpRoute(
            //    name: "GrilleGenerale",
            //    routeTemplate: "api/Livre/grille",
            //    defaults: new {  controller="Livre",
            //        action = "GrilleGenerale" }
            //);
            //config.Routes.MapHttpRoute(
            //    name: "GrilleGenerale",
            //    routeTemplate: "api/{controller}/grille/"
            //    );

            //config.Routes.MapHttpRoute(
            //    name: "DefaultApi2",
            //    routeTemplate: "api/{controller}/{id}",
            //    defaults: new { id = RouteParameter.Optional }
            //);

            //config.Routes.MapHttpRoute(
            //    name: "ServerDataByIP",
            //    routeTemplate: "api/{controller}/ip/{ip}"
            //);

            //config.Routes.MapHttpRoute(
            //    name: "ServerDataByIP1",
            //    routeTemplate: "api/{controller}/ip1/{ip1}"
            //);

            // Supprimez les commentaires de la ligne de code suivante pour activer la prise en charge des requêtes pour les actions ayant un type de retour IQueryable ou IQueryable<T>.
            // Pour éviter le traitement de requêtes inattendues ou malveillantes, utilisez les paramètres de validation définis sur QueryableAttribute pour valider les requêtes entrantes.
            // Pour plus d’informations, visitez http://go.microsoft.com/fwlink/?LinkId=279712.
            // config.EnableQuerySupport();

            // Pour désactiver le suivi dans votre application, supprimez le commentaire de la ligne de code suivante ou supprimez cette dernière
            //Pour plus d’informations, consultez la page : http://www.asp.net/web-api
            // config.EnableSystemDiagnosticsTracing();


        }
    }
}
