namespace Web.Models.Infrastructure
{
    public interface IAuthenticationService
    {
        bool IsAuthenticated { get;  }
        string UserName { get; }
    }
}