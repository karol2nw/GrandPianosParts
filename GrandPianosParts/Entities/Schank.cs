

namespace GrandPianosParts.Entities
{
    public class Schank : EntityBase
    {
        string PartNumber { get; set; }

        string PartName { get; set; }

        char Producer { get; set; }

        public override string ToString() => $"id : {Id}, partName : {PartName}, PartNumber : {PartNumber}";

    }
}
