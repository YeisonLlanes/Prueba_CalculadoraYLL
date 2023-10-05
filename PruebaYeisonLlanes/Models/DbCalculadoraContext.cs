using System;
using System.Collections.Generic;
using System.Reflection.Metadata;
using Microsoft.EntityFrameworkCore;

namespace PruebaYeisonLlanes.Models;

public partial class DbCalculadoraContext : DbContext
{
    public DbCalculadoraContext()
    {
    }

    public DbCalculadoraContext(DbContextOptions<DbCalculadoraContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Historicos> Historicos { get; set; }

    public virtual DbSet<Logs> Logs { get; set; }

    public virtual DbSet<Numeros> Numeros { get; set; }

    public virtual DbSet<Operadores> Operadores { get; set; }

    public virtual DbSet<Prioridades> Prioridades { get; set; }

    public virtual DbSet<Ubicaciones> Ubicaciones { get; set; }

    public virtual DbSet<Usuarios> Usuarios { get; set; }

   public virtual DbSet<GetHistoricos> GetHistoricos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Historicos>().ToTable(tb => tb.HasTrigger("Historicos_Insert"));
        modelBuilder.Entity<Historicos>().ToTable(tb => tb.HasTrigger("Historicos_Delete"));

        modelBuilder.Entity<Historicos>(entity =>
        {
            entity.HasKey(e => e.IdHistorico);

            entity.Property(e => e.IdHistorico).HasColumnName("idHistorico");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
            entity.Property(e => e.Historico).HasColumnName("historico");
            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");

            entity.HasOne(d => d.IdUsuarioNavigation).WithMany(p => p.Historicos)
                .HasForeignKey(d => d.IdUsuario)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Historicos_Usuarios");
        });

        modelBuilder.Entity<Logs>(entity =>
        {
            entity.HasKey(e => e.IdLog);

            entity.Property(e => e.IdLog).HasColumnName("idLog");
            entity.Property(e => e.Detalle).HasColumnName("detalle");
            entity.Property(e => e.Fecha)
                .HasColumnType("date")
                .HasColumnName("fecha");
        });

        modelBuilder.Entity<Numeros>(entity =>
        {
            entity.HasKey(e => e.IdNumero);

            entity.Property(e => e.IdNumero).HasColumnName("idNumero");
            entity.Property(e => e.Numero).HasColumnName("numero");
        });

        modelBuilder.Entity<Operadores>(entity =>
        {
            entity.HasKey(e => e.IdOperador);

            entity.Property(e => e.IdOperador).HasColumnName("idOperador");
            entity.Property(e => e.IdPrioridad).HasColumnName("idPrioridad");
            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.Operador)
                .HasMaxLength(5)
                .IsFixedLength()
                .HasColumnName("operador");

            entity.HasOne(d => d.IdPrioridadNavigation).WithMany(p => p.Operadores)
                .HasForeignKey(d => d.IdPrioridad)
                .HasConstraintName("FK_Operadores_Prioridades");

            entity.HasOne(d => d.IdUbicacionNavigation).WithMany(p => p.Operadores)
                .HasForeignKey(d => d.IdUbicacion)
                .HasConstraintName("FK_Operadores_Ubicaciones");
        });

        modelBuilder.Entity<Prioridades>(entity =>
        {
            entity.HasKey(e => e.IdPrioridades);

            entity.Property(e => e.IdPrioridades).HasColumnName("idPrioridades");
            entity.Property(e => e.Prioridad)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("prioridad");
        });

        modelBuilder.Entity<Ubicaciones>(entity =>
        {
            entity.HasKey(e => e.IdUbicacion);

            entity.Property(e => e.IdUbicacion).HasColumnName("idUbicacion");
            entity.Property(e => e.Ubicacion)
                .HasMaxLength(10)
                .IsFixedLength()
                .HasColumnName("ubicacion");
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.HasKey(e => e.IdUsuario);

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Usuario).HasColumnName("usuario");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
