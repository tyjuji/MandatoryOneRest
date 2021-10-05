using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandatoryOneLibrary;
using MandatoryOneRest.Managers;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace MandatoryOneRest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        BooksManager _manager = new BooksManager();

        // GET: api/<BooksController>
        [HttpGet]
        public IEnumerable<Book> Get()
        {
            return _manager.GetAll();
        }

        // GET api/<BooksController>/5
        [HttpGet("{ISBN13}")]
        public Book Get(string ISBN13)
        {
            return _manager.GetByISBN(ISBN13);
        }

        // POST api/<BooksController>
        [HttpPost]
        public void Post([FromBody] Book book)
        {
            _manager.PostBook(book);
        }

        // PUT api/<BooksController>/5
        [HttpPut("{ISBN13}")]
        public void Put(string ISBN13, [FromBody] Book book)
        {
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{ISBN13}")]
        public void Delete(string ISBN13)
        {
        }
    }
}
