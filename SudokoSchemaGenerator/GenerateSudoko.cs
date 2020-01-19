using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SudokoSchemaGenerator
{
    public static class GenerateSudoko
    {
        [FunctionName("GenerateSudoko")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            SudokoSchema sudoko = new SudokoSchema();
            var result = sudoko.Generate();

            return JsonConvert.SerializeObject(result);
        }
    }
}