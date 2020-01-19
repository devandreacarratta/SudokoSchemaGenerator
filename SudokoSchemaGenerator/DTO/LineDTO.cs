namespace SudokoSchemaGenerator.DTO
{
    public class LineDTO
    {

        public LineDTO(int index, string values)
        {
            this.Index = index;
            this.Values = values;
            this.Chars = values.ToCharArray();
        }
        public int Index { get; private set; }
        public string Values { get; private set; }

        public char[] Chars { get; private set; }
    }
}