
using System.Text.Json.Serialization;

namespace GrandPianosParts.Entities
{
    public class PianoParts : EntityBase
    {        
        public string PartName { get; set; }
        public string PartNumber { get; set; }
        public char Producer { get; set; }
        public override string ToString() => $"id : {Id}, partName : {PartName}, PartNumber : {PartNumber}, Producer : {Producer}";

    }
}
