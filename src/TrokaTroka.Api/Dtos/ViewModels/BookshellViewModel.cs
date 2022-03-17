using System;
using System.Collections.Generic;

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

        public Guid Id { get; private set; }
        public string Title { get; private set; }
        public string Owner { get; private set; }
        public int Rate { get; private set; }
        public string Path { get; private set; }
    }
}