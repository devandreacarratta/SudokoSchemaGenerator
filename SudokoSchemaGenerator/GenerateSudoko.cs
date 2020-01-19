using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using SudokoSchemaGenerator.Logic;
using SudokoSchemaGenerator.DTO;

namespace SudokoSchemaGenerator
{
    public static class GenerateSudoko
    {
        [FunctionName("GenerateSudoko")]
        public static string Run(
            [HttpTrigger(AuthorizationLevel.Function, "get", "post", Route = null)] HttpRequest req,
            ILogger log)
        {

            SudokoSchemaDTO sudoko = new SudokoSchemaDTO();

            RowsLogic rows = new RowsLogic();
            while(sudoko.Solution.Count<9)
            {
                string row = rows.GenerateNew();
                if(sudoko.Solution.Contains( row))
                {
                    continue;
                }

                bool duplicateNumber = false;

                foreach (var line in sudoko.Solution)
                {
                    for (int i = 0; i < row.Length; i++)
                    {
                        if(line[i]==row[i]){ duplicateNumber = true;  break; }
                    }

                    if(duplicateNumber){
                        break;
                    }
                }

                if (duplicateNumber)
                {
                    continue;
                }

                sudoko.Solution.Add(row);
            }


            return JsonConvert.SerializeObject(sudoko);
        }
    }
}
