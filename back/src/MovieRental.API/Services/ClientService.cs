using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MovieRental.API.Domain.Interfaces;
using MovieRental.API.Domain.Interfaces.Services;
using MovieRental.API.Models;

namespace MovieRental.API.Services {
    public class ClientService : IClientService {
        readonly IClientRepository _repository;

        public bool IsSuccess { get; set; }

        public ClientService(IClientRepository repository) {
            _repository = repository;
        }
        
        public async Task<bool> Change(ClientModel obj) {
            var _clientModel = await _repository.Get(obj.Id);
            
            _clientModel.Name = obj.Name;
            _clientModel.Cpf = obj.Cpf;
            _clientModel.BirthDate = obj.BirthDate;

            try {
                _repository.Update(_clientModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<bool> Delete(int id) {
            var _clientModel = await _repository.Get(id);
            
            try {
                _repository.Delete(_clientModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }

        public async Task<ClientModel> Get(int id) {
            return await _repository.Get(id);
        }

        public async Task<List<ClientModel>> GetAll() {
            return await _repository.GetAll();
        }

        public async Task<bool> Save(ClientModel obj) {
            try {
                ClientModel _clientModel = new ClientModel {
                    
                    Name = obj.Name,
                    Cpf = obj.Cpf,
                    BirthDate = obj.BirthDate
                 };

                _repository.Create(_clientModel);

                return await _repository.SaveChangesAsync();
            } catch (System.Exception error) {
                throw new Exception(error.Message);
            }
        }
    }
}