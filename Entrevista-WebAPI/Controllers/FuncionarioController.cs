using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrevista_WebAPI.Data;
using Entrevista_WebAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace Entrevista_WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class FuncionarioController : ControllerBase
    {
        

        private readonly IRepository _repo;
        public FuncionarioController(IRepository repo)
        {
            _repo = repo;
            
        }

        [HttpGet]
        public async Task< IActionResult >Get(){
            try
            {
                var result = await _repo.GetAllFuncionariosAsync(true) ;
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            
        } 
        [HttpGet("{FuncionarioId}")]
        public async Task<IActionResult>GetByFuncionarioId (int FuncionarioId){
            try
            {
                var result = await _repo.GetFuncionarioAsyncById(FuncionarioId, true) ;
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
            
        } 

        [HttpGet("ByCargo/{CargoId}")]

        public async Task<IActionResult> GetByCargoId(int cargoId){
            try
            {
                var result = await _repo.GetFuncionariosAsyncByCargoId(cargoId, false);
                return Ok(result);
            }
            catch (Exception ex)
            {
                
                return BadRequest($"Erro: {ex.Message}");
            }
        
        }
        
    

        [HttpPost]
        public async Task<IActionResult> post(Funcionario model)
        {
            try
            {
                _repo.Add(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }

        [HttpPut ("{funcionarioId}")]
        public async Task<IActionResult> put(int funcionarioId, Funcionario model)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
                if(funcionario == null) return NotFound("Aluno Não encontrado");

            
                _repo.Update(model);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(model);
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }
        
        [HttpDelete ("{funcionarioId}")]
        public async Task<IActionResult> delete(int funcionarioId)
        {
            try
            {
                var funcionario = await _repo.GetFuncionarioAsyncById(funcionarioId, false);
                if(funcionario == null) return NotFound();

            
                _repo.Delete(funcionario);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok(new {message = "Deletado"});
                }                
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }

            return BadRequest();
        }




    }
        
}