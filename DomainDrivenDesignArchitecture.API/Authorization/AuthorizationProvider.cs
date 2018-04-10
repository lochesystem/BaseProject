using DomainDrivenDesignArchitecture.Infra.Helpers;
using DomainDrivenDesignArchitecture.Interface.Service;
using DomainDrivenDesignArchitecture.Repository;
using DomainDrivenDesignArchitecture.Repository.Repository;
using DomainDrivenDesignArchitecture.Service.Service;
using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace DomainDrivenDesignArchitecture.API.Authorization
{
    public class AuthorizationProvider : OAuthAuthorizationServerProvider
    {

        private IServiceUser _serviceAuthorization;
        //private IServiceLog _serviceLog;

        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            try
            {
                _serviceAuthorization = new ServiceUser(new RepositoryUser(new SimpleContext()));

                //_serviceLog = new ServiceLog(new RepositoryLog(new SmarketContext()));

                var account = _serviceAuthorization.Query().FirstOrDefault(x => x.Login == context.UserName);

                if (account == null)
                {
                    context.SetError("user_not_found", "");
                    return;
                }
                else
                {
                    if(account.Password != EncryptHelper.Encrypt(context.Password))
                    {
                        context.SetError("user_password_does_not_match", "");
                        return;
                    }
                }

                var identity = new ClaimsIdentity(context.Options.AuthenticationType);

                identity.AddClaim(new Claim(ClaimTypes.Name, account.Login));

                identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, ""));

                var props = new AuthenticationProperties(new Dictionary<string, string>
                {
                    {
                        "Email", context.UserName
                    }
                });
                var ticket = new AuthenticationTicket(identity, props);

                context.Validated(ticket);
            }
            catch (Exception ex)
            {
                //context.SetError("invalid_grant", GeneralMessages.GetUsersError);
            }
        }

        public override Task TokenEndpoint(OAuthTokenEndpointContext context)
        {
            foreach (KeyValuePair<string, string> property in context.Properties.Dictionary)
            {
                context.AdditionalResponseParameters.Add(property.Key, property.Value);
            }

            return Task.FromResult<object>(null);
        }
    }
}