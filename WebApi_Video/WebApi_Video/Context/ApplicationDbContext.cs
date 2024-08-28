using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi_Video.Models;

namespace WebApi_Video.Context
{

    public class ApplicationDbContext : DbContext
    {

        // Construtor que instancia o banco de dados (entity.Framework)
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        // Especifica a tabela que vai ser criada no banco de dados 
        public DbSet<FuncionarioModel> Funcionarios { get; set; }


    }
}
