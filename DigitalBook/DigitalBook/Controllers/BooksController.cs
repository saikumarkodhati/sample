using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DigitalBook.Models;

namespace DigitalBook.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksDBContext db = new BooksDBContext();
        public IEnumerable<SearchBook> Get()
        {
            return db.SearchBooks;
        }
        [HttpPost]
        public IActionResult Post([FromBody] SearchBook searchbook)
        {
            db.SearchBooks.Add(searchbook);
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

        [HttpPut]
        public IActionResult Put(SearchBook searchbook)
        {
            db.SearchBooks.Add(searchbook);
            db.Entry(searchbook).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            var data = db.SearchBooks.Where(x => x.Id == id).FirstOrDefault();
            db.SearchBooks.Remove(data);
            db.SaveChanges();
            var response = new { Status = "Success" };
            return Ok(response);
        }

        [HttpPost]
        [Route("Search")]
        public IActionResult Post(string author)
        {
            if (author == null)
            {
                return BadRequest("Invalid search options");
            }

            var searchResult = db.SearchBooks.Where(x => x.Author == author).FirstOrDefault();

            return Ok(searchResult);
        }

        // Create Book API
    }
}
