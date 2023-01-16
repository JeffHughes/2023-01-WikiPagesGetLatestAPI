using System.Net;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Azure.Functions.Worker.Http;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Attributes;
using Microsoft.Azure.WebJobs.Extensions.OpenApi.Core.Enums;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;

namespace WikiGetLatestChanges
{
    public class Function1
    {
        private readonly ILogger _logger;

        public Function1(ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<Function1>();
        }

        [OpenApiParameter(name: "user", In = ParameterLocation.Path, Required = true, Summary = "",
            Description = "text to linq", Type = typeof(string), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "links", In = ParameterLocation.Path, Required = true, Summary = "",
            Description = "true to return links to pages, false (default) to embed data from pages", Type = typeof(bool), Visibility = OpenApiVisibilityType.Important)]

        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<WikiPageApp.Model.WikiPageUpdate>), Description = "The OK response message containing a JSON result.")]
        [OpenApiOperation(operationId: "GetLatestWikiPageUpdates", tags: new[] { "wiki-page-update" })]

        [Function("GetLatest")]
        public HttpResponseData Run([HttpTrigger(AuthorizationLevel.Anonymous, "get",
            Route = "latest/{user}/{links}")] HttpRequestData req, string user, bool links)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");

            // getUserLastRead 
            
            // getWikiPageUpdates

            // writeUserLastRead
            
            response.WriteString("Welcome to Azure Functions!");


            
            return response;
        }


        [OpenApiParameter(name: "user", In = ParameterLocation.Path, Required = true, Summary = "",
            Description = "text to linq", Type = typeof(string), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "links", In = ParameterLocation.Path, Required = true, Summary = "",
            Description = "true to return links to pages, false (default) to embed data from pages", Type = typeof(bool), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "date", In = ParameterLocation.Path, Required = true, Summary = "",
            Description = "text to linq", Type = typeof(DateTime), Visibility = OpenApiVisibilityType.Important)]
        [OpenApiParameter(name: "orderNumber", Type = typeof(Int32), In = ParameterLocation.Path, Required = true, Summary = "",
            Description = "true to return links to pages, false (default) to embed data from pages", Visibility = OpenApiVisibilityType.Important)]

        [OpenApiResponseWithBody(statusCode: HttpStatusCode.OK, contentType: "application/json", bodyType: typeof(List<WikiPageApp.Model.WikiPageUpdate>), Description = "The OK response message containing a JSON result.")]
        [OpenApiOperation(operationId: "GetLatestWikiPageUpdates", tags: new[] { "wiki-page-update" })]

        [Function("GetLatest")]
        public HttpResponseData SerialRun([HttpTrigger(AuthorizationLevel.Anonymous, "get",
            Route = "latest/{user}/{links}/{date}/{orderNumber}")] HttpRequestData req, string user, bool links, DateTime date, int orderNumber)
        {
            _logger.LogInformation("C# HTTP trigger function processed a request.");

            var response = req.CreateResponse(HttpStatusCode.OK);
            response.Headers.Add("Content-Type", "application/json; charset=utf-8");


            // getWikiPageUpdates

            // writeUserLastRead
            

            //response.WriteString("Welcome to Azure Functions!");

            return response;
        }
    }
}
