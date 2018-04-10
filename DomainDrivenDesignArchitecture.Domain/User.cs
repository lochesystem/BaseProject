using DomainDrivenDesignArchitecture.Domain.Base;
using System;

namespace DomainDrivenDesignArchitecture.Domain
{
    public class User : DomainUndeletableBase
    {

        public string Login { get; set; }

        public string Password { get; set; }

        public DateTimeOffset? UserLastAccess { get; set; }

    }
}
