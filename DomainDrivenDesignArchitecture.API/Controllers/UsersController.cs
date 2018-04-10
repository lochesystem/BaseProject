using AutoMapper;
using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Domain.CommandModel;
using DomainDrivenDesignArchitecture.Domain.ReturnModel;
using DomainDrivenDesignArchitecture.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.OData;
using System.Web.Http.OData.Extensions;
using System.Web.Http.OData.Query;

namespace DomainDrivenDesignArchitecture.API.Controllers
{
    public class UsersController : ApiController
    {

        private IServiceUser serviceUser;

        public UsersController(IServiceUser serviceUser)
        {
            this.serviceUser = serviceUser;
        }

        public PageResult<UserReturn> Get(ODataQueryOptions<UserReturn> options)
        {
            var userList = Mapper.Map<List<User>, List<UserReturn>>(serviceUser.Query().ToList());

            var result = options.ApplyTo(userList.AsQueryable()).Cast<UserReturn>().ToList();

            return new PageResult<UserReturn>(
              result as IEnumerable<UserReturn>,
              Request.ODataProperties().NextLink,
              Request.ODataProperties().TotalCount);
        }

        [HttpDelete]
        public IHttpActionResult Delete([FromUri] Guid[] ids)
        {
            try
            {
                if (ids == null || ids.Length == 0)
                {
                    return NotFound();
                }
                else
                {
                    serviceUser.Delete(ids);

                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPut]
        public IHttpActionResult Update(SaveUserCommand user)
        {
            try
            {
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var map = Mapper.Map<SaveUserCommand, User>(user);
                    serviceUser.Update(map);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost]
        public IHttpActionResult Create(SaveUserCommand user)
        {
            try
            {
                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var map = Mapper.Map<SaveUserCommand, User>(user);
                    serviceUser.Create(map);
                    return Ok();
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}