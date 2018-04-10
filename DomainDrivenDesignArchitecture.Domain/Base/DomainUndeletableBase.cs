namespace DomainDrivenDesignArchitecture.Domain.Base
{
    public class DomainUndeletableBase : DomainInfoBase
    {
        public bool Deleted { get; set; }
    }
}
