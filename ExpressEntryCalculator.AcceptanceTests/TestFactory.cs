using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using System.IO;
using System.Text;
using System.Text.Json;

namespace ExpressEntryCalculator.AcceptanceTests
{
    public class TestFactory
    {
        public static HttpRequest CreateHttpRequest(object body)
        {
            var stringContent = JsonSerializer.Serialize(body);
            byte[] byteArray = Encoding.ASCII.GetBytes(stringContent);

            var context = new DefaultHttpContext();
            var request = context.Request;
            request.Method = "POST";
            request.Body = new MemoryStream(byteArray);

            return request;
        }

        public static ILogger CreateLogger(LoggerTypes type = LoggerTypes.Null)
        {
            ILogger logger;

            if (type == LoggerTypes.List)
            {
                logger = new ListLogger();
            }
            else
            {
                logger = NullLoggerFactory.Instance.CreateLogger("Null Logger");
            }

            return logger;
        }
    }
}
