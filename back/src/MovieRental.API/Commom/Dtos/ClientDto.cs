using System;
using System.Collections.Generic;

namespace MovieRental.API.Commom.Dtos {
    public class ClientDto : BaseDto {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }

        public List<RentalDto> Rentals { get; set; } = new List<RentalDto>();
    }
}