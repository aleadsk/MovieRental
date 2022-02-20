using Microsoft.AspNetCore.Mvc;

namespace MovieRental.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController {
        [HttpGet]
        public string get() {
            return "Meu primeiro Método";
        }     

        [HttpPost]
        public string post() {
            return "Meu primeiro post";
        }   

        [HttpDelete]
        public string delete() {
            return "Meu primeiro delete";
        }
    }
}