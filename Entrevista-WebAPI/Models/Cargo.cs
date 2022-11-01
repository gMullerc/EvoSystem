using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrevista_WebAPI.Models
{
    public class Cargo
    {
        public Cargo(){ }
        public Cargo(int id, string nome, int departamentoId) 
        {
            this.Id = id;
            this.Nome = nome;
            this.DepartamentoId = departamentoId;
           
   
        }
        public int Id { get; set; }

        public string Nome { get; set; }

        public int DepartamentoId {get; set;}

        public Departamento ?Departamento {get; set;}

        public IEnumerable<FuncionarioCargo> ?FuncionarioCargos { get; set; }


        
    }
}