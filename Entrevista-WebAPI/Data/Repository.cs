using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrevista_WebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace Entrevista_WebAPI.Data
{
    public class Repository : IRepository
    {
        private readonly DataContext _context;

        public Repository(DataContext context)
        {
            _context = context;
        }
        public void Add<T>(T entity) where T : class
        {
            _context.Add(entity);
        }
        public void Update<T>(T entity) where T : class
        {
            _context.Update(entity);
        }
        public void Delete<T>(T entity) where T : class
        {
            _context.Remove(entity);
        }
        public async Task<bool> SaveChangesAsync()
        {
            return (await _context.SaveChangesAsync()) > 0;
        }

        public async Task<Funcionario[]> GetAllFuncionariosAsync(bool includeCargo = false)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeCargo)
            {
                query = query.Include(pe => pe.FuncionariosCargos)
                             .ThenInclude(ad => ad.Cargo)
                             .ThenInclude(d => d.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(c => c.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeCargo)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeCargo)
            {
                query = query.Include(a => a.FuncionariosCargos)
                             .ThenInclude(ad => ad.Cargo)
                             .ThenInclude(d => d.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.Id == funcionarioId);

            return await query.FirstOrDefaultAsync();
        }
        public async Task<Funcionario[]> GetFuncionariosAsyncByCargoId(int cargoId, bool includeCargo)
        {
            IQueryable<Funcionario> query = _context.Funcionarios;

            if (includeCargo)
            {
                query = query.Include(p => p.FuncionariosCargos)
                             .ThenInclude(ad => ad.Cargo)                             
                             .ThenInclude(d => d.Departamento);
            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.FuncionariosCargos.Any(ad => ad.CargoId == cargoId));

            return await query.ToArrayAsync();
        }

        public async Task<Departamento[]> GetDepartamentosAsyncByFuncionarioId(int funcionarioId, bool includeCargo)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeCargo)
            {
                query = query.Include(p => p.Cargos)
                            .ThenInclude(ad => ad.FuncionarioCargos)
                            .ThenInclude(d => d.Funcionario );

            }

            query = query.AsNoTracking()
                         .OrderBy(funcionario => funcionario.Id)
                         .Where(funcionario => funcionario.Cargos.Any
                                    (d => d.FuncionarioCargos.Any(ad => ad.FuncionarioId == funcionarioId)));

            return await query.ToArrayAsync();
        }

        public async Task<Departamento[]> GetAllDepartamentosAsync(bool includeCargos = true)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeCargos)
            {
                query = query.Include(c => c.Cargos);
            }

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id);

            return await query.ToArrayAsync();
        }
        public async Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeCargo = true)
        {
            IQueryable<Departamento> query = _context.Departamentos;

            if (includeCargo)
            {
                query = query.Include(pe => pe.Cargos);
            }

            query = query.AsNoTracking()
                         .OrderBy(departamento => departamento.Id)
                         .Where(departamento => departamento.Id == departamentoId);

            return await query.FirstOrDefaultAsync();
        }
    }
}