using SchoolApp.Server.IRepository;
using SchoolApp.Server.Models.DataObject;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;

namespace SchoolApp.Server.Controllers
{
    public class BooksController : ApiController
    {
        private BookRepository repository = new BookRepository();

        // GET: api/Books
        public IEnumerable<Book> GetBooks()
        {
            return repository.GetAll();
        }

        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult GetBook(int id)
        {
            var book = repository.GetByID(id);

            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            repository.Edit(book);
            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Books
        [ResponseType(typeof(Book))]
        public IHttpActionResult PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

             repository.Add(book);

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public IHttpActionResult DeleteBook(int id)
        {
            Book book = repository.GetByID(id);
            if (book == null)
            {
                return NotFound();
            }

            repository.Delete(book);

            return Ok(book);
        }

        private bool BookExists(int id)
        {
            return repository.GetAll().Count(e => e.Id == id) > 0;
        }
    }
}
