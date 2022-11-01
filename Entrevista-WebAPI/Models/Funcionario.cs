using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrevista_WebAPI.Models
{
    public class Funcionario
    {
        public Funcionario(){}
        public Funcionario(int id, string nome, string sobrenome, string telefone) 
        {
            this.Id = id;
            this.Nome = nome;
            this.Sobrenome = sobrenome;
            this.Telefone = telefone;
        }
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Telefone { get; set; }

        public IEnumerable<FuncionarioCargo> ?FuncionariosCargos { get; set; }

    }
}