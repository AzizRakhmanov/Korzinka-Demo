using Korzinka_Demo.DAL.IRepositories;
using Korzinka_Demo.Domain.Entities;
using Korzinka_Demo.Services.Extensions;
using Korzinka_Demo.Services.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.Xml;


// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Korzinka_Demo.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        protected readonly IKorzinkaRepository<Product> korzinkaRepository;
        public ProductController(IKorzinkaRepository<Product> repository)
        {
            korzinkaRepository = repository;
        }


        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get([FromQuery] PaginationParams paginationParams)
        {
            var all = korzinkaRepository.SelectAll(p => !p.Id.Equals(null), paginationParams).ToList();

            PagedList<Product> result = new PagedList<Product>(all,30, all.Count, paginationParams.PageIndex);

            return (IEnumerable<Product>)result;
        }


        // GET api/<ProductController>/5
        [HttpGet("{id:guid}")]
        public async Task<Product> Get(Guid id)
        => await korzinkaRepository.SelectAsync(p => p.Id == id);


        // POST api/<ProductController>
        [HttpPost]
        public async Task<bool> Post([FromBody] Product product)
        => await korzinkaRepository.InsertAsync(product);


        // PUT api/<ProductController>/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id, [FromBody] Product entity)
        {
            korzinkaRepository.Update(entity);
        }



        // DELETE api/<ProductController>/5
        [HttpDelete("{id:guid}")]
        public async Task<bool> Delete(Guid id)
        {
            return await korzinkaRepository.DeleteAsync(p => p.Id == id);
        }
    }
}
