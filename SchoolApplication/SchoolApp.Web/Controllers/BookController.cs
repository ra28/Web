using SchoolApp.Web.Models;
using SchoolApp.Web.Scripts;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace SchoolApp.Web.Controllers
{
    public class BookController : Controller
    {
        private BookService _service = new BookService();
        // GET: Book
        public ActionResult Index()
        {
            return View(_service.GetListOfBooks().ToList());
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            Book book = _service.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Title, Year, Price, Genre, AuthorId")]Book book)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _service.AddBook(book);
                    return RedirectToAction("Index");
                }
            }
            catch (System.Data.DataException /* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists see your system administrator.");
            }
            return View(book);
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            Book book = _service.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, FormCollection collection)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book bookToUpdate = _service.GetBookById(id);
            if (TryUpdateModel(bookToUpdate, "",
               new string[] { "Title", "Year", "Price", "Genre", "AuthorId" }))
            {
                try
                {
                    _service.EditBook(bookToUpdate);

                    return RedirectToAction("Index");
                }
                catch (DataException /* dex */)
                {
                    //Log the error (uncomment dex variable name and add a line here to write a log.
                    ModelState.AddModelError("", "Unable to save changes. Try again, and if the problem persists, see your system administrator.");
                }
            }
            return View(bookToUpdate);
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id, bool? saveChangesError = false)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            if (saveChangesError.GetValueOrDefault())
            {
                ViewBag.ErrorMessage = "Delete failed. Try again, and if the problem persists see your system administrator.";
            }
            Book book = _service.GetBookById(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Book/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                _service.DeleteBook(id);
            }
            catch (DataException/* dex */)
            {
                //Log the error (uncomment dex variable name and add a line here to write a log.
                return RedirectToAction("Delete", new { id = id, saveChangesError = true });
            }
            return RedirectToAction("Index");
        }
    }
}
