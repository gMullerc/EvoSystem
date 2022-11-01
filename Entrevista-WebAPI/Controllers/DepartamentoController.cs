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
    public class DepartamentoController : ControllerBase
    {
        private readonly IRepository _repo;

        public DepartamentoController(IRepository repo)
        {
            _repo = repo;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var result = await _repo.GetAllDepartamentosAsync(true);

                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("{DepartamentoId}")]
        public async Task<IActionResult> GetByDepartamentoId(int DepartamentoId)
        {
            try
            {
                var result = await _repo.GetDepartamentoAsyncById(DepartamentoId, true);
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpGet("ByFuncionario/{FuncionarioId}")]
        public async Task<IActionResult> GetByFuncionarioId(int funcionarioId)
        {
            try
            {
                var result = await _repo.GetDepartamentosAsyncByFuncionarioId(funcionarioId, true);
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest($"Erro: {ex.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> post(Departamento model)
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
        [HttpPut("{departamentoId}")]

        public async Task<IActionResult> put(int departamentoId, Departamento model)
        {
            try
            {
                var Departamento = await _repo.GetDepartamentoAsyncById(departamentoId, false);
                if(Departamento == null) return NotFound();

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

        [HttpDelete("{departamentoId}")]

        public async Task<IActionResult> delete(int departamentoId)
        {
            try
            {
                var Departamento = await _repo.GetDepartamentoAsyncById(departamentoId, false);
                if(Departamento == null) return NotFound();

                _repo.Delete(Departamento);

                if(await _repo.SaveChangesAsync())
                {
                    return Ok("Deletado");
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