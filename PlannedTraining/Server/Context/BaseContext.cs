using Microsoft.EntityFrameworkCore;
using PlannedTraining.Shared.Models;
using System.Collections.Generic;

namespace PlannedTraining.Server.Context
{
    public class BaseContext : DbContext
    {
        private readonly string _connection;

        public BaseContext(string connection)
        {
            _connection = connection;
        }
        public BaseContext(DbContextOptions<BaseContext> options) : base(options)
        {
            this.ChangeTracker.LazyLoadingEnabled = false;
        }

        public virtual DbSet<Aluno> Alunos { get; set; }
        public virtual DbSet<Endereco> Enderecos { get; set; }
        public virtual DbSet<Exercicio> Exercicios { get; set; }
        public virtual DbSet<Treino> Treinos { get; set; }
        public virtual DbSet<Mensalidade> Mensalidades { get; set; }
    }
}
