using DomainDrivenDesignArchitecture.Domain.ReturnModel;
using DomainDrivenDesignArchitecture.Infra.Helpers;
using Newtonsoft.Json;
using System;
using System.Web.Http;
using System.Web.Http.Description;

namespace DomainDrivenDesignArchitecture.API.Controllers
{
    public class BasicTokenController : ApiController
    {
        [HttpGet]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult GetGeneratedToken()
        {
            try
            {
                return Ok(new { Token = EncryptHelper.Encrypt(JsonConvert.SerializeObject(new { Date = DateTime.Now, UserId = Guid.NewGuid() }, Formatting.None)) });
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}