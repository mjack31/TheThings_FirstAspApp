using System;
using System.Collections.Generic;
using System.Text;
using TheThings.Data.Interfaces;
using TheThings.Models;
using System.Linq;

namespace TheThings.Data
{
    public class DbThingsService : IThingsRepository
    {
        private readonly ThingsDbContext thingsDbContext;

        public DbThingsService(ThingsDbContext thingsDbContext)
        {
            this.thingsDbContext = thingsDbContext;
        }

        public Thing Add(Thing thingToAdd)
        {
            thingsDbContext.Things.Add(thingToAdd);
            return thingToAdd;
        }

        public int CountThings()
        {
            return thingsDbContext.Things.Count();
        }

        public Thing Delete(int idToDelete)
        {
            var thing = GetById(idToDelete);
            if(thing != null)
            {
                thingsDbContext.Things.Remove(thing);
            }
            return thing;
        }

        public Thing GetById(int id)
        {
            return thingsDbContext.Things.FirstOrDefault(t => t.Id == id);
        }

        public IEnumerable<Thing> GetByName(string name)
        {
            // do każdej z chain metod trafia po kolei każdy element kolekcji. Jeżeli metoda zwraca true to element jest zwracany i dodawany do końcowego wyniku chaina
            return thingsDbContext.Things.OrderBy(t => t.Name).Where(t => string.IsNullOrEmpty(name) || t.Name.Contains(name, StringComparison.OrdinalIgnoreCase));
        }

        public int SaveChanges()
        {
            return thingsDbContext.SaveChanges();
        }

        public Thing Update(Thing updatedRestaurent)
        {
            var thing = thingsDbContext.Things.Attach(updatedRestaurent);
            thing.State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            return updatedRestaurent;
        }
    }
}
