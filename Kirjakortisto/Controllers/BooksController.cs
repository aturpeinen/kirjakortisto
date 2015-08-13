using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Kirjakortisto.Context;
using Kirjakortisto.Models;
using Kirjakortisto.Repositories;

namespace Kirjakortisto.Controllers
{
    public class BooksController : Controller
    {
        private readonly IBooksRepository booksRepository;

        // No needed because of DI
        /*public BooksController()
        {
            booksRepo = new BooksRepository();
        }*/

        // Use constructor injection for the dependencies
        public BooksController(IBooksRepository booksRepository)
        {
            this.booksRepository = booksRepository;
        }

        // GET: Books
        public ActionResult Index()
        {
            return View(/*db.Books.ToList()*/); // Angular loads books with ajax
        }

        public JsonResult IndexJSON()
        {
            return Json(booksRepository.Books.ToList(), JsonRequestBehavior.AllowGet);
        }

        // GET: Books/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = booksRepository.GetById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Description,Author,PurchaseDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepository.Save(book);
                return RedirectToAction("Index");
            }

            return View(book);
        }

        // GET: Books/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = booksRepository.GetById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Description,Author,PurchaseDate")] Book book)
        {
            if (ModelState.IsValid)
            {
                booksRepository.Save(book);
                return RedirectToAction("Index");
            }
            return View(book);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = booksRepository.GetById(id.Value);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = booksRepository.GetById(id);
            booksRepository.Delete(book);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                booksRepository.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
