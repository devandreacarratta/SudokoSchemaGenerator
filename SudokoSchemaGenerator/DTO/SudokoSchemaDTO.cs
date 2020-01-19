using System.Collections.Generic;

namespace SudokoSchemaGenerator.DTO
{
    public class SudokoSchemaDTO
    {
        public List<string> Solution { get; set; } = new List<string>();
        public List<char[]> SolutionMatrix { get; set; } = new List<char[]>();
        public List<BaseCellDTO> CellsToShow { get; set; } = new List<BaseCellDTO>();
    }
}