using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Commom.Dtos;
using MovieRental.API.Domain.Interfaces;
using MovieRental.API.Domain.Interfaces.Services;
using MovieRental.API.Models;

namespace MovieRental.API.Services {
    public class MovieService : IMovieService {
        readonly IMovieRepository _repository;

        public bool IsSuccess { get; set; }

        public MovieService(IMovieRepository repository) {
            _repository = repository;
        }
        
        public async Task<bool> Change(MovieDto obj) {
            var _movieDto = await _repository.Get(obj.Id);
            
            _movieDto.Title = obj.Title;
            _movieDto.ParentalRating = obj.ParentalRating;
            _movieDto.LauchMovie = obj.LauchMovie;

            try {
                _repository.Update(_movieDto);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> Delete(int id) {
            var _movieModel = await _repository.Get(id);
            
            try {
                _repository.Delete(_movieModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<MovieModel> Get(int id) {
            return await _repository.Get(id);
        }

        public async Task<List<MovieModel>> GetAll() {
            return await _repository.GetAll();
        }

        public async Task<bool> Save(MovieDto obj) {
            try {
                MovieModel _movieModel = new MovieModel {
                    
                    Title = obj.Title,
                    ParentalRating = obj.ParentalRating,
                    LauchMovie = obj.LauchMovie
                 };

                _repository.Create(_movieModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<List<MovieModel>> GetNeverRentalMovie() {
            return await _repository.GetNeverRentalMovies();
        }
    }
}