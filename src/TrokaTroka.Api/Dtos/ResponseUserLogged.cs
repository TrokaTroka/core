using System;

namespace TrokaTroka.Api.Dtos
{
    public class ResponseUserLogged
    {
        public ResponseUserLogged(Guid id, string email)
        {
            Id = id;
            Email = email;
        }

        public Guid Id { get; private set; }
        public string Email { get; private set; }
    }
}