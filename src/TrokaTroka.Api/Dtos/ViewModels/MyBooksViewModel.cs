using System;

namespace TrokaTroka.Api.Dtos.ViewModels
{
    public class MyBooksViewModel
    {
        public Guid Id { get; set; }

        public string Title { get; set; }

        public string Author { get; set; }

        public string Model { get; set; }

        public string Language { get; set; }

        public decimal BuyPrice { get; set; }
    }
}
