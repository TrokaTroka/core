using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http;

namespace TrokaTroka.Api.Dtos.InputModels
{
    public class CreateBookInputModel
    {
        public Guid IdCategory { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Isbn { get; set; }
        public string Publisher { get; set; }
        public string Model { get; set; }
        public string Language { get; set; }
        public string Reason { get; set; }
        public decimal BuyPrice { get; set; }
        public DateTime BuyDate { get; set; }
        public List<IFormFile> Images { get; set; }
    }

    public class CategoryId
    {
        public string IdCategory { get; set; }
    }
}