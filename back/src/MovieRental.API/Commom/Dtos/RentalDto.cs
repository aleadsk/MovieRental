using System;
using MovieRental.API.Commom.Dtos;

namespace MovieRental.API.Commom {
    public class RentalDto : BaseDto {
        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int FKMovieId { get; set; }

        public int FKClientId { get; set; }

        public ClientDto Client { get; set; }

        public MovieDto Movie { get; set; }
    }
}