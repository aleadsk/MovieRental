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
    public class ClientController : ControllerBase {
        private readonly IClientService _clientService;

        public ClientController(IClientService clientService) {
            _clientService = clientService;
        } 

        [HttpPost("edit/{id}")]
        public async Task<IActionResult> ChangeClient([FromBody] ClientDto cdto) {
            try {

                if (!ModelState.IsValid) {
                    throw new Exception(string.Join("</br>", ModelState.Values
                                                      .SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage)));

                }

                var successfull = await _clientService.Change(cdto);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
            return Ok("Atualizado com Sucesso");
        }   

        [HttpPost("save")]
        public async Task<IActionResult> SaveClient([FromBody] ClientDto cdto) {
            try {
                if (!ModelState.IsValid) {
                    throw new Exception(string.Join("|", ModelState.Values
                                                      .SelectMany(x => x.Errors)
                                                      .Select(x => x.ErrorMessage)));
                }

                await _clientService.Save(cdto);
                
            } catch (System.Exception message) {
                return BadRequest($"Falha ao salvar cliente! {message.Message}");
            }
            return Ok("Cliente cadastrado");
        }   

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> DeleteClient(int id) {
            try {
                var deleteClient = await _clientService.Delete(id);
            } catch (System.Exception message) {                
                return BadRequest($"Falha na exclusão! {message.Message}");
            }
            return Ok("Cliente deletado");
        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> GetClientById(int id) {
            try {

                var clientResult = await _clientService.Get(id);

                if (clientResult == null) {
                    return NotFound("Não foi encontrado nenhum cliente");
                }
                
                ClientDto rmodel = new ClientDto();

                rmodel.Id = clientResult.Id;
                rmodel.Name = clientResult.Name;
                rmodel.BirthDate = clientResult.BirthDate;   
                rmodel.Cpf = clientResult.Cpf;                   

                return Ok(rmodel);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
        } 
        
        [HttpGet("list")]
        public async Task<IActionResult> GetAllClient() {
            try {
                var clientResult = await _clientService.GetAll();
 
                if (clientResult.Count is 0) {
                    return NotFound("Não foi encontrado nenhum cliente");
                }
                
                List<ClientDto> rmodel = new List<ClientDto>();

                foreach (var item in rmodel)
                {   
                    rmodel.Add(new ClientDto {
                        Id = item.Id,
                        Name = item.Name,
                        BirthDate = item.BirthDate,
                        Cpf = item.Cpf,
                    });
                }

                return Ok(rmodel);
            } catch (System.Exception message) {
                return BadRequest(message.Message);
            }
        }
    }
}