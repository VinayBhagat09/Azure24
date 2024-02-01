using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Web.Http;

namespace FunctionWithUnitTesting
{
    public static class WatchInfo
    {
        [FunctionName("WatchInfo")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            //Retrieve the model id from the query string
            string model = req.Query["model"];
            //If the user specified a model ID , find the details for model of watch

            //Dynamic data types are dynamic in nature and don’t require initialization at the time of declaration. It also means that a dynamic type does not have a predefined type and can be used to store any type of data.
            //dynamic tt = new { Manufacturer = "abc", CaseType = "Solid", Bezel = "Titanium", Dial = "Roman", CaseFinish = "Silver", Jewels = 15 };

            List<Watches> watches = new List<Watches>()
            {
                new Watches(){Model = "aa" , Manufacturer = "Tata" ,CaseType = "Solid", Bezel = "Titanium" , Dial = "Round", CaseFinish = "Silver" , Jewels = "15"},
                 new Watches(){Model = "bb" , Manufacturer = "FastTrack" ,CaseType = "Soft", Bezel = "Gold" , Dial = "V-Shaped", CaseFinish = "Silver" , Jewels = "19"},
                  new Watches(){Model = "cc" , Manufacturer = "Rolex" ,CaseType = "Solid", Bezel = "Titanium" , Dial = "Round", CaseFinish = "Silver" , Jewels = "28"},

            };
            foreach(Watches data in watches)
            {
               if(data.Model != model)
                {
                    return (ActionResult)new BadRequestErrorMessageResult("This is not a valid object");
                }
                return (ActionResult)new OkObjectResult(data);
            }

            //if (model == null) { 
            
            //return (ActionResult)new OkObjectResult($"Watch Details : {tt.Manufacturer}, {tt.CaseType} , {tt.Bezel}, {tt.Dial}, {tt.CaseFinish}, {tt.Jewels}");
            // }
            return new BadRequestObjectResult("Please provide a watch model in the query string");
        }
    }
}
