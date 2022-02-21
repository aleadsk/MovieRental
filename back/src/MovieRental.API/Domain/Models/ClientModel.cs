using System;

namespace MovieRental.API.Models {
    public class ClientModel : BaseModel {
        public string Name { get; set; }

        public string Cpf { get; set; }

        public DateTime BirthDate { get; set; }
    }
}