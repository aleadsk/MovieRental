using System;

namespace MovieRental.API.Models {
    public class RentalModel : BaseModel {
        public DateTime RentalDate { get; set; }

        public DateTime ReturnDate { get; set; }

        public int FKMovieId { get; set; }

        public int FKClientId { get; set; }

        public ClientModel Client { get; set; }

        public MovieModel Movie { get; set; }
    }
}