using System;

namespace TrokaTroka.Api.Dtos.ViewModels
{
    public class UserViewModel
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Document { get; set; }
        public string Name { get; set; }
        public string AvatarPath { get; set; }
    }
}
