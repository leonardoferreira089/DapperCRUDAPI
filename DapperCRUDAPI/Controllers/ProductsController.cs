using DapperCRUDAPI.Model;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DapperCRUDAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly ProductRepository _repository;
        public ProductsController()
        {
            _repository = new ProductRepository();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _repository.GetAllProducts();
        }

        [HttpGet("{id}")]
        public Product GetProjectById(int id)
        {
            return _repository.GetProductById(id);
        }

        [HttpPost]
        public void Post([FromBody] Product prod)
        {
            if (ModelState.IsValid)
            {
                _repository.CreateProduct(prod);
            }
        }

        [HttpPut("{id}")]
        public void UpdateProject(int id, [FromBody] Product prod)
        {
            prod.ProductId = id;
            if (ModelState.IsValid)
            {
                _repository.UpdateProject(prod);
            }
        }

        [HttpDelete]
        public void Delete(int id)
        {
            _repository.DeleteProject(id);
        }
    }
}
