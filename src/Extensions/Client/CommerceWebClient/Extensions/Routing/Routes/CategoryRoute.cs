﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Routing;
using VirtoCommerce.Client;
using VirtoCommerce.Foundation.AppConfig.Model;
using VirtoCommerce.Foundation.Catalogs.Services;
using VirtoCommerce.Foundation.Stores.Model;
using VirtoCommerce.Web.Client.Helpers;

namespace VirtoCommerce.Web.Client.Extensions.Routing.Routes
{
    public class CategoryRoute : StoreRoute
    {
        public CategoryRoute(string url, IRouteHandler routeHandler)
            : base(url, routeHandler)
        {
        }

        public CategoryRoute(string url, RouteValueDictionary defaults, IRouteHandler routeHandler)
            : base(url, defaults, routeHandler)
        {
        }

        public CategoryRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, IRouteHandler routeHandler)
            : base(url, defaults, constraints, routeHandler)
        {
        }

        public CategoryRoute(string url, RouteValueDictionary defaults, RouteValueDictionary constraints, RouteValueDictionary dataTokens, IRouteHandler routeHandler)
            : base(url, defaults, constraints, dataTokens, routeHandler)
        {
        }

        public override RouteData GetRouteData(HttpContextBase httpContext)
        {
            var routeData = base.GetRouteData(httpContext);

            if (routeData != null)
            {
                if (!routeData.Values.ContainsKey(Constants.Category) || routeData.Values[Constants.Category] == null)
                {
                    routeData = null;
                }
                else
                {
                    var category = routeData.Values[Constants.Category].ToString();
                    routeData.Values[Constants.Category] = SettingsHelper.SeoDecode(category, SeoUrlKeywordTypes.Category,
                        routeData.Values.ContainsKey(Constants.Language) ? routeData.Values[Constants.Language] as string : null);
                }
            }

            return routeData;
        }

        public override VirtualPathData GetVirtualPath(RequestContext requestContext, RouteValueDictionary values)
        {

            if (values.ContainsKey(Constants.Category) && values[Constants.Category] != null)
            {
                var oldOutline = values[Constants.Category].ToString();

                var newOutline = ModifyCategoryPath(values);

                if (!string.IsNullOrEmpty(newOutline) &&
                    !newOutline.Equals(oldOutline, StringComparison.InvariantCultureIgnoreCase))
                {
                    values[Constants.Category] = newOutline;
                }
            }

            EncodeVirtualPath(requestContext, values, SeoUrlKeywordTypes.Category);
            return base.GetVirtualPath(requestContext, values);
        }

        /// <summary>
        /// Convert path to full category path
        /// </summary>
        /// <param name="values">The route values.</param>
        /// <returns></returns>
        protected virtual string ModifyCategoryPath(RouteValueDictionary values)
        {
            var currentPath = values[Constants.Category].ToString();

            if (string.IsNullOrEmpty(currentPath))
                return null;

            var childCategryEncoded = currentPath.Split(new[] { '/' }, StringSplitOptions.RemoveEmptyEntries).Last();

            if (string.IsNullOrEmpty(childCategryEncoded))
                return null;

            var childCategryCode = SettingsHelper.SeoDecode(childCategryEncoded, SeoUrlKeywordTypes.Category, 
                values.ContainsKey(Constants.Language) ? values[Constants.Language] as string : null);
            var outline =
                new BrowsingOutline(
                    CartHelper.CatalogOutlineBuilder.BuildCategoryOutline(
                        StoreHelper.CustomerSession.CatalogId,
                        CartHelper.CatalogClient.GetCategory(childCategryCode)));

            return outline.ToString();
        }


        public override string GetMainRouteKey()
        {
            return Constants.Category;
        }

    }
}
