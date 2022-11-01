
using System.Threading.Tasks;
using Entrevista_WebAPI.Models;

namespace Entrevista_WebAPI.Data
{
    public interface IRepository
    {
        //GERAL
        void Add<T>(T entity) where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        Task<bool> SaveChangesAsync();

        //ALUNO
        Task<Funcionario[]> GetAllFuncionariosAsync(bool includeDepartamento);        
        Task<Funcionario[]> GetFuncionariosAsyncByCargoId(int CargoId, bool includeCargo);
        Task<Funcionario> GetFuncionarioAsyncById(int funcionarioId, bool includeDepartamento);
        
        //PROFESSOR
        Task<Departamento[]> GetAllDepartamentosAsync(bool includeFuncionario);
        Task<Departamento> GetDepartamentoAsyncById(int departamentoId, bool includeFuncionario);
        Task<Departamento[]> GetDepartamentosAsyncByFuncionarioId(int funcionarioId, bool includeCargo);
    }
}