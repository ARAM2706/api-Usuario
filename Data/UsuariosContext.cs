using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using api_Usuario.Models;

namespace api_Usuario.Data;

public partial class UsuariosContext : DbContext
{
    public UsuariosContext(DbContextOptions<UsuariosContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.HasDefaultSchema("adminDrug");

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Usuario__3213E83F5DF604D1");

            entity.ToTable("Usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClaveUsuario)
                .IsUnicode(false)
                .HasColumnName("clave_usuario");
            entity.Property(e => e.Region)
                .IsUnicode(false)
                .HasColumnName("region");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
