using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace TheGameShop.Mobile.Constants
{
    public static class BackendConstants
    {
#if DEBUG
        public static string GraphQLApiUrl { get; } = Device.RuntimePlatform is Device.Android ? "http://10.0.2.2:5001/" : "http://localhost:5001/";
#else
#error Missing GraphQL Api Url
        public static string GraphQLApiUrl { get; } = "";
#endif
    }
}