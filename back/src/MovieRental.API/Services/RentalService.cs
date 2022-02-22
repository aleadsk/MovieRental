using System;
using System.Collections.Generic;
using System.Threading.Tasks;
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

        public async Task<bool> Change(RentalModel obj) {
            var _rentalModel = await _repository.Get(obj.Id);
            
            _rentalModel.RentalDate = obj.RentalDate;
            _rentalModel.ReturnDate = obj.ReturnDate;
            _rentalModel.FKMovieId = obj.FKMovieId;
            _rentalModel.FKClientId = obj.FKClientId;

            try {
                _repository.Update(_rentalModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> Save(RentalModel obj) {
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