using System;

namespace TrokaTroka.Api.Models
{
    public class Photo : EntityBase
    {
        public Photo(string path, string name, Guid idBook)
        {
            Path = path;
            Name = name;
            IdBook = idBook;
        }

        public string Path { get; private set; }
        public string Name { get; private set; }
        public Guid IdBook { get; private set; }

        public Book Book { get; set; }

        public Photo()
        { }
    }
}