using System;
using System.Collections.Generic;
using System.Text;
using TheThings.Models;

namespace TheThings.Data.Interfaces
{
    public interface IThingsRepository
    {
        List<Thing> GetAll();
    }
}
