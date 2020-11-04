using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace Data.Configuration
{
    public partial class ContextBase : DbContext
    {

        public ContextBase(DbContextOptions<ContextBase> options) : base(options)
        {

        }

        public ContextBase()
        {

        }

        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Usuario> Usuario { get; set; }
        public virtual DbSet<Item> Item { get; set; }
        public virtual DbSet<Orcamento> Orcamento { get; set; }
        public virtual DbSet<ItemOrcamento> ItemOrcamento { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(GetStringConectionConfig());
                optionsBuilder.EnableSensitiveDataLogging();
            }
            base.OnConfiguring(optionsBuilder);
        }

        private string GetStringConectionConfig()
        {
            string strCon = "";
            return strCon;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>(entity =>
            {
                entity.Property(e => e.ClienteId).HasColumnName("clienteId");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Endereco).HasColumnName("endereco");

            });

            modelBuilder.Entity<Usuario>(entity =>
            {
                entity.Property(e => e.UsuarioId).HasColumnName("usuarioId");
                entity.Property(e => e.Login).HasColumnName("login");
                entity.Property(e => e.Nome).HasColumnName("nome");
                entity.Property(e => e.Senha).HasColumnName("senha");
                entity.Property(e => e.Ativo).HasColumnName("ativo");

            });

            modelBuilder.Entity<Item>(entity =>
            {
                entity.Property(e => e.ItemId).HasColumnName("itemId");
                entity.Property(e => e.Descricao).HasColumnName("descricao");
                entity.Property(e => e.Valor)
                .HasColumnName("valor")
                .HasColumnType("decimal(13, 2)"); ;
                entity.Property(e => e.Ativo).HasColumnName("ativo");
            });

            modelBuilder.Entity<Orcamento>(entity => 
            {
                entity.Property(e => e.OrcamentoId).HasColumnName("orcamentoId");
                entity.Property(e => e.ClienteId).HasColumnName("clienteId");
                entity.Property(e => e.ValorTotal).HasColumnName("valorTotal")
                .HasColumnType("decimal(13, 2)");
                entity.Property(e => e.ValorDesconto).HasColumnName("valorDesconto")
                .HasColumnType("decimal(13, 2)");
                entity.Property(e => e.UsuarioCriacao).HasColumnName("usuarioCricacao");
                entity.Property(e => e.UsuarioAlteracao).HasColumnName("usuarioAlteracao");
                entity.Property(e => e.Situacao).HasColumnName("situacao");
                entity.Property(e => e.DataAlteracao).HasColumnName("dataAlteracao")
                .HasColumnType("datetime");
                entity.Property(e => e.DataOrcamento).HasColumnName("dataOrcamento")
                .HasColumnType("datetime");

            });

            modelBuilder.Entity<ItemOrcamento>(entity => {
                entity.HasKey(e => new { e.ItemId, e.OrcamentoId });
                entity.HasOne(e => e.Item).WithMany(e => e.ListItemOrcamento).HasForeignKey(e => e.ItemId);
                entity.HasOne(e => e.Orcamento).WithMany(e => e.ListItemOrcamento).HasForeignKey(e => e.OrcamentoId);
            });

        }

    }
}
