
namespace GrandPianosParts.Entities
{
    public abstract class EntityBase : IEntity
    {
        public int Id { get; set; }  
        public string PartName { get; set; }

    }
}
