﻿using System;
using System.Web;
using System.Web.Mvc;
using VirtoCommerce.Client;
using VirtoCommerce.Foundation.Frameworks;
using VirtoCommerce.Foundation.Frameworks.Tagging;
using VirtoCommerce.Foundation.Customers;
using VirtoCommerce.Web.Client.Helpers;


namespace VirtoCommerce.Web.Client.Modules
{
    /// <summary>
    /// Class MarketingHttpModule.
    /// </summary>
    public class MarketingHttpModule : BaseHttpModule
    {
        /// <summary>
        /// The referral l_ cookie
        /// </summary>
        private const string ReferralCookie = "vcf.referral";

        /// <summary>
        /// You will need to configure this module in the Web.config file of your
        /// web and register it with IIS before being able to use it. For more information
        /// see the following link: http://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public override void Dispose()
        {
            //clean-up code here.
        }

        /// <summary>
        /// Initializes a module and prepares it to handle requests.
        /// </summary>
        /// <param name="context">An <see cref="T:System.Web.HttpApplication" /> that provides access to the methods, properties, and events common to all application objects within an ASP.NET application</param>
        public override void Init(HttpApplication context)
        {
            context.PostAcquireRequestState += context_PostAcquireRequestState;
        }


        /// <summary>
        /// Handles the PostAcquireRequestState event of the context control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        void context_PostAcquireRequestState(object sender, EventArgs e)
        {
            if (IsResourceFile())
                return;

            var application = (HttpApplication)sender;
            var context = application.Context;

            var session = CustomerSession;
            Populate(context, session);

            //Price list can only be evaluated after all customer tagsets are ready
            var priceListHelper = DependencyResolver.Current.GetService<PriceListClient>();
            var priceLists = priceListHelper.GetPriceListStack(session.CatalogId, session.Currency, session.GetCustomerTagSet());
            session.Pricelists = priceLists;
           

        }
        #endregion

        #region Helper Methods

        /// <summary>
        /// Populates the specified context.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="session">The session.</param>
        private void Populate(HttpContext context, ICustomerSession session)
        {
            var set = session.GetCustomerTagSet();

            //Category
            set.Add(ContextFieldConstants.CategoryId, new Tag(session.CategoryId));

            //Profile
            var customer = StoreHelper.UserClient.GetCurrentCustomer();
            if (customer != null)
            {
                if (customer.BirthDate.HasValue)
                {
                    set.Add(ContextFieldConstants.UserAge, new Tag(GetAge(customer.BirthDate.Value)));
                }
            }
    
            PopulateBrowserBehavior(context, session);
            PopulateShoppingCart(context, session);
            PopulateGEOLocation(context, session);
        }

        /// <summary>
        /// Populates the geo location.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="session">The session.</param>
        private void PopulateGEOLocation(HttpContext context, ICustomerSession session)
        {
            //TODO: populate geo location information
            var set = session.GetCustomerTagSet();
            
        }

        /// <summary>
        /// Populates the shopping cart.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="session">The session.</param>
        private void PopulateShoppingCart(HttpContext context, ICustomerSession session)
        {
            var set = session.GetCustomerTagSet();

            // cart total
            var helper = new CartHelper(CartHelper.CartName);
            if (!helper.IsEmpty)
            {
                set.Add(ContextFieldConstants.CartTotal, new Tag(helper.Cart.Total));
                if (context.Session != null)
                {
                    session.CouponCode = (string)context.Session["CurrentCouponCode"];
                }
            }
        }

