using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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
        
        public async Task<bool> Change(MovieModel obj) {
            var _movieModel = await _repository.Get(obj.Id);
            
            _movieModel.Title = obj.Title;
            _movieModel.ParentalRating = obj.ParentalRating;
            _movieModel.LauchMovie = obj.LauchMovie;

            try {
                _repository.Update(_movieModel);

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

        public async Task<bool> Save(MovieModel obj) {
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
    }
}