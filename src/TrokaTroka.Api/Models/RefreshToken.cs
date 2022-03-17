using System;

namespace TrokaTroka.Api.Models
{
    public class RefreshToken : EntityBase
    {
        public RefreshToken()
        {
            Token = Guid.NewGuid();
        }

        public string Username { get; set; }
        public Guid Token { get; set; }
        public DateTime ExpirationDate { get; set; }
    }
}
