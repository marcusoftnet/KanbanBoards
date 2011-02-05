using System;

namespace Web.Models.Infrastructure
{
    public class KanbanAuthenticationService : IAuthenticationService
    {
        public bool IsAuthenticated
        {
            get { throw new NotImplementedException(); }
        }

        public string UserName
        {
            get { throw new NotImplementedException(); }
        }
    }
}