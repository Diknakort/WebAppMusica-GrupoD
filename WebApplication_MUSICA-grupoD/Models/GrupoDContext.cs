using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace WebApplication_MUSICA_grupoD.Models;

public partial class GrupoDContext : DbContext
{
    public GrupoDContext()
    {
    }

    public GrupoDContext(DbContextOptions<GrupoDContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Artistas> Artistas { get; set; }

    public virtual DbSet<Canciones> Canciones { get; set; }

    public virtual DbSet<Colaboraciones> Colaboraciones { get; set; }

    public virtual DbSet<Conciertos> Conciertos { get; set; }

    public virtual DbSet<Discos> Discos { get; set; }

    public virtual DbSet<Generos> Generos { get; set; }

    public virtual DbSet<Giras> Giras { get; set; }

    public virtual DbSet<Grupos> Grupos { get; set; }

    public virtual DbSet<Managers> Managers { get; set; }

    public virtual DbSet<Roles> Roles { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
        => optionsBuilder.UseSqlServer("server=musicagrupos.database.windows.net;database=GrupoD;user=as;password=P0t@t0P0t@t0");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Artistas>(entity =>
        {
            entity.Property(e => e.Fecha_Nacimiento).HasColumnName("Fecha Nacimiento");
            entity.Property(e => e.Nombre_Artistico)
                .HasMaxLength(50)
                .HasColumnName("Nombre Artistico");
            entity.Property(e => e.Nombre_Real)
                .HasMaxLength(50)
                .HasColumnName("Nombre Real");

            entity.HasOne(d => d.RolPrincipalNavigation).WithMany(p => p.Artistas)
                .HasForeignKey(d => d.RolPrincipal)
                .HasConstraintName("FK_Artistas_Roles");
        });

        modelBuilder.Entity<Canciones>(entity =>
        {
            entity.Property(e => e.Titulo).HasMaxLength(50);

            entity.HasOne(d => d.Discos).WithMany(p => p.Canciones)
                .HasForeignKey(d => d.DiscosID)
                .HasConstraintName("FK_Canciones_Discos");
        });

        modelBuilder.Entity<Colaboraciones>(entity =>
        {
            entity.HasOne(d => d.Artistas).WithMany(p => p.Colaboraciones)
                .HasForeignKey(d => d.ArtistasID)
                .HasConstraintName("FK_Colaboraciones_Artistas");

            entity.HasOne(d => d.Grupos).WithMany(p => p.Colaboraciones)
                .HasForeignKey(d => d.GruposID)
                .HasConstraintName("FK_Colaboraciones_Grupos");
        });

        modelBuilder.Entity<Conciertos>(entity =>
        {
            entity.Property(e => e.Ciudad).HasMaxLength(50);
            entity.Property(e => e.FechaHora).HasColumnType("datetime");
            entity.Property(e => e.Precio).HasColumnType("money");

            entity.HasOne(d => d.Giras).WithMany(p => p.Conciertos)
                .HasForeignKey(d => d.GirasID)
                .HasConstraintName("FK_Conciertos_Giras");

            entity.HasOne(d => d.Grupos).WithMany(p => p.Conciertos)
                .HasForeignKey(d => d.GruposID)
                .HasConstraintName("FK_Conciertos_Grupos");
        });

        modelBuilder.Entity<Discos>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Genero).WithMany(p => p.Discos)
                .HasForeignKey(d => d.GeneroID)
                .HasConstraintName("FK_Discos_Generos");

            entity.HasOne(d => d.Grupos).WithMany(p => p.Discos)
                .HasForeignKey(d => d.GruposId)
                .HasConstraintName("FK_Discos_Grupos");
        });

        modelBuilder.Entity<Generos>(entity =>
        {
            entity.Property(e => e.Id).ValueGeneratedNever();
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        modelBuilder.Entity<Giras>(entity =>
        {
            entity.Property(e => e.Fecha_Final).HasColumnName("Fecha Final");
            entity.Property(e => e.Fecha_Inicio).HasColumnName("Fecha Inicio");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Grupos>(entity =>
        {
            entity.Property(e => e.Nombre).HasMaxLength(50);

            entity.HasOne(d => d.Managers).WithMany(p => p.Grupos)
                .HasForeignKey(d => d.ManagersID)
                .HasConstraintName("FK_Grupos_Managers");
        });

        modelBuilder.Entity<Managers>(entity =>
        {
            entity.Property(e => e.Fecha_Nacimiento).HasColumnName("Fecha Nacimiento");
            entity.Property(e => e.Nombre).HasMaxLength(50);
        });

        modelBuilder.Entity<Roles>(entity =>
        {
            entity.Property(e => e.Nombre)
                .HasMaxLength(50)
                .IsUnicode(false);
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
