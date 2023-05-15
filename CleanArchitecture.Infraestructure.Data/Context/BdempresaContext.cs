using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CleanArchitecture.Infraestructure.Data.Context;

public partial class BdempresaContext : DbContext
{
    public BdempresaContext()
    {
    }

    public BdempresaContext(DbContextOptions<BdempresaContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Compra> Compras { get; set; }

    public virtual DbSet<DetalleCompra> DetalleCompras { get; set; }

    public virtual DbSet<Historial> Historials { get; set; }

    public virtual DbSet<Paciente> Pacientes { get; set; }

    public virtual DbSet<Product> Products { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=JSANTOS;initial catalog=BDEmpresa;user id=sa;password=123456;Trust Server Certificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Compra>(entity =>
        {
            entity.ToTable("Compra");

            entity.Property(e => e.NumeroDocumento)
                .HasMaxLength(10)
                .IsUnicode(false);
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");
        });

        modelBuilder.Entity<DetalleCompra>(entity =>
        {
            entity.ToTable("DetalleCompra");

            entity.Property(e => e.Precio).HasColumnType("decimal(10, 2)");
            entity.Property(e => e.Producto)
                .HasMaxLength(60)
                .IsUnicode(false);
            entity.Property(e => e.Total).HasColumnType("decimal(10, 2)");

            entity.HasOne(d => d.IdCompraNavigation).WithMany(p => p.DetalleCompras)
                .HasForeignKey(d => d.IdCompra)
                .HasConstraintName("FK_IdVenta");
        });

        modelBuilder.Entity<Historial>(entity =>
        {
            entity.HasKey(e => e.IHistorialId).HasName("PK__Historia__3828AAFCA46050D5");

            entity.ToTable("Historial");

            entity.Property(e => e.IHistorialId).HasColumnName("i_historial_id");
            entity.Property(e => e.DtFecha)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dt_fecha");
            entity.Property(e => e.IPacienteId).HasColumnName("i_paciente_id");
            entity.Property(e => e.VcArea)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_area");
            entity.Property(e => e.VcDescripcion)
                .IsUnicode(false)
                .HasColumnName("vc_descripcion");
            entity.Property(e => e.VcHospital)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vc_hospital");
            entity.Property(e => e.VcMedico)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vc_medico");

            entity.HasOne(d => d.IPaciente).WithMany(p => p.Historials)
                .HasForeignKey(d => d.IPacienteId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__Historial__i_pac__46E78A0C");
        });

        modelBuilder.Entity<Paciente>(entity =>
        {
            entity.HasKey(e => e.IPacienteId).HasName("PK__Paciente__03E0394D53DC1896");

            entity.ToTable("Paciente");

            entity.Property(e => e.IPacienteId).HasColumnName("i_paciente_id");
            entity.Property(e => e.Edad).HasColumnName("edad");
            entity.Property(e => e.VcDocumento)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vc_documento");
            entity.Property(e => e.VcNombres)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vc_nombres");
        });

        modelBuilder.Entity<Product>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Product__3214EC075063047B");

            entity.ToTable("Product");

            entity.Property(e => e.Price).HasColumnType("decimal(18, 2)");
            entity.Property(e => e.ProductName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.ProductType)
                .HasMaxLength(100)
                .IsUnicode(false);
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC078F3FDA41");

            entity.Property(e => e.Address)
                .HasMaxLength(200)
                .IsUnicode(false);
            entity.Property(e => e.DocumentNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Email)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.FullName)
                .HasMaxLength(100)
                .IsUnicode(false);
            entity.Property(e => e.Password)
                .HasMaxLength(128)
                .IsUnicode(false);
            entity.Property(e => e.PhoneNumber)
                .HasMaxLength(20)
                .IsUnicode(false);
            entity.Property(e => e.Token)
                .HasMaxLength(200)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
