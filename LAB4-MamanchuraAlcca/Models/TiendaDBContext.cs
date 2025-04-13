using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using Pomelo.EntityFrameworkCore.MySql.Scaffolding.Internal;

namespace LAB4_MamanchuraAlcca.Models;

public partial class TiendaDBContext : DbContext
{
    public TiendaDBContext()
    {
    }

    public TiendaDBContext(DbContextOptions<TiendaDBContext> options)
        : base(options)
    {
    }

    public virtual DbSet<categoria> categorias { get; set; }

    public virtual DbSet<cliente> clientes { get; set; }

    public virtual DbSet<detallesorden> detallesordens { get; set; }

    public virtual DbSet<Ordene> ordenes { get; set; }

    public virtual DbSet<pago> pagos { get; set; }

    public virtual DbSet<producto> productos { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseMySql("server=localhost;database=TiendaDB;user=root", Microsoft.EntityFrameworkCore.ServerVersion.Parse("8.0.30-mysql"));

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder
            .UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<categoria>(entity =>
        {
            entity.HasKey(e => e.CategoriaID).HasName("PRIMARY");

            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<cliente>(entity =>
        {
            entity.HasKey(e => e.ClienteID).HasName("PRIMARY");

            entity.Property(e => e.Correo).HasMaxLength(100);
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<detallesorden>(entity =>
        {
            entity.HasKey(e => e.DetalleID).HasName("PRIMARY");

            entity.ToTable("detallesorden");

            entity.HasIndex(e => e.OrdenID, "OrdenID");

            entity.HasIndex(e => e.ProductoID, "ProductoID");

            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.Orden).WithMany(p => p.detallesordens)
                .HasForeignKey(d => d.OrdenID)
                .HasConstraintName("detallesorden_ibfk_1");

            entity.HasOne(d => d.Producto).WithMany(p => p.detallesordens)
                .HasForeignKey(d => d.ProductoID)
                .HasConstraintName("detallesorden_ibfk_2");
        });

        modelBuilder.Entity<Ordene>(entity =>
        {
            entity.HasKey(e => e.OrdenID).HasName("PRIMARY");

            entity.HasIndex(e => e.ClienteID, "ClienteID");

            entity.Property(e => e.FechaOrden)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.Total).HasPrecision(10, 2);

            entity.HasOne(d => d.Cliente).WithMany(p => p.ordenes)
                .HasForeignKey(d => d.ClienteID)
                .HasConstraintName("ordenes_ibfk_1");
        });

        modelBuilder.Entity<pago>(entity =>
        {
            entity.HasKey(e => e.PagoID).HasName("PRIMARY");

            entity.HasIndex(e => e.OrdenID, "OrdenID");

            entity.Property(e => e.FechaPago)
                .HasDefaultValueSql("CURRENT_TIMESTAMP")
                .HasColumnType("datetime");
            entity.Property(e => e.MetodoPago).HasMaxLength(50);
            entity.Property(e => e.Monto).HasPrecision(10, 2);

            entity.HasOne(d => d.Orden).WithMany(p => p.pagos)
                .HasForeignKey(d => d.OrdenID)
                .HasConstraintName("pagos_ibfk_1");
        });

        modelBuilder.Entity<producto>(entity =>
        {
            entity.HasKey(e => e.ProductoID).HasName("PRIMARY");

            entity.HasIndex(e => e.CategoriaID, "CategoriaID");

            entity.Property(e => e.Descripcion).HasMaxLength(255);
            entity.Property(e => e.Nombre).HasMaxLength(100);
            entity.Property(e => e.Precio).HasPrecision(10, 2);

            entity.HasOne(d => d.Categoria).WithMany(p => p.productos)
                .HasForeignKey(d => d.CategoriaID)
                .HasConstraintName("productos_ibfk_1");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
