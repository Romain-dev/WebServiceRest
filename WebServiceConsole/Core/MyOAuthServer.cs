using Microsoft.Owin.Security;
using Microsoft.Owin.Security.OAuth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.SessionState;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace WebServiceConsole.Core
{
    public class MyOAuthServer : OAuthAuthorizationServerProvider
    {
        public MyOAuthServer() {}

        public MyContext db = new MyContext();

        public async override Task ValidateClientAuthentication(OAuthValidateClientAuthenticationContext context)
        {
            context.Validated();
        }

        public async override Task GrantResourceOwnerCredentials(OAuthGrantResourceOwnerCredentialsContext context)
        {
            var User = db.Users.FirstOrDefault(u => u.Name == context.UserName && u.Password == context.Password);

            if(User == null)
            {
                context.Rejected();
                context.SetError("Invalid User");
            }
            else
            {
                var id = new System.Security.Claims.ClaimsIdentity(OAuthDefaults.AuthenticationType);
                id.AddClaim(new System.Security.Claims.Claim("Id", User.Id.ToString()));
                
                var ticket = new AuthenticationTicket(id,null);
                context.Validated(ticket);
            }
        }
    }
}
