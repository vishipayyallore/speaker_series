using System;
using System.Collections.Generic;
using System.Text;

namespace RetrieveJwtTokeUsingRestSharp
{
    public class UserAuthorization
    {
        public string Token { get; set; }

        public DateTime Expiration { get; set; }
    }
}
