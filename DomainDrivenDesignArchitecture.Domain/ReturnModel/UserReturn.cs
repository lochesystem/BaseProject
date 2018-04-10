using System;

namespace DomainDrivenDesignArchitecture.Domain.ReturnModel
{
    public class UserReturn : BaseReturn
    {
        public string Login { get; set; }

        public string Password { get; set; }

        public bool FirstAccess { get; set; }

        public DateTimeOffset? UserLastAccess { get; set; }
    }
}
