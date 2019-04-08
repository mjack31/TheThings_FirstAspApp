using System;
using System.Collections.Generic;
using System.Text;
using TheThings.Data.Interfaces;
using TheThings.Models;
using System.Linq;

namespace TheThings.Data
{
    class DbThingsService : IThingsRepository
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
            return thingsDbContext.SaveChanges();
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
            return thingsDbContext.Things.FirstOrDefault();
        }

        public IEnumerable<Thing> GetByName(string name)
        {
            throw new NotImplementedException();
        }

        public int SaveChanges()
        {
            throw new NotImplementedException();
        }

        public Thing Update(Thing updatedRestaurent)
        {
            throw new NotImplementedException();
        }
    }
}
