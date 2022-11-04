using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrevista_WebAPI.Models
{
    public class Departamento
    {
         public Departamento(){}
        public Departamento(int id, string nome) 
        {
            this.Id = id;
            this.Nome = nome;
        
   
        }
        public int Id { get; set; }

        public string Nome { get; set; }
        
        public IEnumerable<Cargo> ?Cargos {get; set;}
       
    }
}