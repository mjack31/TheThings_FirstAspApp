using System;
using System.Collections.Generic;
using System.Text;
using TheThings.Data.Interfaces;
using TheThings.Models;
using System.Linq;

namespace TheThings.Data
{
    public class DummyThingsService : IThingsRepository
    {
        // seeding dummy data
        List<Thing> _things;

        public DummyThingsService()
        {
            _things = new List<Thing>()
            {
                new Thing {Id=1, Name="Banana", Location="Bowl", Type=ThingType.Food},
                new Thing {Id=2, Name="Apple", Location="Fridge", Type=ThingType.Food},
                new Thing {Id=3, Name="Orange", Location="Bowl", Type=ThingType.Food},
                new Thing {Id=4, Name="TV", Location="Table", Type=ThingType.Device},
                new Thing {Id=5, Name="Knife", Location="Kitchen", Type=ThingType.Tool},
            };
        }

        public List<Thing> GetAll()
        {
            return _things.OrderBy(t => t.Name).ToList();
        }
    }
}
