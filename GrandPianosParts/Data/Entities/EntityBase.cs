namespace GrandPianosParts.Data.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public char Producer { get; set; }

    }
}
