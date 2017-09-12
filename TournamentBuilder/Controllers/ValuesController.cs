using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace TournamentBuilder.Controllers
{
    public class SecondeModel
    {
        public string Name { get; set; }
    }
    public class Model
    {
        public Guid Id { get; set; }
        public SecondeModel Seconde { get; set; }
    }
    public class ValuesController : ApiController
    {
        // GET api/values
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/values/5
        public IHttpActionResult Get(int id)
        {
            var model = new Model
            {
                Id = Guid.NewGuid(),
                Seconde = new SecondeModel {
                    Name = "SomeName"
                }
            };
            return Ok(model);
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
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
