using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyProject.DataContext;
using MyProject.Model;
using ShareModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyProject.Controllers
{
    [ApiController]
    [Route("controller")]
    public class ProductsController : ControllerBase
    {
        public readonly MyDbContext _myDbContext;

        public ProductsController (MyDbContext myDbContext)
        {
            _myDbContext = myDbContext;
        }

        [HttpGet]
        public async Task<ActionResult<ProductShare>> GetProducts()
        {
            var product = await _myDbContext.products.Select(x => new ProductShare
            {
                ProductID = x.Id,
                ProductName = x.Name,
                Description = x.Description,
                Image = x.Image,
                Price = x.Price
            }).ToListAsync();
            return Ok(product);
        }

        [HttpPost]
        public async Task<ActionResult> CreateProduct(ProductFromCategory pro)
        {
            var product = new Product
            {
                Name = pro.Name,
                Description = pro.Description,
                Price = pro.Price,
                Image = pro.Img,
                CategoryId = pro.CategoryId
            };
            _myDbContext.products.Add(product);
            await _myDbContext.SaveChangesAsync();
            return Accepted();
        }
    } 
 }

