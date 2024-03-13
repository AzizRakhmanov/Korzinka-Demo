using Korzinka_Demo.DAL.DbContexts;
using Korzinka_Demo.DAL.Repositories;
using Korzinka_Demo.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            { 

                var repository = new KorzinkaRepository<Product>(new KorzinkaDbContext());


                // var er = await  repository.DeleteAsync( p => p.Name == "OLma");

                  repository.Update(
                    new Product()
                    {
                       Id = new Guid("7fa85f64-5717-4562-b3fc-2c963f66afa8"),
                        Name = "Behi",
                        Price = 3000,
                        Address = new ProductAddress()
                        {
                             Id = new Guid(),
                             Address = "ChinaTown"
                        }                        
                    });

              


                //var result = await repository.InsertAsync(
                //    new Product()
                //    {
                //        Id = new Guid(),
                //        Name = "Olma",
                //        Price = 10000
                //    });

                //Console.WriteLine(result);
            }
        }
    }
}
