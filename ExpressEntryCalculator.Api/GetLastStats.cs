using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using ExpressEntryCalculator.Api.Models;
using System.IO;

namespace ExpressEntryCalculator.Api
{
    public static class GetLastStats
    {
        const int defaultInvitationIssued = 3232;
        const int defaultLowestScore = 467;
        private static DateTime defaultRoundDate = new DateTime(2020, 3, 23);

        [FunctionName("stats")]
        public static async Task<IActionResult> Run(
            [HttpTrigger(AuthorizationLevel.Anonymous, "get", Route = null)] HttpRequest req,
            [Blob("express-entry-rounds/last_draw", FileAccess.Read, Connection = "AzureWebJobsStorage")] string myBlob,
            ILogger log)
        {
            log.LogInformation($"C# HTTP trigger function processed a request. myBlob size: {myBlob.Length} bytes");

            var lastDrawInfo = myBlob.Split('\n');
            if (lastDrawInfo.Length < 2)
            {
                return await Task.FromResult(new OkObjectResult(new ExpressEntryStats
                {
                    InvitationsIssued = defaultInvitationIssued,
                    LowestScore = defaultLowestScore,
                    RoundDate = defaultRoundDate
                }));
            }

            DateTime roundDate;
            if (!DateTime.TryParse(lastDrawInfo[0], out roundDate))
            {
                roundDate = defaultRoundDate;
            }

            int invitationIssued;
            if (!int.TryParse(lastDrawInfo[1], out invitationIssued))
            {
                invitationIssued = defaultInvitationIssued;
            }

            int lowestScore;
            if (!int.TryParse(lastDrawInfo[2], out lowestScore))
            {
                lowestScore = defaultLowestScore;
            }

            var lastStats = new ExpressEntryStats
            {
                InvitationsIssued = invitationIssued,
                LowestScore = lowestScore,
                RoundDate = roundDate
            };

            return await Task.FromResult(new OkObjectResult(lastStats));
        }
    }
}