        /// <summary>
        /// Populates the browser behavior.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <param name="session">The session.</param>
        private void PopulateBrowserBehavior(HttpContext context, ICustomerSession session)
        {
            var set = session.GetCustomerTagSet();

            // search
            var search = context.Request["q"];
            if (!String.IsNullOrEmpty(search))
            {
                set.Add(ContextFieldConstants.StoreSearchPhrase, new Tag(search));
            }

            // store id
            if (!String.IsNullOrEmpty(session.StoreId))
            {
                set.Add(ContextFieldConstants.StoreId, new Tag(session.StoreId));
            }

            // current URL
            set.Add(ContextFieldConstants.CurrentUrl, new Tag(context.Request.Url.AbsoluteUri));

            // referral
            var referral = GetReferralUrl(context);
            if (!String.IsNullOrEmpty(referral))
            {
                set.Add(ContextFieldConstants.ReferredUrl, new Tag(referral));

                var keywords = GetKeywords(referral);

                if (!String.IsNullOrEmpty(keywords))
                {
                    set.Add(ContextFieldConstants.InternetSearchPhrase, new Tag(keywords));
                }
            }
        }

        /// <summary>
        /// Gets the referral URL.
        /// </summary>
        /// <param name="context">The context.</param>
        /// <returns>System.String.</returns>
        private string GetReferralUrl(HttpContext context)
        {
            var referral = context.Request.UrlReferrer;

            if (referral != null)
            {
                bool isLocal = referral.Host.Equals(context.Request.Url.Host, StringComparison.OrdinalIgnoreCase);

                if (!isLocal)
                {
                    // save value in the cookie
                    StoreHelper.SetCookie(ReferralCookie, referral.AbsoluteUri, DateTime.Now.AddDays(1));

                    return referral.AbsoluteUri;
                }
            }

            // now try getting it from cookie
            var url = StoreHelper.GetCookieValue(ReferralCookie);
            if (!String.IsNullOrEmpty(url))
            {
                return url;
            }

            return null;
        }

        /// <summary>
        /// Gets the age.
        /// </summary>
        /// <param name="birthday">The birthday.</param>
        /// <returns>System.Int32.</returns>
        private int GetAge(DateTime birthday)
        {
            var now = DateTime.Today;
            var age = now.Year - birthday.Year;
            if (now < birthday.AddYears(age)) age--;
            return age;
        }

        /// <summary>
        /// Gets the keywords.
        /// </summary>
        /// <param name="urlReferrer">The URL referrer.</param>
        /// <returns>System.String.</returns>
        private string GetKeywords(string urlReferrer)
        {
            string searchQuery;
            var url = new Uri(urlReferrer);
            var query = HttpUtility.ParseQueryString(urlReferrer);
            switch (url.Host)
            {
                case "google":
                case "daum":
                case "msn":
                case "bing":
                case "ask":
                case "altavista":
                case "alltheweb":
                case "live":
                case "najdi":
                case "aol":
                case "seznam":
                case "search":
                case "szukacz":
                case "pchome":
                case "kvasir":
                case "sesam":
                case "ozu":
                case "mynet":
                case "ekolay":
                    searchQuery = query["q"];
                    break;
                case "naver":
                case "netscape":
                case "mama":
                case "mamma":
                case "terra":
                case "cnn":
                    searchQuery = query["query"];
                    break;
                case "virgilio":
                case "alice":
                    searchQuery = query["qs"];
                    break;
                case "yahoo":
                    searchQuery = query["p"];
                    break;
                case "onet":
                    searchQuery = query["qt"];
                    break;
                case "eniro":
                    searchQuery = query["search_word"];
                    break;
                case "about":
                    searchQuery = query["terms"];
                    break;
                case "voila":
                    searchQuery = query["rdata"];
                    break;
                case "baidu":
                    searchQuery = query["wd"];
                    break;
                case "yandex":
                    searchQuery = query["text"];
                    break;
                case "szukaj":
                    searchQuery = query["wp"];
                    break;
                case "yam":
                    searchQuery = query["k"];
                    break;
                case "rambler":
                    searchQuery = query["words"];
                    break;
                default:
                    searchQuery = query["q"];
                    break;
            }
            return searchQuery;
        }
        #endregion
    }
}
