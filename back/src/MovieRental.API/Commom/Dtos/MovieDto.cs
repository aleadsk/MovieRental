using System;
using System.Collections.Generic;

namespace MovieRental.API.Commom.Dtos {
    public class MovieDto : BaseDto {
        public string Title { get; set; }

        public int ParentalRating { get; set; }

        public DateTime LauchMovie { get; set; }

        public int Rental { get; set; }

        public List<RentalDto> Rentals { get; set; } = new List<RentalDto>();
    }
}