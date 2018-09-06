using FormationDotNet.Models;
using FormationDotNet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FormationDotNet.Controllers
{
    [RoutePrefix("test")]
    public class TestController : Controller
    {

        public String Index()
        {
            return "Page d'index";
        }




        [HttpGet]
        [Route("hello")]
        public String HelloWorld()
        {
            return "Hello World!";
        }

        [HttpGet]
        [Route("hello/{text}")]
        public String Hello(string text)
        {
            String buffer = "Bonjour " + text;
            return buffer;
        }


        [HttpGet]
        [Route("mock/{id}")]
        public MyMock Mock(int id)
        {
            return new MyMock { Titi = "Mock", Toto = id };
        }

        [HttpGet]
        [Route("aaa")]
        public String GetBook()
        {
            return "retard";
        }



        [HttpGet]
        [Route("book/{price}")]
        public List<BookTO> GetBooksByPrice(int price)
        {
            MediaBdd db = new MediaBdd();
            return db.Books
                .Where(b => b.price <= price)
                .Select(b => new BookTO
                {
                    Id = b.id,
                    Title = b.title,
                    //Price = b.price,
                    PublisherName = b.publisher == null ? "None" : b.publisher.name
                })
                .ToList();
        }


        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }
        /*
                // POST api/<controller>
                public void Post([FromBody]string value)
                {
                }

                // PUT api/<controller>/5
                public void Put(int id, [FromBody]string value)
                {
                }

                // DELETE api/<controller>/5
                public void Delete(int id)
                {
                }
                */
    }
}