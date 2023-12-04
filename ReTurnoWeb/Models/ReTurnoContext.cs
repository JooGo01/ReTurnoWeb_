using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace ReTurnoWeb.Models;

public partial class ReTurnoContext : DbContext
{
    public ReTurnoContext()
    {
    }

    public ReTurnoContext(DbContextOptions<ReTurnoContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Administracion> Administracions { get; set; }

    public virtual DbSet<Atencion> Atencions { get; set; }

    public virtual DbSet<Cliente> Clientes { get; set; }

    public virtual DbSet<Direccion> Direccions { get; set; }

    public virtual DbSet<Dium> Dia { get; set; }

    public virtual DbSet<Rubro> Rubros { get; set; }

    public virtual DbSet<Servicio> Servicios { get; set; }

    public virtual DbSet<Sucursal> Sucursals { get; set; }

    public virtual DbSet<SucursalServicio> SucursalServicios { get; set; }

    public virtual DbSet<Turno> Turnos { get; set; }

    public virtual DbSet<Usuario> Usuarios { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Administracion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__administ__3213E83F182D5C83");

            entity.ToTable("administracion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Administracions)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__administr__sucur__59FA5E80");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Administracions)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__administr__usuar__5AEE82B9");
        });

        modelBuilder.Entity<Atencion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__atencion__3213E83FE236515D");

            entity.ToTable("atencion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.DiaId).HasColumnName("dia_id");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.HoraApertura).HasColumnName("hora_apertura");
            entity.Property(e => e.HoraCierre).HasColumnName("hora_cierre");
            entity.Property(e => e.PersonalServicio).HasColumnName("personal_servicio");
            entity.Property(e => e.SucursalServicioId).HasColumnName("sucursal_servicio_id");

            entity.HasOne(d => d.Dia).WithMany(p => p.Atencions)
                .HasForeignKey(d => d.DiaId)
                .HasConstraintName("FK__atencion__dia_id__6D0D32F4");

            entity.HasOne(d => d.SucursalServicio).WithMany(p => p.Atencions)
                .HasForeignKey(d => d.SucursalServicioId)
                .HasConstraintName("FK__atencion__sucurs__6E01572D");
        });

        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__cliente__3213E83FD9060B8B");

            entity.ToTable("cliente");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.RazonSocial)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("razon_social");
            entity.Property(e => e.RubroId).HasColumnName("rubro_id");
            entity.Property(e => e.UsuarioId)
                .HasDefaultValueSql("((0))")
                .HasColumnName("usuario_id");

            entity.HasOne(d => d.Rubro).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.RubroId)
                .HasConstraintName("FK__cliente__rubro_i__5165187F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Clientes)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("fk_usuario_id");
        });

        modelBuilder.Entity<Direccion>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__direccio__3213E83F18037CF4");

            entity.ToTable("direccion");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Altura).HasColumnName("altura");
            entity.Property(e => e.Calle)
                .HasMaxLength(30)
                .IsUnicode(false)
                .HasColumnName("calle");
            entity.Property(e => e.Ciudad)
                .HasMaxLength(35)
                .IsUnicode(false)
                .HasColumnName("ciudad");
            entity.Property(e => e.CodigoPostal)
                .HasMaxLength(5)
                .IsUnicode(false)
                .HasColumnName("codigo_postal");
            entity.Property(e => e.Departamento)
                .HasMaxLength(2)
                .IsUnicode(false)
                .HasColumnName("departamento");
            entity.Property(e => e.Piso).HasColumnName("piso");
            entity.Property(e => e.Provincia)
                .HasMaxLength(25)
                .IsUnicode(false)
                .HasColumnName("provincia");
        });

        modelBuilder.Entity<Dium>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__dia__3213E83F9E2A03C5");

            entity.ToTable("dia");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreDia)
                .HasMaxLength(10)
                .IsUnicode(false)
                .HasColumnName("nombre_dia");
        });

        modelBuilder.Entity<Rubro>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__rubro__3213E83F9B42FA79");

            entity.ToTable("rubro");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
        });

        modelBuilder.Entity<Servicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__servicio__3213E83F5A7170BC");

            entity.ToTable("servicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.NombreServicio)
                .HasMaxLength(50)
                .IsUnicode(false)
                .HasColumnName("nombre_servicio");
        });

        modelBuilder.Entity<Sucursal>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sucursal__3213E83F4BF3F6C8");

            entity.ToTable("sucursal");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.ClienteId).HasColumnName("cliente_id");
            entity.Property(e => e.DireccionId).HasColumnName("direccion_id");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.Telefono)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("telefono");

            entity.HasOne(d => d.Cliente).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.ClienteId)
                .HasConstraintName("FK__sucursal__client__5535A963");

            entity.HasOne(d => d.Direccion).WithMany(p => p.Sucursals)
                .HasForeignKey(d => d.DireccionId)
                .HasConstraintName("FK__sucursal__direcc__5629CD9C");
        });

        modelBuilder.Entity<SucursalServicio>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__sucursal__3213E83F04BC1537");

            entity.ToTable("sucursal_servicio");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.TiempoServicio).HasColumnName("tiempo_servicio");

            entity.HasOne(d => d.Servicio).WithMany(p => p.SucursalServicios)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK__sucursal___servi__6754599E");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.SucursalServicios)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__sucursal___sucur__66603565");
        });

        modelBuilder.Entity<Turno>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__turno__3213E83F1ADAC86D");

            entity.ToTable("turno");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.FechaFin)
                .HasColumnType("datetime")
                .HasColumnName("fecha_fin");
            entity.Property(e => e.FechaIni)
                .HasColumnType("datetime")
                .HasColumnName("fecha_ini");
            entity.Property(e => e.ServicioId).HasColumnName("servicio_id");
            entity.Property(e => e.SucursalId).HasColumnName("sucursal_id");
            entity.Property(e => e.UsuarioId).HasColumnName("usuario_id");

            entity.HasOne(d => d.Servicio).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.ServicioId)
                .HasConstraintName("FK__turno__servicio___6383C8BA");

            entity.HasOne(d => d.Sucursal).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.SucursalId)
                .HasConstraintName("FK__turno__sucursal___60A75C0F");

            entity.HasOne(d => d.Usuario).WithMany(p => p.Turnos)
                .HasForeignKey(d => d.UsuarioId)
                .HasConstraintName("FK__turno__usuario_i__619B8048");
        });

        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("PK__usuario__3213E83F7C28AF69");

            entity.ToTable("usuario");

            entity.Property(e => e.Id).HasColumnName("id");
            entity.Property(e => e.Apellido)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("apellido");
            entity.Property(e => e.Contrasenia)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("contrasenia");
            entity.Property(e => e.DireccionId).HasColumnName("direccion_id");
            entity.Property(e => e.Dni)
                .HasMaxLength(8)
                .IsUnicode(false)
                .HasColumnName("dni");
            entity.Property(e => e.Email)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("email");
            entity.Property(e => e.EstadoBaja)
                .HasDefaultValueSql("((0))")
                .HasColumnName("estado_baja");
            entity.Property(e => e.Nombre)
                .HasMaxLength(45)
                .IsUnicode(false)
                .HasColumnName("nombre");
            entity.Property(e => e.Telefono)
                .HasMaxLength(11)
                .IsUnicode(false)
                .HasColumnName("telefono");
            entity.Property(e => e.TipoUsuario)
                .HasMaxLength(1)
                .IsUnicode(false)
                .HasColumnName("tipo_usuario");

            entity.HasOne(d => d.Direccion).WithMany(p => p.Usuarios)
                .HasForeignKey(d => d.DireccionId)
                .HasConstraintName("FK__usuario__direcci__4D94879B");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
