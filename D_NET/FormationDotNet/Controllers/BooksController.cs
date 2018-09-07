using FormationDotNet.Models;
using FormationDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
namespace formationPOEwebAPI.Controllers
{

    [RoutePrefix("books")]
    public class BooksController : Controller
    {
        private MediaBdd db = new MediaBdd();
        public String index() //methode par default
        {
            return "default book";
        }
/*
        [HttpGet]
        [Route("details")]
        public ActionResult Details()
        {
            return View(db.Books.ToList());
        }
        */




        [HttpGet]
        [Route("details")]
        public ActionResult Details(String searchingString)
        {
            MediaBdd db = new MediaBdd(); //ouverture de la bdd

            //String title = "aie";
            if (searchingString == null) //Si aucun titre n'a était entré, ou si on entre pour la 1ere fois sur la page
            {
                return View(db.Books    // on appel un page, et on lui envoi des information de la base de donnée
                    .Select(b => new BookTO   //on renvoi un objet de type BookTO
                    {
                        Id = b.id,
                        Title = b.title,
                        Price = b.price,
                        PublisherName = b.publisher == null ? "None" : b.publisher.name
                    })
                    .ToList());
    }
            else  // si une recherche a étais passé 
            {
                return View(db.Books
                    .Where(b => b.title.Equals(searchingString))
                    .Select(b => new BookTO
                    {
                        Id = b.id,
                        Title = b.title,
                        Price = b.price,
                        PublisherName = b.publisher == null ? "None" : b.publisher.name
                    })
                    .ToList()
                );
            }
        }

        
        [HttpGet]
        [Route("delete")]
        public ActionResult Delete(int? id)
        {
            System.Diagnostics.Debug.WriteLine("**********GET");
            System.Diagnostics.Debug.WriteLine("**********BookId " + id + " **");
            if (id != null)
            {
                System.Diagnostics.Debug.WriteLine("**********DB");
                MediaBdd db = new MediaBdd(); //ouverture de la bdd
                Book book = db.Books.Find(id);
                if (book != null)
                {
                    return DeleteConfirmed(book.id);
                }
            }
            return RedirectToAction("details");
        }
        
    
        [HttpPost, ActionName("delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            MediaBdd db = new MediaBdd(); //ouverture de la bdd
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();

            return RedirectToAction("details");
        }
        







    }
}