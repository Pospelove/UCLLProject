using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace GIP1.Web.Entities
{
    public partial class GiP1Context : DbContext
    {
        public GiP1Context()
        {
        }

        public GiP1Context(DbContextOptions<GiP1Context> options)
            : base(options)
        {
        }

        public virtual DbSet<Les> Les { get; set; }
        public virtual DbSet<Lokaal> Lokaal { get; set; }
        public virtual DbSet<Planning> Planning { get; set; }
        public virtual DbSet<Vak> Vak { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. See http://go.microsoft.com/fwlink/?LinkId=723263 for guidance on storing connection strings.
                optionsBuilder.UseSqlServer("Data Source=localhost;Initial Catalog=GiP1;Integrated Security=True");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Les>(entity =>
            {
                entity.Property(e => e.LesId)
                    .HasColumnName("LesID")
                    .ValueGeneratedNever();

                entity.Property(e => e.Lesnaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Lokaalcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Planningcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vakcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.LokaalcodeNavigation)
                    .WithMany(p => p.Les)
                    .HasForeignKey(d => d.Lokaalcode)
                    .HasConstraintName("FK_Les_Lokaal");

                entity.HasOne(d => d.PlanningcodeNavigation)
                    .WithMany(p => p.Les)
                    .HasForeignKey(d => d.Planningcode)
                    .HasConstraintName("FK_Les_Planning");

                entity.HasOne(d => d.VakcodeNavigation)
                    .WithMany(p => p.Les)
                    .HasForeignKey(d => d.Vakcode)
                    .HasConstraintName("FK_Les_Vak");
            });

            modelBuilder.Entity<Lokaal>(entity =>
            {
                entity.HasKey(e => e.Lokaalcode);

                entity.Property(e => e.Lokaalcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Locatie)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Middelen)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Opmerking)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Planning>(entity =>
            {
                entity.HasKey(e => e.Planningcode);

                entity.Property(e => e.Planningcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Datumtijd).HasColumnType("datetime");
            });

            modelBuilder.Entity<Vak>(entity =>
            {
                entity.HasKey(e => e.Vakcode);

                entity.Property(e => e.Vakcode)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Vaknaam)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
