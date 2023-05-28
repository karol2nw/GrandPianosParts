﻿
namespace GrandPianosParts.Entities
{
    public class DamperFilz : EntityBase
    {
        public string PartNumber { get; set; }

        public string PartName { get; set; }

        public char Producer { get; set; }

        public override string ToString() => $"id : {Id}, partName : {PartName}, PartNumber : {PartNumber}";
        
    }
}