using ava.carona.app.domains;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.repositories
{
    public class AppContext : DbContext
    {
        public DbSet<Colaborador> Colaboradores { get; set; }
        public DbSet<Carona> Caronas { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=Turma01;Trusted_Connection=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Colaborador>()
                .ToTable("colaborador");

            modelBuilder.Entity<Carona>()
                .ToTable("carona");

            modelBuilder.Entity<Carona>()
                .HasMany<Endereco>(c => c.Enderecos)
                .WithOne(e => e.Carona)
                .OnDelete(DeleteBehavior.Cascade);

            //modelBuilder.Entity<Carona>()
            //    .HasOne<Endereco>(c => c.Destino)
            //    .WithMany()
            //    .OnDelete(DeleteBehavior.Restrict);



            modelBuilder.Entity<CaronaCaroneiro>()
                .HasKey(t => new { t.CaroneiroId, t.CaronaId });


            modelBuilder.Entity<CaronaCaroneiro>()
                .HasOne(pt => pt.Carona)
                .WithMany(p => p.Caronas)
                .HasForeignKey(pt => pt.CaroneiroId)
                .OnDelete(DeleteBehavior.Cascade); 

            //modelBuilder.Entity<CaronaCaroneiro>()
            //    .HasOne(pt => pt.Caroneiro)
            //    .WithMany(p => p.Caronas)
            //    .HasForeignKey(pt => pt.CaroneiroId);
        }

        public void AtivarBaseDeDados()
        {
            Database.EnsureCreated();
        }

        public void DesativarBaseDeDados()
        {
            Database.EnsureDeleted();
        }


    }
}
