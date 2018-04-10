using System;

namespace DomainDrivenDesignArchitecture.Domain.Base
{
    public class DomainInfoBase : DomainBase
    {
        public DateTimeOffset CreatedAt { get; set; }
        public DateTimeOffset UpdatedAt { get; set; }
    }
}
