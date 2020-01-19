using SudokoSchemaGenerator.DTO;
using SudokoSchemaGenerator.Logic;
using System;

namespace SudokoSchemaGenerator
{
    public class SudokoSchema
    {
        private const int NUMBER_OF_ELEMENTS = 81;

        public SudokoSchema()
        {
        }

        public SudokoSchemaDTO Generate()
        {
            SudokoSchemaDTO sudoko = new SudokoSchemaDTO();
            CalculateNumbersToShow(ref sudoko);
            GenerateBasicSchema(ref sudoko);

            return sudoko;
        }

        private void CalculateNumbersToShow(ref SudokoSchemaDTO sudoko)
        {
            int position = 0;

            Random random = new Random();
            while (position < NUMBER_OF_ELEMENTS)
            {
                int nextStp = random.Next(0, 5);

                if (nextStp == 0)
                {
                    continue;
                }

                position += nextStp;

                if (position > NUMBER_OF_ELEMENTS) { break; }

                var divMod = position % 9;
                var div = (position / 9);

                BaseCellDTO cell = new BaseCellDTO(div, divMod);
                sudoko.CellsToShow.Add(cell);
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
                    var chars = row.ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        var cell = new CellDTO(sudoko.Solution.Count, i)
                        {
                            Value = chars[i].ToString(),
                            IsVisible = false,
                        };

                        foreach (var item in sudoko.CellsToShow)
                        {
                            if (item.Row != sudoko.Solution.Count) { continue; }

                            if (item.Column != i) { continue; }

                            cell.IsVisible = true;
                        }

                        sudoko.SolutionMatrix.Add(cell);
                    }

                    sudoko.Lines.Add(new LineDTO(sudoko.Solution.Count, row));
                    sudoko.Solution.Add(row);
                }
            }
        }
    }
}