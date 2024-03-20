using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;

namespace API
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            try
            {
              

              
                config.Routes.MapHttpRoute(
                    name: "honeycombApi",
                    routeTemplate: "api/honeycomb",
                    defaults: new { controller = "Honeycomb" }
                );
            
            
            config.EnableCors();
                config.Formatters.XmlFormatter.SupportedMediaTypes.Add(new System.Net.Http.Headers.MediaTypeHeaderValue("multipart/form-data"));
                config.Routes.MapHttpRoute(name: "addressbookFilterSelect", routeTemplate: "api/addressbookFilterSelect/{id}", defaults: new
                {
                controller = "addressbookFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "benefitsFilterSelect", routeTemplate: "api/benefitsFilterSelect/{id}", defaults: new
                {
                controller = "benefitsFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "documentsFilterSelect", routeTemplate: "api/documentsFilterSelect/{id}", defaults: new
                {
                controller = "documentsFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "friendsreferredFilterSelect", routeTemplate: "api/friendsreferredFilterSelect/{id}", defaults: new
                {
                controller = "friendsreferredFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "loyaltyFilterSelect", routeTemplate: "api/loyaltyFilterSelect/{id}", defaults: new
                {
                controller = "loyaltyFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "paymentlinkFilterSelect", routeTemplate: "api/paymentlinkFilterSelect/{id}", defaults: new
                {
                controller = "paymentlinkFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "registrationFilterSelect", routeTemplate: "api/registrationFilterSelect/{id}", defaults: new
                {
                controller = "registrationFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "useremploymentFilterSelect", routeTemplate: "api/useremploymentFilterSelect/{id}", defaults: new
                {
                controller = "useremploymentFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "walletFilterSelect", routeTemplate: "api/walletFilterSelect/{id}", defaults: new
                {
                controller = "walletFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "wallettransactionFilterSelect", routeTemplate: "api/wallettransactionFilterSelect/{id}", defaults: new
                {
                controller = "wallettransactionFilterSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "addressbookSelect", routeTemplate: "api/addressbookSelect/{id}", defaults: new
                {
                controller = "addressbookSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "benefitsSelect", routeTemplate: "api/benefitsSelect/{id}", defaults: new
                {
                controller = "benefitsSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "documentsSelect", routeTemplate: "api/documentsSelect/{id}", defaults: new
                {
                controller = "documentsSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "friendsreferredSelect", routeTemplate: "api/friendsreferredSelect/{id}", defaults: new
                {
                controller = "friendsreferredSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "loyaltySelect", routeTemplate: "api/loyaltySelect/{id}", defaults: new
                {
                controller = "loyaltySelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "paymentlinkSelect", routeTemplate: "api/paymentlinkSelect/{id}", defaults: new
                {
                controller = "paymentlinkSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "registrationSelect", routeTemplate: "api/registrationSelect/{id}", defaults: new
                {
                controller = "registrationSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "useremploymentSelect", routeTemplate: "api/useremploymentSelect/{id}", defaults: new
                {
                controller = "useremploymentSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "walletSelect", routeTemplate: "api/walletSelect/{id}", defaults: new
                {
                controller = "walletSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "wallettransactionSelect", routeTemplate: "api/wallettransactionSelect/{id}", defaults: new
                {
                controller = "wallettransactionSelect", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "addressbookUpdate", routeTemplate: "api/addressbookUpdate/{id}", defaults: new
                {
                controller = "addressbookUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "benefitsUpdate", routeTemplate: "api/benefitsUpdate/{id}", defaults: new
                {
                controller = "benefitsUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "documentsUpdate", routeTemplate: "api/documentsUpdate/{id}", defaults: new
                {
                controller = "documentsUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "friendsreferredUpdate", routeTemplate: "api/friendsreferredUpdate/{id}", defaults: new
                {
                controller = "friendsreferredUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "loyaltyUpdate", routeTemplate: "api/loyaltyUpdate/{id}", defaults: new
                {
                controller = "loyaltyUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "paymentlinkUpdate", routeTemplate: "api/paymentlinkUpdate/{id}", defaults: new
                {
                controller = "paymentlinkUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "registrationUpdate", routeTemplate: "api/registrationUpdate/{id}", defaults: new
                {
                controller = "registrationUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "useremploymentUpdate", routeTemplate: "api/useremploymentUpdate/{id}", defaults: new
                {
                controller = "useremploymentUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "walletUpdate", routeTemplate: "api/walletUpdate/{id}", defaults: new
                {
                controller = "walletUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "wallettransactionUpdate", routeTemplate: "api/wallettransactionUpdate/{id}", defaults: new
                {
                controller = "wallettransactionUpdate", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "addressbookInsert", routeTemplate: "api/addressbookInsert/{id}", defaults: new
                {
                controller = "addressbookInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "benefitsInsert", routeTemplate: "api/benefitsInsert/{id}", defaults: new
                {
                controller = "benefitsInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "documentsInsert", routeTemplate: "api/documentsInsert/{id}", defaults: new
                {
                controller = "documentsInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "friendsreferredInsert", routeTemplate: "api/friendsreferredInsert/{id}", defaults: new
                {
                controller = "friendsreferredInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "loyaltyInsert", routeTemplate: "api/loyaltyInsert/{id}", defaults: new
                {
                controller = "loyaltyInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "paymentlinkInsert", routeTemplate: "api/paymentlinkInsert/{id}", defaults: new
                {
                controller = "paymentlinkInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "registrationInsert", routeTemplate: "api/registrationInsert/{id}", defaults: new
                {
                controller = "registrationInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "useremploymentInsert", routeTemplate: "api/useremploymentInsert/{id}", defaults: new
                {
                controller = "useremploymentInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "walletInsert", routeTemplate: "api/walletInsert/{id}", defaults: new
                {
                controller = "walletInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "wallettransactionInsert", routeTemplate: "api/wallettransactionInsert/{id}", defaults: new
                {
                controller = "wallettransactionInsert", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "addressbookDelete", routeTemplate: "api/addressbookDelete/{id}", defaults: new
                {
                controller = "addressbookDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "benefitsDelete", routeTemplate: "api/benefitsDelete/{id}", defaults: new
                {
                controller = "benefitsDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "documentsDelete", routeTemplate: "api/documentsDelete/{id}", defaults: new
                {
                controller = "documentsDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "friendsreferredDelete", routeTemplate: "api/friendsreferredDelete/{id}", defaults: new
                {
                controller = "friendsreferredDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "loyaltyDelete", routeTemplate: "api/loyaltyDelete/{id}", defaults: new
                {
                controller = "loyaltyDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "paymentlinkDelete", routeTemplate: "api/paymentlinkDelete/{id}", defaults: new
                {
                controller = "paymentlinkDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "registrationDelete", routeTemplate: "api/registrationDelete/{id}", defaults: new
                {
                controller = "registrationDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "useremploymentDelete", routeTemplate: "api/useremploymentDelete/{id}", defaults: new
                {
                controller = "useremploymentDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "walletDelete", routeTemplate: "api/walletDelete/{id}", defaults: new
                {
                controller = "walletDelete", id = RouteParameter.Optional
                }

                );
                config.Routes.MapHttpRoute(name: "wallettransactionDelete", routeTemplate: "api/wallettransactionDelete/{id}", defaults: new
                {
                controller = "wallettransactionDelete", id = RouteParameter.Optional
                }

                );
            }
            catch (Exception ee)
            {
                string text = ee.ToString();
            }
        }
    }
}