using SudokoSchemaGenerator.DTO;
using SudokoSchemaGenerator.Logic;
using System;
using System.Collections.Generic;

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
            GenerateBasicSchema(ref sudoko);
            CalculateMatrixSchema(ref sudoko);

            CalculateNumbersToShow(ref sudoko);

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