using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SudokoSchemaGenerator.Logic
{
    public class RowsLogic
    {

        private const string NUMBERS = "123456789";

        public string GenerateNew()
        {
            string result = Shuffle(NUMBERS);

            return result;
        }

        private string Shuffle(string text)
        {
            Random num = new Random();

            var chars = text.ToCharArray()
                        .OrderBy(s => num.NextDouble())
                        .ToArray();

            return new string(chars);

        }



    }
}
