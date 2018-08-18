using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace Mdt10.WebApi.Controllers
{
    public class ValuesController : ApiController
    {

        public ValuesController() { }


        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/values
        //public void Post([FromBody]string value)
        //{
        //}

        [HttpPost]
        public HttpResponseMessage Post([FromBody]object p)
        {
        //    if (p == null)
        //        return new HttpResponseMessage(HttpStatusCode.BadRequest);

           // _products.Add(p);
            return new HttpResponseMessage(HttpStatusCode.Created);
        }


        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}