using System;

namespace TrokaTroka.Api.Dtos.ViewModels
{
    public class BookViewModel
    {
        public BookViewModel(Guid id, string title, string author, string isbn, string publisher, string model, string language, string reason, decimal buyPrice, DateTime buyDate, Guid idUser)
        {
            Id = id;
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

        public Guid Id { get; private set; }
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
    }
}