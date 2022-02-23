using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MovieRental.API.Commom.Dtos;
using MovieRental.API.Domain.Interfaces.Services;

namespace MovieRental.API.Controllers {
    [ApiController]
    [Route("api/[controller]")]
    public class MovieController : ControllerBase {
        private readonly IMovieService _movieService;

        public MovieController(IMovieService movieService) {
            _movieService = movieService;
        } 

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> ChangeMovie([FromBody] MovieDto mdto) {
            try {

                if (!ModelState.IsValid) {
                    throw new Exception(string.Join("</br>", ModelState.Values
                                                      .SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage)));

                }

                var successfull = await _movieService.Change(mdto);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
            return Ok("Atualizado com Sucesso");
        }   

        [HttpPost("save")]
        public async Task<IActionResult> SaveMovie([FromBody] MovieDto mdto) {
            try {
                if (!ModelState.IsValid) {
                    throw new Exception(string.Join("|", ModelState.Values
                                                      .SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage)));
                }

                await _movieService.Save(mdto);
                
            } catch (System.Exception message) {
                return BadRequest($"Falha ao salvar filme! {message.Message}");
            }
            return Ok("Filme salvo");
        }   

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteMovie(int id) {
            try {
                var deleteMovie = await _movieService.Delete(id);
            } catch (System.Exception message) {                
                return BadRequest($"Falha na exclusão! {message.Message}");
            }
            return Ok("Filme deletado");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetMovieById(int id) {
            try {

                var movieResult = await _movieService.Get(id);

                if (movieResult == null) {
                    return NotFound("Não foi encontrado nenhuma filme");
                }
                
                MovieDto rmodel = new MovieDto();

                rmodel.Id = movieResult.Id;
                rmodel.Title = movieResult.Title;
                rmodel.ParentalRating = movieResult.ParentalRating;  
                rmodel.LauchMovie = movieResult.LauchMovie;                   

                return Ok(rmodel);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
        } 
        
        [HttpGet("list")]
        public async Task<IActionResult> GetAllMovie() {
            try {
                var movieResult = await _movieService.GetAll();
 
                if (movieResult.Count is 0) {
                    return NotFound("Não foi encontrado nenhum filme");
                }
                
                List<MovieDto> rmodel = new List<MovieDto>();

                foreach (var item in rmodel)
                {   
                    rmodel.Add(new MovieDto {
                        Id = item.Id,
                        Title = item.Title,
                        ParentalRating = item.ParentalRating,
                        LauchMovie = item.LauchMovie,
                    });
                }

                return Ok(rmodel);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
        }
    }
}