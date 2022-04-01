using System;

namespace TrokaTroka.Api.Dtos.ViewModels
{
    public class BookshellViewModel
    {
        public BookshellViewModel(Guid id, string title, string owner, int rate, string list)
        {
            Id = id;
            Title = title;
            Owner = owner;
            Rate = rate;
            Path = list;
        }
        public BookshellViewModel()
        {

        }

        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Owner { get; set; }
        public int Rate { get; set; }
        public string Path { get; set; }
    }
}