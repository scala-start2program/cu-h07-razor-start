using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Wba.StovePalace.Data;
using System;
using System.Linq;

namespace Wba.StovePalace.Models
{
    public static class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new StoveContext(
                serviceProvider.GetRequiredService<
                    DbContextOptions<StoveContext>>()))
            {
                if (!context.Fuel.Any() && !context.Brand.Any() && !context.Stove.Any())
                {
                    Fuel hout = new Fuel {FuelName = "Hout"};
                    Fuel kolen = new Fuel {FuelName = "Kolen"};
                    Fuel pellets = new Fuel {FuelName = "Pellets"};
                    context.Fuel.AddRange(
                        hout, kolen, pellets
                    );
                    context.SaveChanges();

                    Brand saey = new Brand {BrandName = "Saey"};
                    Brand jotul = new Brand {BrandName = "Jotul"};
                    Brand moderna = new Brand {BrandName = "Moderna"};
                    context.Brand.AddRange(
                        saey, jotul, moderna
                    );
                    context.SaveChanges();

                    context.Stove.AddRange(
                        new Stove { Brand = moderna, Fuel = hout, ModelName = "Modena", Performance = 19000, SalesPrice = 2590m },
                        new Stove { Brand = moderna, Fuel = pellets, ModelName="Bella", Performance=14000, SalesPrice=1599m},
                        new Stove { Brand = saey, Fuel = hout, ModelName="Gustav", Performance=9000, SalesPrice=2200m},
                        new Stove { Brand = saey, Fuel = hout, ModelName="Scope", Performance=9000, SalesPrice=2199m},
                        new Stove { Brand = saey, Fuel = kolen, ModelName="Duo", Performance=7000, SalesPrice=1999m},
                        new Stove { Brand = saey, Fuel = pellets, ModelName = "Qubic 9", Performance=9600, SalesPrice=1599m},
                        new Stove { Brand = jotul, Fuel=hout, ModelName="F167", Performance=10500, SalesPrice=3075m},
                        new Stove { Brand = jotul, Fuel=hout, ModelName="F400", Performance=15000, SalesPrice=3500m}
                        );
                    context.SaveChanges();
                }

            }
        }

    }
}
