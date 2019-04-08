using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TheThings.Models;

namespace TheThings.Data

// Aby mieć pewność ze jest dobrze skonfigurowane połączenie z bazą danych należ pozyskać info o DbContext przez Entity Framework Core CLI
// Komenda w projekcie danych (tutaj TheThings.Data) dotnet ef dbcontext info
// Aby sprawdzić czy w ogóle jest dobrze zinicjalizowany DbContext można użyć komendy dotnet ef dbcontext info. To pokaże dostępne DbContext'y
// Na końcu komendy info trzeba zdefiniować projekt startowy w którym zazwyczaj jest konfiguracja połączenia - connection string (appsettings.json) oraz ustawienia (Startup.cs)
// Robi się to dodając na końcu -s i lokalizację projektu z konfiguracją (tutaj -s ../TheThings_FirstAspApp/TheThings_FirstAspApp.csproj)

{
    public class ThingsDbContext : DbContext
    {
        public ThingsDbContext(DbContextOptions<ThingsDbContext> opt)
            : base(opt)
        {

        }

        public DbSet<Thing> Things { get; set; }
    }
}
