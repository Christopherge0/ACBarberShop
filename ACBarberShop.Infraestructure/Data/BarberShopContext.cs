using System;
using System.Collections.Generic;
using ACBarberShop.Infraestructure.Models;
using Microsoft.EntityFrameworkCore;

namespace ACBarberShop.Infraestructure.Data;

public partial class BarberShopContext : DbContext
{
    public BarberShopContext(DbContextOptions<BarberShopContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Categoria> Categoria { get; set; }

    public virtual DbSet<Cita> Cita { get; set; }

    public virtual DbSet<Direccion> Direccion { get; set; }

    public virtual DbSet<EstadoBloqueo> EstadoBloqueo { get; set; }

    public virtual DbSet<EstadoFactura> EstadoFactura { get; set; }

    public virtual DbSet<EstadosCita> EstadosCita { get; set; }

    public virtual DbSet<Factura> Factura { get; set; }

    public virtual DbSet<FacturaProducto> FacturaProducto { get; set; }

    public virtual DbSet<FacturaServicio> FacturaServicio { get; set; }

    public virtual DbSet<Horario> Horario { get; set; }

    public virtual DbSet<Producto> Producto { get; set; }

    public virtual DbSet<Rol> Rol { get; set; }

    public virtual DbSet<Servicio> Servicio { get; set; }

    public virtual DbSet<Sucursal> Sucursal { get; set; }

    public virtual DbSet<Usuario> Usuario { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.HasKey(e => e.IdCategoria);

            entity.ToTable("categoria");

            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Nombre)
                .HasMaxLength(20)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Cita>(entity =>
        {
            entity.HasKey(e => e.IdCita).HasName("PK__cita__814F31263E5DD660");

            entity.ToTable("cita");

            entity.Property(e => e.IdCita).HasColumnName("idCita");
            entity.Property(e => e.FechaCita).HasColumnName("fechaCita");
            entity.Property(e => e.FechaCreacion)
                .HasDefaultValueSql("(getdate())")
                .HasColumnName("fechaCreacion");
            entity.Property(e => e.FechaReprogramada).HasColumnName("fechaReprogramada");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Pregunta1)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pregunta1");
            entity.Property(e => e.Pregunta2)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pregunta2");
            entity.Property(e => e.Pregunta3)
                .HasMaxLength(200)
                .IsUnicode(false)
                .HasColumnName("pregunta3");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdCliente)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cita__idCliente__403A8C7D");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cita__idEstado__412EB0B6");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdServicio)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cita__idServicio__4222D4EF");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Cita)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__cita__idSucursal__4316F928");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.IdDireccion).HasName("PK__direccio__B49878C9A77FC7DD");

            entity.ToTable("direccion");

            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.Canton)
                .HasMaxLength(100)
                .HasColumnName("canton");
            entity.Property(e => e.DireccionExacta)
                .HasMaxLength(255)
                .HasColumnName("direccionExacta");
            entity.Property(e => e.Distrito)
                .HasMaxLength(100)
                .HasColumnName("distrito");
            entity.Property(e => e.Provincia)
                .HasMaxLength(100)
                .HasColumnName("provincia");
        });

        modelBuilder.Entity<EstadoBloqueo>(entity =>
        {
            entity.HasKey(e => e.IdEstadBlokeo).HasName("PK_EstadoBloqueo");

            entity.ToTable("estadoBloqueo");

            entity.Property(e => e.IdEstadBlokeo).HasColumnName("idEstadBlokeo");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("estado");
        });

        modelBuilder.Entity<EstadoFactura>(entity =>
        {
            entity.HasKey(e => e.IdEstadoFactura);

            entity.ToTable("estadoFactura");

            entity.Property(e => e.IdEstadoFactura).HasColumnName("idEstadoFactura");
            entity.Property(e => e.Descripccion)
                .HasMaxLength(50)
                .IsFixedLength()
                .HasColumnName("descripccion");
        });

        modelBuilder.Entity<EstadosCita>(entity =>
        {
            entity.HasKey(e => e.IdEstadoCita).HasName("PK__estadosC__FDA623A1F0FC3BAA");

            entity.ToTable("estadosCita");

            entity.Property(e => e.IdEstadoCita).HasColumnName("idEstadoCita");
            entity.Property(e => e.Estado)
                .HasMaxLength(50)
                .HasColumnName("estado");
        });

        modelBuilder.Entity<Factura>(entity =>
        {
            entity.HasKey(e => e.IdFactura).HasName("PK__factura__3CD5687EED3D4295");

            entity.ToTable("factura");

            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Fecha).HasColumnName("fecha");
            entity.Property(e => e.IdCliente).HasColumnName("idCliente");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");
            entity.Property(e => e.Total)
                .HasColumnType("money")
                .HasColumnName("total");

            entity.HasOne(d => d.IdClienteNavigation).WithMany(p => p.Factura)
                .HasForeignKey(d => d.IdCliente)
                .HasConstraintName("FK__factura__idClien__440B1D61");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Factura)
                .HasForeignKey(d => d.IdEstado)
                .HasConstraintName("FK_factura_estadoFactura");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Factura)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("FK__factura__idSucur__44FF419A");
        });

        modelBuilder.Entity<FacturaProducto>(entity =>
        {
            entity.HasKey(e => e.IdFacturaProducto).HasName("PK__facturaP__C341F23500F778C0");

            entity.ToTable("facturaProducto");

            entity.Property(e => e.IdFacturaProducto).HasColumnName("idFacturaProducto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.SubTotal)
                .HasColumnType("money")
                .HasColumnName("subTotal");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.FacturaProducto)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK_facturaProducto_factura");

            entity.HasOne(d => d.IdProductoNavigation).WithMany(p => p.FacturaProducto)
                .HasForeignKey(d => d.IdProducto)
                .HasConstraintName("FK__facturaPr__idPro__46E78A0C");
        });

        modelBuilder.Entity<FacturaServicio>(entity =>
        {
            entity.HasKey(e => e.IdFacturaServicio).HasName("PK__facturaS__7C194415C4A6C6F0");

            entity.ToTable("facturaServicio");

            entity.Property(e => e.IdFacturaServicio).HasColumnName("idFacturaServicio");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.IdFactura).HasColumnName("idFactura");
            entity.Property(e => e.IdServicio).HasColumnName("idServicio");
            entity.Property(e => e.SubTotal)
                .HasColumnType("money")
                .HasColumnName("subTotal");

            entity.HasOne(d => d.IdFacturaNavigation).WithMany(p => p.FacturaServicio)
                .HasForeignKey(d => d.IdFactura)
                .HasConstraintName("FK_facturaServicio_factura");

            entity.HasOne(d => d.IdServicioNavigation).WithMany(p => p.FacturaServicio)
                .HasForeignKey(d => d.IdServicio)
                .HasConstraintName("FK__facturaSe__idSer__48CFD27E");
        });

        modelBuilder.Entity<Horario>(entity =>
        {
            entity.HasKey(e => e.IdHorario).HasName("PK__horario__3213E83FACF90431");

            entity.ToTable("horario");

            entity.Property(e => e.IdHorario).HasColumnName("idHorario");
            entity.Property(e => e.DiaSemana)
                .HasMaxLength(50)
                .HasColumnName("diaSemana");
            entity.Property(e => e.FechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.FechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.HoraFin).HasColumnName("horaFin");
            entity.Property(e => e.HoraInicio).HasColumnName("horaInicio");
            entity.Property(e => e.IdEstado).HasColumnName("idEstado");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");

            entity.HasOne(d => d.IdEstadoNavigation).WithMany(p => p.Horario)
                .HasForeignKey(d => d.IdEstado)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_horario_EstadoBloqueo");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Horario)
                .HasForeignKey(d => d.IdSucursal)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK__horario__idSucur__46E78A0C");
        });

        modelBuilder.Entity<Producto>(entity =>
        {
            entity.HasKey(e => e.IdProducto).HasName("PK__producto__07F4A132A11511DA");

            entity.ToTable("producto");

            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Cantidad).HasColumnName("cantidad");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdCategoria).HasColumnName("idCategoria");
            entity.Property(e => e.Marca)
                .HasMaxLength(100)
                .HasColumnName("marca");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Precio)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("precio");
            entity.Property(e => e.Volumen)
                .HasMaxLength(100)
                .HasColumnName("volumen");

            entity.HasOne(d => d.IdCategoriaNavigation).WithMany(p => p.Producto)
                .HasForeignKey(d => d.IdCategoria)
                .HasConstraintName("FK_producto_categoria");
        });

        modelBuilder.Entity<Rol>(entity =>
        {
            entity.HasKey(e => e.IdRol).HasName("PK__rol__3C872F763C9B0B36");

            entity.ToTable("rol");

            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.IdSevicio).HasName("PK__servicio__104D67DB8ABB447B");

            entity.ToTable("servicio");

            entity.Property(e => e.IdSevicio).HasColumnName("idSevicio");
            entity.Property(e => e.AreaEnfoque)
                .HasMaxLength(100)
                .HasColumnName("areaEnfoque");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdProducto).HasColumnName("idProducto");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Tarifa)
                .HasColumnType("decimal(10, 2)")
                .HasColumnName("tarifa");
            entity.Property(e => e.TiempoServicio).HasColumnName("tiempoServicio");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.IdSucursal).HasName("PK__sucursal__F707694C84DBA206");

            entity.ToTable("sucursal");

            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.Descripcion)
                .HasMaxLength(255)
                .HasColumnName("descripcion");
            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Sucursal)
                .HasForeignKey(d => d.IdDireccion)
                .HasConstraintName("FK__sucursal__idDire__4D94879B");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.IdUsuario).HasName("PK__usuario__645723A6F88648A2");

            entity.ToTable("usuario");

            entity.Property(e => e.IdUsuario).HasColumnName("idUsuario");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(255)
                .HasColumnName("contrasenia");
            entity.Property(e => e.CorreoElectronico)
                .HasMaxLength(100)
                .HasColumnName("correoElectronico");
            entity.Property(e => e.FechaNacimiento).HasColumnName("fechaNacimiento");
            entity.Property(e => e.IdDireccion).HasColumnName("idDireccion");
            entity.Property(e => e.IdRol).HasColumnName("idRol");
            entity.Property(e => e.IdSucursal).HasColumnName("idSucursal");
            entity.Property(e => e.Nombre)
                .HasMaxLength(100)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(20)
                .HasColumnName("telefono");

            entity.HasOne(d => d.IdDireccionNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdDireccion)
                .HasConstraintName("FK__usuario__idDirec__4E88ABD4");

            entity.HasOne(d => d.IdRolNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdRol)
                .HasConstraintName("FK__usuario__idRol__4F7CD00D");

            entity.HasOne(d => d.IdSucursalNavigation).WithMany(p => p.Usuario)
                .HasForeignKey(d => d.IdSucursal)
                .HasConstraintName("FK_usuario_sucursal");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
