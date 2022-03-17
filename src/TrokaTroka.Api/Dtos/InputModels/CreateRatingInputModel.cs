using System;

namespace TrokaTroka.Api.Dtos.InputModels
{
    public class CreateRatingInputModel
    {
        public int Grade { get; set; }

        public string Comment { get; set; }

        public Guid IdRated { get; set; }
    }
}
