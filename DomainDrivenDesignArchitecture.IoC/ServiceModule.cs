using DomainDrivenDesignArchitecture.Interface.Service;
using DomainDrivenDesignArchitecture.Service.Service;
using System;
using System.Collections.Generic;

namespace DomainDrivenDesignArchitecture.IoC
{
    public class ServiceModule
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

                {typeof(IServiceUser), typeof(ServiceUser)},

                #endregion
            };
            return ioc;
        }
    }
}
