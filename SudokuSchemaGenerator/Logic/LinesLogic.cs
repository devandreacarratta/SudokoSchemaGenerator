using System;
using System.Linq;

namespace SudokuSchemaGenerator.Logic
{
    public class LinesLogic
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