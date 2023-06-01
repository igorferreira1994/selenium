using Microsoft.EntityFrameworkCore;
using SeleniumDomain.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SeleniumRepository.Repository
{
    public class Context : DbContext
    {
        public DbSet<Dados> Dados { get; set; }

        public Context(DbContextOptions<Context> options): base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            #region Dados          

            modelBuilder.Entity<Dados>()
                .ToTable("dados")
                .Property(p => p.Descricao)
                .HasColumnName("descricao");

            modelBuilder.Entity<Dados>()
               .ToTable("dados")
               .Property(p => p.Publicacao)
               .HasColumnName("publicacao");

            modelBuilder.Entity<Dados>()
               .ToTable("dados")
               .Property(p => p.Titulo)
               .HasColumnName("titulo");

            modelBuilder.Entity<Dados>()
               .ToTable("dados")
               .Property(p => p.Area)
               .HasColumnName("area");

            modelBuilder.Entity<Dados>()
               .ToTable("dados")
               .Property(p => p.Autor)
               .HasColumnName("autor");

            #endregion
        }

    }
}
