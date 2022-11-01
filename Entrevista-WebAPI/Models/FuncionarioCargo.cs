using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Entrevista_WebAPI.Models
{
    public class FuncionarioCargo
    {
        public FuncionarioCargo(){}
        public FuncionarioCargo(int funcionarioId, int cargoId) 
        {
            this.FuncionarioId = funcionarioId;
            this.CargoId = cargoId;
   
        }
        public int FuncionarioId { get; set; }
        public Funcionario Funcionario { get; set; }
        public int CargoId { get; set; }
        public Cargo Cargo { get; set; }

        


    }
}