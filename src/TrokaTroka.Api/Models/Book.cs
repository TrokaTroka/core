using System;
using System.Collections.Generic;

namespace TrokaTroka.Api.Models
{
    public class Book : EntityBase
    {
        public Book(string title, string author, string isbn, string publisher, string model, 
            string language, string reason, decimal buyPrice, DateTime buyDate, Guid idUser)
        {
            Title = title;
            Author = author;
            Isbn = isbn;
            Publisher = publisher;
            Model = model;
            Language = language;
            Reason = reason;
            BuyPrice = buyPrice;
            BuyDate = buyDate;
            IdUser = idUser;
        }

        public string Title { get; private set; } 
        public string Author { get; private set; }
        public string Isbn { get; private set; }
        public string Publisher { get; private set; }
        public string Model { get; private set; }
        public string Language { get; private set; }
        public string Reason { get; private set; }
        public decimal BuyPrice { get; private set; }
        public DateTime BuyDate { get; private set; }
        public Guid IdUser { get; private set; }
        public Guid IdTrade { get; private set; }

        public User Owner { get; set; }
        public List<Photo> Photos { get; set; }

        public Book()
        { }
    }
}