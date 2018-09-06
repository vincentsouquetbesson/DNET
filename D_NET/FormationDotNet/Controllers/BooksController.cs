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
        public String index()
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
        public ActionResult Details(String title)
        {
            Response.Write("<script>console.log('opened window');</script>");

            MediaBdd db = new MediaBdd();

            //String title = "aie";
            if (title == null)
            {
                return View(db.Books
                    .Select(b => new BookTO
                    {
                        Id = b.id,
                        Title = b.title,
                        Price = b.price,
                        PublisherName = b.publisher == null ? "None" : b.publisher.name
                    })
                    .ToList());
    }
            else
            {
                return View(db.Books
                    .Where(b => b.title.Equals(title))
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













        [HttpPost]
        [Route("research")]
        public ActionResult Research()
        {
            Response.Write("<script>console.log('opened window');</script>");

            MediaBdd db = new MediaBdd();

            String title = "aie";
            if (title == null)
            {
                return View();
            }
            else
            {
                return View(db.Books
                    .Where(b => b.title.Equals(title))
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
        
    }
}