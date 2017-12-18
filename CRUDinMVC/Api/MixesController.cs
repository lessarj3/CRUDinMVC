using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using CathRepoCommon.Models;

namespace CRUDinMVC.Api
{
    public class MixesController : ApiController
    {
        private readonly IMixRepository _mixRepository;

        public MixesController()
        {
            _mixRepository = MixRepositoryFactory.Get();
        }

        // GET api/mixes
        [HttpGet]
        [Route("api/mixes")]
        public IEnumerable<Mix> Get()
        {
            return _mixRepository.GetMixes();
        }

        // GET api/mixes/5
        [HttpGet]
        [Route("api/mixes/{id}")]
        public Mix Get(string id)
        {
            return _mixRepository.GetMixes().Where(m => m.Id == id).FirstOrDefault();
        }

        // POST api/mixes
        [HttpPost]
        [Route("api/mixes")]
        public HttpResponseMessage Post([FromBody]Mix mix)
        {
            try
            {
                _mixRepository.AddMix(mix);
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.BadRequest);
            }

            return Request.CreateResponse(HttpStatusCode.Created);
        }

        // GET api/mixes/5/pellets
        [HttpGet]
        [Route("api/mixes/{id}/pellets")]
        public IEnumerable<Pellet> GetPellets(string id)
        {
            try
            {
                var pellets = _mixRepository.GetMixes().Where(m => m.Id == id).FirstOrDefault().Pellets;
                return pellets;
            }
            catch (Exception ex)
            {
                throw;
            }

        }

        [HttpPut]
        [Route("api/mixes/{id}")]
        public HttpResponseMessage Put(string id, [FromBody]Mix mix)
        {
            _mixRepository.UpdateDetails(mix);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/mixes/5
        [HttpDelete]
        [Route("api/mixes/{id}")]
        public HttpResponseMessage Delete(string id)
        {
            _mixRepository.DeleteMix(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // PUT: api/mixes/{id}/pellets
        [Route("api/mixes/{id}/pellets")]
        [HttpPut]
        public HttpResponseMessage Put(string Id, [FromBody]IEnumerable<Pellet> pellets)
        {
            try
            {
                _mixRepository.UpdatePellets(Id, pellets);
                return Request.CreateResponse(HttpStatusCode.OK);
            }
            catch (Exception)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
        }
    }
}