using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace EjemploEntity.Models;

public partial class VentasContext : DbContext
{
    public VentasContext()
    {
    }

    public VentasContext(DbContextOptions<VentasContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Caja> Cajas { get; set; }

    public virtual DbSet<Categorium> Categoria { get; set; }

    public virtual DbSet<Ciudad> Ciudads { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<ConsultaAnioUnidade> ConsultaAnioUnidades { get; set; }

    public virtual DbSet<Ejemplo> Ejemplos { get; set; }

    public virtual DbSet<Marca> Marcas { get; set; }

    public virtual DbSet<Modelo> Modelos { get; set; }

    public virtual DbSet<Producto> Productos { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<VConsultaVtasSucursal> VConsultaVtasSucursals { get; set; }

    public virtual DbSet<Vendedor> Vendedors { get; set; }

    public virtual DbSet<Venta> Ventas { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        //optionsBuilder.UseSqlServer("Server=ASUSGIGI\\SQLEXPRESS;Database=VENTAS;Integrated Security=True;TrustServerCertificate=True");
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Caja>(entity =>
        {
            entity.ToTable("CAJA");

            entity.Property(e => e.CajaId).HasColumnName("CAJA_ID");
            entity.Property(e => e.CajaDescripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("CAJA_DESCRIPCION");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ESTADO");
        });

        modelBuilder.Entity<Categorium>(entity =>
        {
            entity.HasKey(e => e.CategId);

            entity.ToTable("CATEGORIA");

            entity.Property(e => e.CategId).HasColumnName("CATEG_ID");
            entity.Property(e => e.CategNombre)
                .HasMaxLength(255)
                .HasColumnName("CATEG_NOMBRE");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
        });

        modelBuilder.Entity<Ciudad>(entity =>
        {
            entity.ToTable("CIUDAD");

            entity.Property(e => e.CiudadId).HasColumnName("CIUDAD_ID");
            entity.Property(e => e.CiudadNombre)
                .HasMaxLength(255)
                .HasColumnName("CIUDAD_NOMBRE");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.ToTable("CLIENTE");

            entity.Property(e => e.ClienteId).HasColumnName("CLIENTE_ID");
            entity.Property(e => e.Cedula).HasColumnName("CEDULA");
            entity.Property(e => e.ClienteNombre)
                .HasMaxLength(255)
                .HasColumnName("CLIENTE_NOMBRE");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
        });

        modelBuilder.Entity<ConsultaAnioUnidade>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("CONSULTA_ANIO_UNIDADES");

            entity.Property(e => e.Anio).HasColumnName("anio");
            entity.Property(e => e.Unidades).HasColumnName("UNIDADES");
        });

        modelBuilder.Entity<Ejemplo>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__Ejemplo__3214EC27A8CFAC28");

            entity.ToTable("Ejemplo");

            entity.Property(e => e.Id).HasColumnName("ID");
            entity.Property(e => e.Nombre).HasMaxLength(100);
        });

        modelBuilder.Entity<Marca>(entity =>
        {
            entity.ToTable("MARCA");

            entity.Property(e => e.MarcaId).HasColumnName("MARCA_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.MarcaNombre)
                .HasMaxLength(255)
                .HasColumnName("MARCA_NOMBRE");
        });

        modelBuilder.Entity<Modelo>(entity =>
        {
            entity.ToTable("MODELO");

            entity.Property(e => e.ModeloId).HasColumnName("MODELO_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.ModeloDescripción)
                .HasMaxLength(255)
                .HasColumnName("MODELO_DESCRIPCIÓN");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.ToTable("PRODUCTO");

            entity.Property(e => e.ProductoId).HasColumnName("PRODUCTO_ID");
            entity.Property(e => e.CategId).HasColumnName("CATEG_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.MarcaId).HasColumnName("MARCA_ID");
            entity.Property(e => e.ModeloId).HasColumnName("MODELO_ID");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("PRECIO");
            entity.Property(e => e.ProductoDescrip)
                .HasMaxLength(255)
                .HasColumnName("PRODUCTO_DESCRIP");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.SucursalId).HasName("PK_SUCURSAL$");

            entity.ToTable("SUCURSAL");

            entity.Property(e => e.SucursalId).HasColumnName("SUCURSAL_ID");
            entity.Property(e => e.CiudadId).HasColumnName("CIUDAD_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(255)
                .HasColumnName("ESTADO");
            entity.Property(e => e.FechaHoraReg)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA_REG");
            entity.Property(e => e.SucursalNombre)
                .HasMaxLength(255)
                .HasColumnName("SUCURSAL_NOMBRE");

            entity.HasOne(d => d.Ciudad).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.CiudadId)
                .HasConstraintName("FK_SUCURSAL$_CIUDAD");
        });

        modelBuilder.Entity<VConsultaVtasSucursal>(entity =>
        {
            entity
                .HasNoKey()
                .ToView("V_CONSULTA_VTAS_SUCURSAL");

            entity.Property(e => e.Registros).HasColumnName("REGISTROS");
            entity.Property(e => e.SucursalNombre)
                .HasMaxLength(255)
                .HasColumnName("SUCURSAL_NOMBRE");
            entity.Property(e => e.UnidadesVendidas).HasColumnName("UNIDADES_VENDIDAS");
            entity.Property(e => e.UsdVenta).HasColumnName("USD_VENTA");
        });

        modelBuilder.Entity<Vendedor>(entity =>
        {
            entity.ToTable("VENDEDOR");

            entity.Property(e => e.VendedorId).HasColumnName("VENDEDOR_ID");
            entity.Property(e => e.Estado)
                .HasMaxLength(1)
                .IsUnicode(false)
                .IsFixedLength()
                .HasColumnName("ESTADO");
            entity.Property(e => e.VendedorDescripcion)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("VENDEDOR_DESCRIPCION");
        });

        modelBuilder.Entity<Venta>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK_VENTAS$");

            entity.ToTable("VENTAS");

            entity.HasIndex(e => e.FechaHora, "INDICE1");

            entity.Property(e => e.IdFactura).HasColumnName("ID_FACTURA");
            entity.Property(e => e.CajaId).HasColumnName("CAJA_ID");
            entity.Property(e => e.CategId).HasColumnName("CATEG_ID");
            entity.Property(e => e.ClienteId).HasColumnName("CLIENTE_ID");
            entity.Property(e => e.Estado).HasColumnName("ESTADO");
            entity.Property(e => e.FechaHora)
                .HasColumnType("datetime")
                .HasColumnName("FECHA_HORA");
            entity.Property(e => e.MarcaId).HasColumnName("MARCA_ID");
            entity.Property(e => e.ModeloId).HasColumnName("MODELO_ID");
            entity.Property(e => e.NumFact)
                .HasMaxLength(255)
                .HasColumnName("NUM_FACT");
            entity.Property(e => e.Precio).HasColumnName("PRECIO");
            entity.Property(e => e.ProductoId).HasColumnName("PRODUCTO_ID");
            entity.Property(e => e.SucursalId).HasColumnName("SUCURSAL_ID");
            entity.Property(e => e.Unidades).HasColumnName("UNIDADES");
            entity.Property(e => e.VendedorId).HasColumnName("VENDEDOR_ID");

            entity.HasOne(d => d.Caja).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CajaId)
                .HasConstraintName("FK_VENTAS_CAJA");

            entity.HasOne(d => d.Categ).WithMany(p => p.Venta)
                .HasForeignKey(d => d.CategId)
                .HasConstraintName("FK_CATEGORIA_VENTAS");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK_VENTAS_CLIENTE");

            entity.HasOne(d => d.Marca).WithMany(p => p.Venta)
                .HasForeignKey(d => d.MarcaId)
                .HasConstraintName("FK_MARCA_VENTAS");

            entity.HasOne(d => d.Modelo).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ModeloId)
                .HasConstraintName("FK_MODELO_VENTAS");

            entity.HasOne(d => d.Producto).WithMany(p => p.Venta)
                .HasForeignKey(d => d.ProductoId)
                .OnDelete(DeleteBehavior.Cascade)
                .HasConstraintName("FK_PRODUCTO_VENTAS");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Venta)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK_SUCURSAL_VENTAS");

            entity.HasOne(d => d.Vendedor).WithMany(p => p.Venta)
                .HasForeignKey(d => d.VendedorId)
                .HasConstraintName("FK_VENTAS_VENDEDOR");
        });
        modelBuilder.HasSequence("SEC_CAJA");

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
