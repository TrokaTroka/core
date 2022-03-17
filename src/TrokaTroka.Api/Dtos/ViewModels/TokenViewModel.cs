using System;

namespace TrokaTroka.Api.Dtos.ViewModels
{
    public class TokenViewModel
    {
        public UserViewModel User { get; set; }
        public string Token { get; set; }
        public Guid RefreshToken { get; set; }
        public DateTime Expiration { get; set; }
    }
}