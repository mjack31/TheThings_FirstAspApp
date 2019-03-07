using System;
using System.Collections.Generic;
using System.Text;

namespace TheThings.Models
{
    public class Thing
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Location { get; set; }
        public ThingType Type { get; set; }
    }
}
