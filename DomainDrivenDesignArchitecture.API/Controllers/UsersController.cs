using AutoMapper;
using DomainDrivenDesignArchitecture.Domain;
using DomainDrivenDesignArchitecture.Domain.CommandModel;
using DomainDrivenDesignArchitecture.Domain.ReturnModel;
using DomainDrivenDesignArchitecture.Interface.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
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

        /// <summary>
        /// List User's
        /// </summary>
        /// <param name="options">OData Filter's</param>
        /// <remarks>Return a list of Users</remarks>
        public PageResult<UserReturn> Get(ODataQueryOptions<UserReturn> options)
        {
            var userList = Mapper.Map<List<User>, List<UserReturn>>(serviceUser.Query().ToList());

            var result = options.ApplyTo(userList.AsQueryable()).Cast<UserReturn>().ToList();

            return new PageResult<UserReturn>(
              result as IEnumerable<UserReturn>,
              Request.ODataProperties().NextLink,
              Request.ODataProperties().TotalCount);
        }

        /// <summary>
        /// Delete User's
        /// </summary>
        /// <param name="ids">Array of Ids</param>
        /// <remarks>Return a message if success or failed</remarks>
        [Authorize]
        [HttpDelete]
        [ResponseType(typeof(BaseReturn))]
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

        /// <summary>
        /// Update a User
        /// </summary>
        /// <param name="user">User's data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [Authorize]
        [HttpPut]
        [ResponseType(typeof(BaseReturn))]
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

        /// <summary>
        /// Save a User
        /// </summary>
        /// <param name="user">User's data</param>
        /// <remarks>Return a message if success or failed</remarks>
        [Authorize]
        [HttpPost]
        [ResponseType(typeof(BaseReturn))]
        public IHttpActionResult Create(SaveUserCommand user)
        {
            try
            {
                var returnModel = new BaseReturn();

                if (user == null)
                {
                    return NotFound();
                }
                else
                {
                    var map = Mapper.Map<SaveUserCommand, User>(user);

                    var valid = serviceUser.Query().Any(x => x.Login == map.Login);

                    if (!valid)
                    {
                        serviceUser.Create(map);

                        return Ok(returnModel);
                    }

                    return BadRequest("User already exists.");
                }
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

    }
}