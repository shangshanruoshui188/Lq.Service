using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;
using Lq.Service.Controllers;
using Lq.Service.Models.Entity;

namespace Lq.Service.Extensions
{
    public class ControllerSelector: DefaultHttpControllerSelector
    {
        private readonly HttpConfiguration configuration;
        private Dictionary<string, Type> entityMap=BaseEntity.EntityMap;

        public ControllerSelector(HttpConfiguration configuration)
            : base(configuration)
        {
            this.configuration = configuration;

        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllerName = base.GetControllerName(request)??"";

            Type entityType = null;
            if (!entityMap.TryGetValue(controllerName.ToLower(), out entityType))
            {
                return base.SelectController(request);
            }

            return new HttpControllerDescriptor(configuration, controllerName, typeof(GenericController<>).MakeGenericType(entityType));
        }

    }
}