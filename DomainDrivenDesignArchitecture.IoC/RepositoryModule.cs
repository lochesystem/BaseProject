using DomainDrivenDesignArchitecture.Interface.Repository;
using DomainDrivenDesignArchitecture.Repository.Repository;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesignArchitecture.IoC
{
    public class RepositoryModule
    {
        public static Dictionary<Type, Type> GetTypes()
        {
            var ioc = new Dictionary<Type, Type>
            {

                #region A

                #endregion

                #region E

                #endregion

                #region S

                #endregion

                #region P

                #endregion

                #region L

                #endregion

                #region M

                #endregion

                #region U

                {typeof(IRepositoryUser), typeof(RepositoryUser)},

                #endregion
            };
            return ioc;
        }
    }
}
