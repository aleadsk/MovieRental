using System;

namespace MovieRental.API.Models {
    public class MovieModel : BaseModel {
        public string Title { get; set; }

        public int ParentalRating { get; set; }

        public DateTime LauchMovie { get; set; }
    }
}