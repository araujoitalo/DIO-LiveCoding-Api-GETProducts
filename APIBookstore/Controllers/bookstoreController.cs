using APIBookstore.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace APIBookstore.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class bookstoreController : ControllerBase
    {
        private readonly TodoContext _context;



        public bookstoreController(TodoContext context)
        {

            _context = context;

            foreach (Product x in _context.TodoProducts)
                _context.TodoProducts.Remove(x);
            _context.SaveChanges();


            _context.TodoProducts.Add(new Product { Id = "1", Name = "Book1", Price = 254, Quantity = 1, Category = "Programação", Img = "img1" });
            _context.TodoProducts.Add(new Product { Id = "2", Name = "Book2", Price = 550, Quantity = 1, Category = "action", Img = "img2" });
            _context.TodoProducts.Add(new Product { Id = "3", Name = "Book3", Price = 250, Quantity = 2, Category = "action", Img = "img3" });
            _context.TodoProducts.Add(new Product { Id = "4", Name = "Book4", Price = 130, Quantity = 1, Category = "Programação", Img = "img4" });
            _context.TodoProducts.Add(new Product { Id = "9", Name = "Book5", Price = 135, Quantity = 5, Category = "Programação", Img = "img5" });
            _context.TodoProducts.Add(new Product { Id = "5", Name = "Book6", Price = 153, Quantity = 5, Category = "action", Img = "img6" });
            _context.TodoProducts.Add(new Product { Id = "58", Name = "Book7", Price = 165, Quantity = 5, Category = "action", Img = "img7" });
            _context.TodoProducts.Add(new Product { Id = "12", Name = "Book8", Price = 175, Quantity = 5, Category = "action", Img = "img8" });
            _context.TodoProducts.Add(new Product { Id = "45", Name = "Book9", Price = 175, Quantity = 5, Category = "action", Img = "img9" });
            _context.TodoProducts.Add(new Product { Id = "13", Name = "Book10", Price = 195, Quantity = 5, Category = "action", Img = "img10" });



            _context.SaveChanges();



        }

        [HttpPost]
        public async Task<ActionResult<Product>> PostProduct(Product product)
        {
            _context.TodoProducts.Add(product);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetProdut), new { id = product.Id }, product);
        }

        // GET: api/
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetTodoItems()
        {
            return await _context.TodoProducts.ToListAsync(); 



        }

        // GET: api/bookstore/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetProdut(int id)
        {
            var todoItem = await _context.TodoProducts.FindAsync(id.ToString());

            if (todoItem == null)
            {
                return NotFound();
            }

            return todoItem;
        }

    }
}
