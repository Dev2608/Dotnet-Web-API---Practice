using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.Owin.Security.OAuth;
using System.Security.Claims;
using System.Threading.Tasks;
using WebApiOauth.Models;
using System.Web.Security;
using System.Data.SqlClient;

namespace WebApiOauth
{
    // override this bcoz to get the functionalities of OAuth Authorization server in our api.
    public class Class1 : OAuthAuthorizationServerProvider
    {
        newCheckingEntities db = new newCheckingEntities();


        // override this method to validate the client application.
        public override async Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();  // means we have validated the client
        }

        // in this, we will validate the credintial of user
        // if we found valid user, then we will generate token for that user.
        public override async Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var identity = new ClaimsIdentity(context.Options.AuthenticationType);


            //MembershipUser newUser = Membership.CreateUser(context.UserName, context.Password);

            //if (Membership.ValidateUser(context.UserName, context.Password))
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            //    context.Validated(identity);
            //}
            if (db.loginDetails.Any(
                loginDetail => loginDetail.username.Equals(context.UserName, StringComparison.OrdinalIgnoreCase) &&
                loginDetail.password.Equals(context.Password)
                ))
            {
                identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
                context.Validated(identity);
            }
            //if (MembershipProvider.Equals(context.UserName, context.Password))
            //{
            //    identity.AddClaim(new Claim(ClaimTypes.Name, context.UserName));
            //    context.Validated(identity);
            //}
            else
            {
                context.SetError("invalid grant", "provided username and password is incorrect");
            }

        }
    }
}