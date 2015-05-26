﻿using System.Web.Http;
using Microsoft.Owin.Security.OAuth;
using Microsoft.Practices.Unity;
using DAL.Repository.Abstract;
using DAL.Repository.Concrete;
using WebUI.Infrastructure;
using WebUI.Mappers;
using System.Collections.Generic;
using DAL.Models;
using WebUI.Models;

namespace WebUI
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API configuration and services
            // Configure Web API to use only bearer token authentication.
            config.SuppressDefaultHostAuthentication();
            config.Filters.Add(new HostAuthenticationFilter(OAuthDefaults.AuthenticationType));

            // Web API routes
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            var container = new UnityContainer();
            container.RegisterType<IVideoRepository, VideoRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IUserRepository, UserRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<ICommentRepository, CommentRepository>(new HierarchicalLifetimeManager());
            container.RegisterType<IMapToNew<IEnumerable<Video>, IEnumerable<VideoViewModelPreview>>, VideoViewModelMapper>(new HierarchicalLifetimeManager());
            
            config.DependencyResolver = new UnityResolver(container);

        }
    }
}
