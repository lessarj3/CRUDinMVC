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
        public IEnumerable<Mix> Get()
        {
            return _mixRepository.GetMixes();
        }

        // GET api/mixes/5
        public Mix Get(int id)
        {
            return _mixRepository.GetMixes().Where(m => m.Id == id).FirstOrDefault();
        }

        // POST api/mixes
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

        // PUT api/mixes/
        public HttpResponseMessage Put([FromBody]Mix mix)
        {
            _mixRepository.UpdateDetails(mix);
            return Request.CreateResponse(HttpStatusCode.OK);
        }

        // DELETE api/mixes/5
        public HttpResponseMessage Delete(int id)
        {
            _mixRepository.DeleteMix(id);
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}