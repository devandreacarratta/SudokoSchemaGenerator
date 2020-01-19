using Newtonsoft.Json;
using System.Collections.Generic;

namespace SudokuSchemaGenerator.DTO
{
    public class SudokuSchemaDTO
    {
        public List<string> Solution { get; set; } = new List<string>();

        public List<LineDTO> Lines { get; set; } = new List<LineDTO>();
        public List<CellDTO> SolutionMatrix { get; set; } = new List<CellDTO>();

        [JsonIgnore]
        public List<BaseCellDTO> CellsToShow { get; set; } = new List<BaseCellDTO>();
    }
}