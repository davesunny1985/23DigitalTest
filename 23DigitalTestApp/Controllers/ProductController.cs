using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using DigitalTestApp.Infrastructure.Interfaces;
using DigitalTestApp.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;
using AutoMapper;
using DigitalTestApp.Models;

namespace DigitalTestApp.Controllers
{
    //[Authorize]
    [EnableCors("AllowAll")]
    [Produces("application/json")]
    [Route("api/[Controller]")]
    public class ProductController : Controller
    {
        private readonly IProductRepository _products;
        public ProductController(IProductRepository products)
        {
            _products = products;
        }
        [HttpGet]
        //[Route("api/GetProducts")]
        public IActionResult Get()
        {
            return  Ok(Mapper.Map<IEnumerable<ProductViewModel>>(_products.GetAll().Where(product=>!product.IsDeleted)));
        }


        [HttpGet("{productName}")]
        //[Route("api/FindProduct")]
        public IActionResult Get(string productName)
        {
            return Ok(Mapper.Map<IEnumerable<ProductViewModel>>(_products.FindBy(product => (!product.IsDeleted) && product.Name.ToLower().Contains(productName.ToLower()))));
        }

        [HttpDelete("{id}")]
        //[Route("api/DeleteProduct")]
        public IActionResult Delete(string id)
        {
            var product = _products.FindBy(item => item.Id == Guid.Parse(id));
            if (product == null)
            {
                return NotFound();
            }
            product.Single().IsDeleted = true;
            _products.Update(product.Single());
            _products.Commit();
            return new NoContentResult();
        }
    }
}