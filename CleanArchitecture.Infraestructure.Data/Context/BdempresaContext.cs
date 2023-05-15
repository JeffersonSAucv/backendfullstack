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

    public virtual DbSet<RegistroMarcacion> RegistroMarcacions { get; set; }

    public virtual DbSet<Trabajador> Trabajadors { get; set; }

    public virtual DbSet<User> Users { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("data source=ATELLO\\ATELLO;initial catalog=BDEmpresa;user id=sa;password=012806;Trust Server Certificate=true");

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

        modelBuilder.Entity<RegistroMarcacion>(entity =>
        {
            entity.HasKey(e => e.IRegistroMarcacion).HasName("PK__Registro__2776ED975BE2A8AD");

            entity.ToTable("RegistroMarcacion");

            entity.Property(e => e.IRegistroMarcacion).HasColumnName("i_registro_marcacion");
            entity.Property(e => e.DtFechaHoraMarcacion)
                .HasColumnType("datetime")
                .HasColumnName("dt_fecha_hora_marcacion");
            entity.Property(e => e.DtFechaRegistro)
                .HasColumnType("date")
                .HasColumnName("dt_fecha_registro");
            entity.Property(e => e.IIngresoSalida).HasColumnName("i_ingreso_salida");
            entity.Property(e => e.ITrabajadorId).HasColumnName("i_trabajador_id");
        });

        modelBuilder.Entity<Trabajador>(entity =>
        {
            entity.HasKey(e => e.ITrabajadorId).HasName("PK__Trabajad__2A55D555B1DE16FF");

            entity.ToTable("Trabajador");

            entity.Property(e => e.ITrabajadorId).HasColumnName("i_trabajador_id");
            entity.Property(e => e.DtFechaIngreso)
                .HasColumnType("date")
                .HasColumnName("dt_fecha_ingreso");
            entity.Property(e => e.DtFechaNacimiento)
                .HasColumnType("date")
                .HasColumnName("dt_fecha_nacimiento");
            entity.Property(e => e.VcApellidoMaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_apellido_materno");
            entity.Property(e => e.VcApellidoPaterno)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_apellido_paterno");
            entity.Property(e => e.VcCorreo)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vc_correo");
            entity.Property(e => e.VcDireccion)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vc_direccion");
            entity.Property(e => e.VcDni)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("vc_dni");
            entity.Property(e => e.VcNombre)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("vc_nombre");
            entity.Property(e => e.VcProcedencia)
                .HasMaxLength(100)
                .IsUnicode(false)
                .HasColumnName("vc_procedencia");
            entity.Property(e => e.VcSexo)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("vc_sexo");
            entity.Property(e => e.VcTelefono)
                .HasMaxLength(20)
                .IsUnicode(false)
                .HasColumnName("vc_telefono");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Users__3214EC07B72BC022");

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
