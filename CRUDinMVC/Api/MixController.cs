using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CathRepoCommon.Models;

namespace CRUDinMVC.Api
{
    public class MixController : ApiController
    {
        private readonly IMixRepository _mixRepository;

        public MixController()
        {
            _mixRepository = MixRepositoryFactory.Get();
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

        // POST: api/Mix/EditPellets/{id}
        [Route("api/Mix/{id}")]
        [HttpPut]
        public HttpResponseMessage Put(string Id, [FromBody]IEnumerable<Pellet> pellets)
        {
            try
            {
                _mixRepository.UpdatePellets(Id, pellets);
                return Request.CreateResponse(HttpStatusCode.Created);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}