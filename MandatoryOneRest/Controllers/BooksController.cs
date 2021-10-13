using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MandatoryOneLibrary;
using MandatoryOneRest.Managers;
using Microsoft.AspNetCore.Http;

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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<IEnumerable<Book>> Get()
        {
            var result = _manager.GetAll();
            if (result != null && result.Count() > 0)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // GET api/<BooksController>/5
        [HttpGet("{ISBN13}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> Get(string ISBN13)
        {
            var result = _manager.GetByISBN(ISBN13);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // POST api/<BooksController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status409Conflict)]
        public ActionResult<Book> Post([FromBody] Book book)
        {
            var result = _manager.PostBook(book);
            if (result != null)
            {
                return Ok(result);
            }
            return Conflict();
        }

        // PUT api/<BooksController>/5
        [HttpPut("{ISBN13}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> Put(string ISBN13, [FromBody] Book book)
        {
            var result = _manager.PutBook(ISBN13, book);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }

        // DELETE api/<BooksController>/5
        [HttpDelete("{ISBN13}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<Book> Delete(string ISBN13)
        {
            var result = _manager.DeleteBook(ISBN13);
            if (result != null)
            {
                return Ok(result);
            }
            return NotFound();
        }
    }
}
