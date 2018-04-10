using DomainDrivenDesignArchitecture.Interface.Infra;
using DomainDrivenDesignArchitecture.Repository;
using DomainDrivenDesignArchitecture.Repository.UnitOfWork;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesignArchitecture.IoC
{
    public class InfraModule
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var ioc = new Dictionary<Type, Type>
            {
                {typeof(IContextManager), typeof(ContextManager)},
                {typeof(IUnitOfWork), typeof(UnitOfWork)},
                {typeof(IUnitOfWorkFactory), typeof(UnitOfWorkFactory)}
            };

            return ioc;
        }
    }
}
