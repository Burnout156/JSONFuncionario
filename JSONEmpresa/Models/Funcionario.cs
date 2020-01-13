using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace JSONEmpresa.Models
{
    public class Funcionario
    {
        public string nome { get; set; }
        public int idade { get; set; }
        public int salario { get; set; }

        public List<string> cursos { get; set; }

        public Funcionario()
        {
            cursos = new List<string>();
        }
    }
}