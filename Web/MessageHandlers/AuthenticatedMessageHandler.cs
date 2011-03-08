using System;
using System.Web;
using MvcContrib.PortableAreas;
using OpenIdPortableArea.Helpers;
using OpenIdPortableArea.Messages;

namespace Web.MessageHandlers
{
    public class AuthenticatedMessageHandler : MessageHandler<AuthenticatedMessage>
    {
        public override void Handle(AuthenticatedMessage message)
        {
            var name = "Unkown";
            var userData = string.Empty;

            if (message.ClaimsResponse != null)
            {
                name = string.IsNullOrWhiteSpace(message.ClaimsResponse.FullName) ?
                                    message.ClaimsResponse.Email : message.ClaimsResponse.FullName;
                userData = message.ClaimsResponse.Email;
            }

            OpenIdHelpers.Login(name, userData, new TimeSpan(0, 5, 0), true);
            HttpContext.Current.Session.Add("OpenIDClaimedIdentifier", message.ClaimedIdentifier);
            message.ReturnUrl = "~/";
        }
    }
}