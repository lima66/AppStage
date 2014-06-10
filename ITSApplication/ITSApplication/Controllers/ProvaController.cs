using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ITSApplication.Controllers
{
    public class ProvaController : ApiController
    {
        // GET api/prova
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/prova/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/prova
        public void Post([FromBody]string value)
        {
        }

        // PUT api/prova/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/prova/5
        public void Delete(int id)
        {
        }
    }
}
