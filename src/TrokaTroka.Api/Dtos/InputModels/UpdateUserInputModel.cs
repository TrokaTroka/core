using System;
using Microsoft.AspNetCore.Http;

namespace TrokaTroka.Api.Dtos.InputModels
{
    public class UpdateUserInputModel
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Document { get; set; }
        public string Email { get; set; }
        public IFormFile Avatar { get; set; }
    }
}
