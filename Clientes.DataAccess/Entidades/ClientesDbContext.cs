using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;

namespace Clientes.DataAccess.Entidades;

public partial class ClientesDbContext : DbContext
{

    //public Startup(IConfiguration configuration)
    //{
    //    Configuration = configuration;
    //}

    //public IConfiguration Configuration { get; }
    public ClientesDbContext()
    {
    }

    public ClientesDbContext(DbContextOptions<ClientesDbContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Cliente> Clientes { get; set; }

    //protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    //    => optionsBuilder.UseSqlServer( this.confiEnvironment.builder.Configuration.GetConnectionString("SQLConnection")));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasIndex(e => e.CorreoElectronico, "UQ_Clientes").IsUnique();

            entity.Property(e => e.Activo).HasDefaultValue(true);
            entity.Property(e => e.ApellidoMaterno).HasMaxLength(100);
            entity.Property(e => e.ApellidoPaterno).HasMaxLength(100);
            entity.Property(e => e.Ciudad).HasMaxLength(100);
            entity.Property(e => e.CodigoPostal).HasMaxLength(10);
            entity.Property(e => e.CorreoElectronico).HasMaxLength(200);
            entity.Property(e => e.Direccion).HasMaxLength(250);
            entity.Property(e => e.FechaRegistro).HasDefaultValueSql("(sysdatetime())");
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Telefono).HasMaxLength(20);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
