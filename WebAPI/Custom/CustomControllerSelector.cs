using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Dispatcher;

namespace WebAPI.Custom
{
    public class CustomControllerSelector : DefaultHttpControllerSelector
    {
        private HttpConfiguration _config;
        public CustomControllerSelector(HttpConfiguration config) : base(config)
        {
            _config = config;
        }

        public override HttpControllerDescriptor SelectController(HttpRequestMessage request)
        {
            var controllers = GetControllerMapping();
            var routeData = request.GetRouteData();

            var controllerName = routeData.Values["controller"].ToString();

            string versionNumber = "1";

            // Comment the code that gets the version number from Query String
            // var versionQueryString =
            //         HttpUtility.ParseQueryString(request.RequestUri.Query);
            //if (versionQueryString["v"] != null)
            //{
            //    versionNumber = versionQueryString["v"];
            //}

            // Get the version number from Custom version header

            //string customHeader = "X-StudentService-Version";
            //if (request.Headers.Contains(customHeader))
            //{
            //    // If X-StudentService-Version:1 is specified twice in the request
            //    // then in versionNumber variable will get a value of "1,1"
            //    versionNumber = request.Headers.GetValues(customHeader).FirstOrDefault();
            //    // Check if versionNumber string contains a comma, and take only
            //    // the first number from the comma separated list of version numbers
            //    if (versionNumber.Contains(","))
            //    {
            //        versionNumber = versionNumber.Substring(0, versionNumber.IndexOf(","));
            //    }
            //}

            // Get the version number from the Accept header

            // Users can include multiple Accept headers in the request
            // Check if any of the Accept headers has a parameter with name version
            //var acceptHeader = request.Headers.Accept.Where(a => a.Parameters
            //                    .Count(p => p.Name.ToLower() == "version") > 0);

            //// If there is atleast one header with a "version" parameter
            //if (acceptHeader.Any())
            //{
            //    // Get the version parameter value from the Accept header
            //    versionNumber = acceptHeader.First().Parameters
            //                    .First(p => p.Name.ToLower() == "version").Value;
            //}

            // Get the version number from the Custom media type

            // Use regular expression for mataching the pattern of the media
            // type. We have given a name for the matched group that contains
            // the version number. This enables us to retrieve the version number 
            // using the group name("version") instead of ZERO based index
            string regex =
                @"application\/vnd\.pragimtech\.([a-z]+)\.v(?<version>[0-9]+)\+([a-z]+)";

            // Users can include multiple Accept headers in the request.
            // Check if any of the Accept headers has our custom media type by
            // checking if there is a match with regular expression specified
            var acceptHeader = request.Headers.Accept
                .Where(a => Regex.IsMatch(a.MediaType, regex, RegexOptions.IgnoreCase));
            // If there is atleast one Accept header with our custom media type
            if (acceptHeader.Any())
            {
                // Retrieve the first custom media type
                var match = Regex.Match(acceptHeader.First().MediaType,
                    regex, RegexOptions.IgnoreCase);
                // From the version group, get the version number
                versionNumber = match.Groups["version"].Value;
            }

            HttpControllerDescriptor controllerDescriptor;
            if (versionNumber == "1")
            {
                controllerName = string.Concat(controllerName, "V1");
            }
            else
            {
                controllerName = string.Concat(controllerName, "V2");
            }

            if (controllers.TryGetValue(controllerName, out controllerDescriptor))
            {
                return controllerDescriptor;
            }

            return null;
        }
    }
}