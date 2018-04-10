using System;

namespace DomainDrivenDesignArchitecture.Infra.Attributes
{
    public class EnumAttribute : Attribute
    {
        public int Value { get; set; }
    }
}
