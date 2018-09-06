using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FormationPOEWebAPI
{
    [RoutePrefix("api")]
    public class BookController : ApiController
    {
     
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
            return "Hello "+text;
        }

        [HttpGet]
        [Route("mock/{id}")]
        public MyMock Mock(int id)
        {
            return new MyMock { Titi = "Mock", Toto = id };
        }

        [HttpGet]
        [Route("book/price/{price}")]
        public List<BookTO> GetBooksByPrice(double price)
        {
            Model1 db = new Model1();
            return db.Books
                .Where(b => b.Price <= price)
                .Select(b => new BookTO
                {
                    Id = b.Id,
                    Title = b.Title,
                    Price = b.Price,
                    PublisherName = b.Publisher == null ? "None" : b.Publisher.Name
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
    }
}