namespace SudokoSchemaGenerator.DTO
{
    public class CellDTO : BaseCellDTO
    {
        public CellDTO(int row, int column) : base(row, column)
        {
        }

        public string Value { get; set; }
        public bool IsVisible { get; set; }
    }

    public class BaseCellDTO
    {
        public BaseCellDTO(int row, int column)
        {
            this.Row = row;
            this.Column = column;
        }
        public int Row { get; private set; }
        public int Column { get; private set; }
    }
}