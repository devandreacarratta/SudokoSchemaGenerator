using SudokoSchemaGenerator.DTO;
using SudokoSchemaGenerator.Logic;

namespace SudokoSchemaGenerator
{
    public class SudokoSchema
    {
        public SudokoSchema()
        {
        }

        public SudokoSchemaDTO Generate()
        {
            SudokoSchemaDTO sudoko = new SudokoSchemaDTO();
            GenerateBasicSchema(ref sudoko);
            CalculateMatrixSchema(ref sudoko);

            return sudoko;
        }

        private void CalculateMatrixSchema(ref SudokoSchemaDTO sudoko)
        {
            foreach (var item in sudoko.Solution)
            {
                var chars = item.ToCharArray();
                sudoko.SolutionMatrix.Add(chars);
            }
        }

        private void GenerateBasicSchema(ref SudokoSchemaDTO sudoko)
        {
            ColumnsLogic columns = new ColumnsLogic();
            LinesLogic lines = new LinesLogic();

            while (sudoko.Solution.Count < 9)
            {
                string row = lines.GenerateNew();
                if (sudoko.Solution.Contains(row))
                {
                    continue;
                }

                if (columns.IsValid(sudoko.Solution, row))
                {
                    sudoko.Solution.Add(row);
                }
            }
        }
    }
}