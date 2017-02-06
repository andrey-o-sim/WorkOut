using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WO.ApiServices.Models;

namespace WO.ApiServices.Controllers
{
    public class GenericDataController : ApiController
    {
        // GET: api/GenericData
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/GenericData/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/GenericData
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/GenericData/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/GenericData/5
        public void Delete(int id)
        {
        }
    }
}
