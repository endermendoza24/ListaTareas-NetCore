using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using ListaTareas.Models;

#nullable disable

namespace ListaTareas.Data
{
    public partial class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext()
        {
        }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<TblCategoriaTarea> TblCategoriaTareas { get; set; }
        public virtual DbSet<TblCategorium> TblCategoria { get; set; }
        public virtual DbSet<TblTarea> TblTareas { get; set; }
        public virtual DbSet<TblUsuario> TblUsuarios { get; set; }
        public virtual DbSet<TodoList> TodoLists { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("Data Source=.; initial catalog=TodoList; trusted_connection=yes;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Modern_Spanish_CI_AS");

            modelBuilder.Entity<TblCategoriaTarea>(entity =>
            {
                entity.HasOne(d => d.IdCategoriaNavigation)
                    .WithMany(p => p.TblCategoriaTareas)
                    .HasForeignKey(d => d.IdCategoria)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCategoriaTarea_tblCategoria");

                entity.HasOne(d => d.IdTareaNavigation)
                    .WithMany(p => p.TblCategoriaTareas)
                    .HasForeignKey(d => d.IdTarea)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblCategoriaTarea_tblTareas");
            });

            modelBuilder.Entity<TblCategorium>(entity =>
            {
                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<TblTarea>(entity =>
            {
                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);

                entity.HasOne(d => d.IdUsuarioNavigation)
                    .WithMany(p => p.TblTareas)
                    .HasForeignKey(d => d.IdUsuario)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_tblTareas_tblUsuario");
            });

            modelBuilder.Entity<TblUsuario>(entity =>
            {
                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);
            });

            modelBuilder.Entity<TodoList>(entity =>
            {
                entity.ToView("TodoList");

                entity.Property(e => e.Descripcion).IsUnicode(false);

                entity.Property(e => e.Email).IsUnicode(false);

                entity.Property(e => e.Expr1).IsUnicode(false);

                entity.Property(e => e.Nombre).IsUnicode(false);

                entity.Property(e => e.Titulo).IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
