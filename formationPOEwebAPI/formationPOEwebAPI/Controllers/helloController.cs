using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace formationPOEwebAPI
{
    [RoutePrefix("api")]
    public class helloController : ApiController
    {

        [HttpGet]
        [Route("hello")]
        public String HelloWorld()
        {
            return "hello world";
        }

        [HttpGet]
        [Route("hello/{text}")]
        public String Hello(string text)
        {
            return "hello " + text;
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