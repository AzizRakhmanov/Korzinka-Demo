using Korzinka_Demo.DAL.DbContexts;
using Korzinka_Demo.DAL.Repositories;
using Korzinka_Demo.Domain.Entities;
using Korzinka_Demo.Services.Pagination;

namespace Test
{
    internal class Program
    {
        static async Task Main(string[] args)
        {
            {
                ProductAddress productAddress = new ProductAddress()
                {
                    Id = new Guid(),
                    Address = "Chilonzor",
                    CreatedAt = DateTime.Now,
                    UpdatedAt = DateTime.Now,
                };





                var repository = new KorzinkaRepository<ProductAddress>(new KorzinkaDbContext());


                var result = repository.SelectAll(p => !p.Id.Equals(null), new PaginationParams(1, 10));

                foreach (var item in result)
                {
                    Console.WriteLine(item.Address + " " + item.Id);
                }

                //var result =  await repository.InsertAsync(productAddress);

                //Console.Write(result);


                //// var er = await  repository.DeleteAsync( p => p.Name == "OLma");

                //  repository.Update(
                //    new Product()
                //    {
                //       Id = new Guid("7fa85f64-5717-4562-b3fc-2c963f66afa8"),
                //        Name = "Behi",
                //        Price = 3000,
                //        Address = new ProductAddress()
                //        {
                //             Id = new Guid(),
                //             Address = "ChinaTown"
                //        }                        
                //    });




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
