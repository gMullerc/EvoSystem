using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Entrevista_WebAPI.Models;
using Microsoft.EntityFrameworkCore;


namespace Entrevista_WebAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }        
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Departamento> Departamentos { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<FuncionarioCargo> FuncionarioCargos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<FuncionarioCargo>()
                .HasKey(AD => new { AD.FuncionarioId, AD.CargoId });

            builder.Entity<Departamento>()
                .HasData(new List<Departamento>(){
                    new Departamento(1, "Lauro"),
                    new Departamento(2, "Roberto"),
                    new Departamento(3, "Ronaldo"),
                    new Departamento(4, "Rodrigo"),
                    new Departamento(5, "Alexandre"),
                });
            
            builder.Entity<Cargo>()
                .HasData(new List<Cargo>{
                    new Cargo(1, "Matemática", 1),
                    new Cargo(2, "Física", 2),
                    new Cargo(3, "Português", 3),
                    new Cargo(4, "Inglês", 4),
                    new Cargo(5, "Programação", 5)
                });
            
            builder.Entity<Funcionario>()
                .HasData(new List<Funcionario>(){
                    new Funcionario(1, "Marta", "Kent", "33225555"),
                    new Funcionario(2, "Paula", "Isabela", "3354288"),
                    new Funcionario(3, "Laura", "Antonia", "55668899"),
                    new Funcionario(4, "Luiza", "Maria", "6565659"),
                    new Funcionario(5, "Lucas", "Machado", "565685415"),
                    new Funcionario(6, "Pedro", "Alvares", "456454545"),
                    new Funcionario(7, "Paulo", "José", "9874512")
                });

            builder.Entity<FuncionarioCargo>()
                .HasData(new List<FuncionarioCargo>() {
                    new FuncionarioCargo() {FuncionarioId = 1, CargoId = 2 },
                    new FuncionarioCargo() {FuncionarioId = 1, CargoId = 4 },
                    new FuncionarioCargo() {FuncionarioId = 1, CargoId = 5 },
                    new FuncionarioCargo() {FuncionarioId = 2, CargoId = 1 },
                    new FuncionarioCargo() {FuncionarioId = 2, CargoId = 2 },
                    new FuncionarioCargo() {FuncionarioId = 2, CargoId = 5 },
                    new FuncionarioCargo() {FuncionarioId = 3, CargoId = 1 },
                    new FuncionarioCargo() {FuncionarioId = 3, CargoId = 2 },
                    new FuncionarioCargo() {FuncionarioId = 3, CargoId = 3 },
                    new FuncionarioCargo() {FuncionarioId = 4, CargoId = 1 },
                    new FuncionarioCargo() {FuncionarioId = 4, CargoId = 4 },
                    new FuncionarioCargo() {FuncionarioId = 4, CargoId = 5 },
                    new FuncionarioCargo() {FuncionarioId = 5, CargoId = 4 },
                    new FuncionarioCargo() {FuncionarioId = 5, CargoId = 5 },
                    new FuncionarioCargo() {FuncionarioId = 6, CargoId = 1 },
                    new FuncionarioCargo() {FuncionarioId = 6, CargoId = 2 },
                    new FuncionarioCargo() {FuncionarioId = 6, CargoId = 3 },
                    new FuncionarioCargo() {FuncionarioId = 6, CargoId = 4 },
                    new FuncionarioCargo() {FuncionarioId = 7, CargoId = 1 },
                    new FuncionarioCargo() {FuncionarioId = 7, CargoId = 2 },
                    new FuncionarioCargo() {FuncionarioId = 7, CargoId = 3 },
                    new FuncionarioCargo() {FuncionarioId = 7, CargoId = 4 },
                    new FuncionarioCargo() {FuncionarioId = 7, CargoId = 5 }
                });
        }
    }
}