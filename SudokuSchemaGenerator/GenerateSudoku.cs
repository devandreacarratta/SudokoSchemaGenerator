using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace SudokuSchemaGenerator
{
    public static class GenerateSudoku
    {
        [FunctionName("GenerateSudoku")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {
            SudokuSchema sudokuSchema = new SudokuSchema();
            var result = sudokuSchema.Generate();

            return JsonConvert.SerializeObject(result, Formatting.None);
        }
    }
}