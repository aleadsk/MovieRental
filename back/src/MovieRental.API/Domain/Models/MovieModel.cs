using System;
using System.Collections.Generic;

namespace MovieRental.API.Models {
    public class MovieModel : BaseModel {
        public string Title { get; set; }

        public int ParentalRating { get; set; }

        public DateTime LauchMovie { get; set; }
        
        public int Rental { get; set; }

        public List<RentalModel> Rentals { get; set; } = new List<RentalModel>();
    }
}