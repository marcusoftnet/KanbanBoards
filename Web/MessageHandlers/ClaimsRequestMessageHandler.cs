using DotNetOpenAuth.OpenId.Extensions.SimpleRegistration;
using MvcContrib.PortableAreas;
using OpenIdPortableArea.Messages;

namespace Web.MessageHandlers
{
    public class ClaimsRequestMessageHandler : MessageHandler<ClaimsRequestMessage>
    {
        public override void Handle(ClaimsRequestMessage message)
        {
            message.Claim.Email = DemandLevel.Require;
            message.Claim.FullName = DemandLevel.Require;
        }
    }
}