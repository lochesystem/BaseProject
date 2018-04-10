using DomainDrivenDesignArchitecture.Infra.Helpers;
using System;

namespace DomainDrivenDesignArchitecture.Infra.Attributes
{

    public class DescriptionAttribute : EnumAttribute
    {
        public DescriptionAttribute()
        {
            Description = string.Empty;
        }

        private string description;
        public string Description
        {
            get
            {
                if (ResourceType != null && !String.IsNullOrEmpty(description) && ResourceHelper.IsThere(ResourceType, description))
                    description = ResourceHelper.GetString(ResourceType, description);

                return description;
            }
            set
            {
                description = value;
            }
        }

        /// <summary>Este tipo de recurso deverá ser usado para todas as propriedades que necessitem de tradução</summary>
        public Type ResourceType { get; set; }
    }
}
