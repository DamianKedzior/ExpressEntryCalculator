using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ExpressEntryCalculator.Api.Models;

namespace ExpressEntryCalculator.Api
{
    public static class GetLastStats
    {
        [FunctionName("stats")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var lastStats = new ExpressEntryStats
            {
                InvitationsIssued = 3600,
                LowestScore = 471,
                RoundDate = new DateTime(2019, 11, 27)
            };

            return new OkObjectResult(lastStats);
        }
    }
}
