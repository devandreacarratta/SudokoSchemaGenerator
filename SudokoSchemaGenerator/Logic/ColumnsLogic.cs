using System.Collections.Generic;

namespace SudokoSchemaGenerator.Logic
{
    public class ColumnsLogic
    {
        public bool IsValid(List<string> solution, string row)
        {
            foreach (var line in solution)
            {
                for (int i = 0; i < row.Length; i++)
                {
                    if (line[i] == row[i])
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}