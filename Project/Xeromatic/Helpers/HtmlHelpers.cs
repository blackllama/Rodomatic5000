using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace Xeromatic.Helpers 
{
    public static class HtmlHelpers 
    {
        /// <summary>
        /// Helper method to serialise a Json object. Unlike HtmlHelperExtensions.JsonNetEncode, this returns a string
        /// that will automatically be encoded by the Razor template.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="U"></typeparam>
        /// <param name="helper"></param>
        /// <param name="objectsToEncode"></param>
        /// <returns></returns>
        public static string Serialize<T, U>(this HtmlHelper<T> helper, U objectsToEncode) 
        {
            return JsonConvert.SerializeObject(objectsToEncode, Formatting.Indented, new JavaScriptDateTimeConverter(),
                                               new StringEnumConverter());
        }
    }
}