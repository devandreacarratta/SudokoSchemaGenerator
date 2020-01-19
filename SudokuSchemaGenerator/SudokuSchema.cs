using SudokuSchemaGenerator.DTO;
using SudokuSchemaGenerator.Logic;
using System;

namespace SudokuSchemaGenerator
{
    public class SudokuSchema
    {
        private const int NUMBER_OF_ELEMENTS = 81;

        public SudokuSchema()
        {
        }

        public SudokuSchemaDTO Generate()
        {
            SudokuSchemaDTO result = new SudokuSchemaDTO();
            CalculateNumbersToShow(ref result);
            GenerateBasicSchema(ref result);
            return result;
        }

        private void CalculateNumbersToShow(ref SudokuSchemaDTO sudoku)
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
                sudoku.CellsToShow.Add(cell);
            }
        }

        private void GenerateBasicSchema(ref SudokuSchemaDTO sudoku)
        {
            ColumnsLogic columns = new ColumnsLogic();
            LinesLogic lines = new LinesLogic();

            while (sudoku.Solution.Count < 9)
            {
                string row = lines.GenerateNew();
                if (sudoku.Solution.Contains(row))
                {
                    continue;
                }

                if (columns.IsValid(sudoku.Solution, row))
                {
                    var chars = row.ToCharArray();

                    for (int i = 0; i < chars.Length; i++)
                    {
                        var cell = new CellDTO(sudoku.Solution.Count, i)
                        {
                            Value = chars[i].ToString(),
                            IsVisible = false,
                        };

                        foreach (var item in sudoku.CellsToShow)
                        {
                            if (item.Row != sudoku.Solution.Count) { continue; }

                            if (item.Column != i) { continue; }

                            cell.IsVisible = true;
                        }

                        sudoku.SolutionMatrix.Add(cell);
                    }

                    sudoku.Lines.Add(new LineDTO(sudoku.Solution.Count, row));
                    sudoku.Solution.Add(row);
                }
            }
        }
    }
}