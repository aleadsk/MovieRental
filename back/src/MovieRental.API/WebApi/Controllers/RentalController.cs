using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.API.Commom;
using MovieRental.API.Domain.Interfaces.Services;

namespace MovieRental.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class RentalController : ControllerBase {
        private readonly IRentalService _rentalService;

        public RentalController(IRentalService rentalService) {
            _rentalService = rentalService;
        }

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> ChangeRental([FromBody] RentalDto rdto) {
            try {

                if (!ModelState.IsValid) {
                    throw new Exception(string.Join("</br>", ModelState.Values
                                                      .SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage)));

                }

                var successfull = await _rentalService.Change(rdto);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
            return Ok("Atualizado com Sucesso");
        }   

        [HttpPost("save")]
        public async Task<IActionResult> SaveRental([FromBody] RentalDto rdto) {
            try {
                if (!ModelState.IsValid) {
                    throw new Exception(string.Join("|", ModelState.Values
                                                      .SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage)));
                }

                await _rentalService.Save(rdto);
                
            } catch (System.Exception message) {
                return BadRequest($"Falha ao salvar locação! {message.Message}");
            }
            return Ok("Filme alugado");
        }   

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteRental(int id) {
            try {
                var deleteRental = await _rentalService.Delete(id);
            } catch (System.Exception message) {                
                return BadRequest($"Falha na exclusão! {message.Message}");
            }
            return Ok("Filme alugado, liberado novamente");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetRentalById(int id) {
            try {

                var rentalResult = await _rentalService.Get(id);

                if (rentalResult == null) {
                    return NotFound("Não foi encontrado nenhuma Locação desejada");
                }
                
                RentalDto rmodel = new RentalDto();

                rmodel.Id = rentalResult.Id;
                rmodel.RentalDate = rentalResult.RentalDate;
                rmodel.ReturnDate = rentalResult.ReturnDate;
                rmodel.FKMovieId = rentalResult.FKMovieId;
                rmodel.FKClientId = rentalResult.FKClientId;                    

                return Ok(rmodel);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
        } 
        
        [HttpGet("list")]
        public async Task<IActionResult> GetAllRental() {
            try {
                var rentalResult = await _rentalService.GetAll();
 
                if (rentalResult.Count is 0) {
                    return NotFound("Não foi encontrado nenhuma Locação");
                }
                
                List<RentalDto> rmodel = new List<RentalDto>();

                foreach (var item in rmodel)
                {   
                    rmodel.Add(new RentalDto {
                        Id = item.Id,
                        RentalDate = item.RentalDate,
                        ReturnDate = item.ReturnDate,
                        FKMovieId = item.FKMovieId,
                        FKClientId = item.FKClientId, 
                    });
                }

                return Ok(rmodel);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
        }
    }
}