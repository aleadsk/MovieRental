using System;

namespace MovieRental.API.Commom {
    public class RentalDto : BaseDto {
        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int FKMovieId { get; set; }

        public int FKClientId { get; set; }

        public string ClientName { get; set; }

        public string MovieName { get; set; }
    }
}