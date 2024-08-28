using System.ComponentModel.DataAnnotations;
using WebApi_Video.Enums;

namespace WebApi_Video.Models
{
    public class FuncionarioModel
    {

        // Método code first criação da tabela via código 
        // Criação da tabela funcionários 

        [Key] // Reforça o uso da primary key no int ID 
        public int Id { get; set; }

        public string Nome { get; set; }

        public string Sobrenome { get; set; }

        public DepartamentoEnum Departamento { get; set; }

        public bool Ativo { get; set; }

        public TurnoEnum Turno { get; set; }

        public DateTime DataDaCriacao { get; set; } = DateTime.Now.ToLocalTime();

        public DateTime DataDeAlteracao { get; set; } = DateTime.Now.ToLocalTime();


    }
}
