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

        public IEnumerable<Thing> GetByName(string name = null)
        {
            return _things.OrderBy(t => t.Name).Where(t => string.IsNullOrEmpty(name) || t.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).Select(t => t);
        }

        public Thing GetById(int id)
        {
            return _things.SingleOrDefault(t => id == t.Id);
        }

        public Thing Update(Thing updatedRestaurent)
        {
            var restaurant = _things.SingleOrDefault(r => r.Id == updatedRestaurent.Id);
            restaurant.Name = updatedRestaurent.Name;
            restaurant.Location = updatedRestaurent.Location;
            restaurant.Type = updatedRestaurent.Type;
            return restaurant;
        }

        public int SaveChanges()
        {
            return 0;
        }

        public Thing Add(Thing thingToAdd)
        {
            _things.Add(thingToAdd);
            thingToAdd.Id = _things.Max(t => t.Id) + 1;
            return thingToAdd;
        }

        public Thing Delete(int idToDelete)
        {
            var thingToDelete = _things.FirstOrDefault(t => t.Id == idToDelete);
            _things.Remove(thingToDelete);
            return thingToDelete;
        }
    }
}
