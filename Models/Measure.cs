using System;
using System.Collections.Generic;
using System.Text;

namespace PruebaNivel.Models
{
    [Serializable]
    public class Measure
    {
        public int ID { get; set; }
        [field: NonSerialized()]
        public DateTime LastDate { get; set; }
        public string CPUSerial { get; set; }
        public string MotherboardSerial { get; set; }

        public float CPUusage { get; set; }
        public float RAMusage { get; set; }
    }
}
