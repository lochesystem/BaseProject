using DomainDrivenDesignArchitecture.API.Filters;
using DomainDrivenDesignArchitecture.Domain.ReturnModel;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Description;
using System.Web.Http.ModelBinding;

namespace DomainDrivenDesignArchitecture.API.Controllers
{
    [APIMainFilter]
    public class BaseController : ApiController
    {
        [ApiExplorerSettings(IgnoreApi = true)]
        public BaseReturn ReturnModelError(ModelStateDictionary modelState, string msgError)
        {
            foreach (var model in modelState.Values)
            {
                var error = model.Errors.FirstOrDefault().ErrorMessage;

                if (string.IsNullOrEmpty(error))
                    error = model.Errors.FirstOrDefault().Exception.Message;

                if (string.IsNullOrEmpty(error))
                    error = msgError;

                return new BaseReturn()
                {
                    Error = true,
                    Message = error,
                };
            }

            return new BaseReturn()
            {
                Error = true,
                Message = msgError,
            };
        }
    }
}