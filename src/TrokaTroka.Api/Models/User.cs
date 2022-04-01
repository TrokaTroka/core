﻿using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace TrokaTroka.Api.Models
{
    public class User : EntityBase
    {
        public User(string email, string password, string name, string document)
        {
            Email = email;
            Password = password;
            Name = name;
            Document = document;
        }
        public User(string email, string password, string name)
        {
            Email = email;
            Password = password;
            Name = name;
        }

        public string Email { get; private set; }
        public string Password { get; private set; }
        public string Name { get; private set; }
        public string Document { get; private set; }
        public string AvatarName { get; private set; }
        public string AvatarPath { get; private set; }


        public void UpdateUser(string name, string document, string email)
        {
            Name = name ?? Name;
            Email = email ?? Email;

            UnmaskDocument(document);
            Update();
        }
        public void UpdateAvatar(string avatarName, string avatarPath)
        {
            AvatarName = avatarName ?? AvatarName;
            AvatarPath = avatarPath ?? AvatarPath;
            Update();
        }

        public void UnmaskDocument(string document)
        {
            Document = Regex.Replace(document, "[^0-9]", "");
        }

        public List<Rating> Ratings { get; set; }
        public List<Book> Books{ get; set; }

        public User()
        { }
    }
}