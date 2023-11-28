namespace GrandPianosParts.Data.Entities
{
    public interface IEntity
    {
        int Id { get; set; }
        string PartName { get; set; }
        public string PartNumber { get; set; }
        public char Producer { get; set; }
    }
}
