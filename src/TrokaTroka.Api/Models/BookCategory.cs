using System;

namespace TrokaTroka.Api.Models
{
    public class BookCategory 
    { 
        public BookCategory(Guid idBook, Guid idCategory)
        {
            IdBook = idBook;
            IdCategory = idCategory;
        }

        public Guid IdBook { get; private set; }
        public Guid IdCategory { get; private set; }

        public BookCategory()
        { }
    }
}