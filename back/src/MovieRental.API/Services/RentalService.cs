using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Commom;
using MovieRental.API.Domain.Interfaces;
using MovieRental.API.Domain.Interfaces.Services;
using MovieRental.API.Models;

namespace MovieRental.API.Services {
    public class RentalService : IRentalService {
        readonly IRentalRepository _repository;

        public bool IsSuccess { get; set; }

        public RentalService(IRentalRepository repository) {
            _repository = repository;
        }

        public async Task<RentalModel> Get(int id) {
            return await _repository.Get(id);
        }

        public async Task<List<RentalModel>> GetAll() {
            return await _repository.GetAll();
        }

        public async Task<bool> Change(RentalDto obj) {
            var _rentalDto = await _repository.Get(obj.Id);
            
            _rentalDto.RentalDate = obj.RentalDate;
            _rentalDto.ReturnDate = obj.ReturnDate;
            _rentalDto.FKMovieId = obj.FKMovieId;
            _rentalDto.FKClientId = obj.FKClientId;

            try {
                _repository.Update(_rentalDto);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> Save(RentalDto obj) {
            try {
                RentalModel _rentalModel = new RentalModel {
                    
                    RentalDate = obj.RentalDate,
                    ReturnDate = obj.ReturnDate,
                    FKMovieId = obj.FKMovieId,
                    FKClientId = obj.FKClientId,
                 };

                _repository.Create(_rentalModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> Delete(int id) {
            var _rentalModel = await _repository.Get(id);
            
            try {
                _repository.Delete(_rentalModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }
    }
}