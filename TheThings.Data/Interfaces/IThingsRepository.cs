using System;
using System.Collections.Generic;
using System.Text;
using TheThings.Models;

namespace TheThings.Data.Interfaces
{
    public interface IThingsRepository
    {
        IEnumerable<Thing> GetByName(string name);
        Thing GetById(int id);
        Thing Update(Thing updatedRestaurent);
        Thing Add(Thing thingToAdd);
        Thing Delete(int idToDelete);
        int CountThings();
        int SaveChanges();
    }
}
