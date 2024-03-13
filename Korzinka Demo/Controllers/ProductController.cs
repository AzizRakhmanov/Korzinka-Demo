using Korzinka_Demo.DAL.IRepositories;
using Korzinka_Demo.Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Net.Http.Headers;

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
            this.korzinkaRepository = repository;
        }

        
        // GET: api/<ProductController>
        [HttpGet]
        public async Task<IEnumerable<Product>> Get()
        {
            var all = await this.korzinkaRepository.SelectAll(p => p.Id.Equals(null)).ToListAsync();
            return (IEnumerable<Product>)all;
        }

        // GET api/<ProductController>/5
        [HttpGet("{id}")]
        public async Task<Product> Get(Guid id)
        {
            Product product = await this.korzinkaRepository.SelectAsync(p => p.Id == id);

            return product;
        }

        // POST api/<ProductController>
        [HttpPost]  
        public async Task Post([FromBody] Product product)
        =>   await this.korzinkaRepository.InsertAsync(product);

    
        

        // PUT api/<ProductController>/5
        [HttpPut("{id:guid}")]
        public void Put(Guid id,[FromBody] Product entity)
        {
            this.korzinkaRepository.Update(entity);
        }

        // DELETE api/<ProductController>/5
        [HttpDelete("{id:guid}")]
        public async Task<bool> Delete(Guid id)
        {
           return   await this.korzinkaRepository.DeleteAsync(p => p.Id == id);
        }
    }
}
