using Equipment_accounting.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Equipment_accounting.DataBase
{
    public partial class EquipmentBDContext : IdentityDbContext<User>
    {
        public EquipmentBDContext()
        {
        }

        public EquipmentBDContext(DbContextOptions<EquipmentBDContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Audience> Audiences { get; set; } = null!;
        public virtual DbSet<Categoryequipment> Categoryequipments { get; set; } = null!;
        public virtual DbSet<Documentsequipment> Documentsequipments { get; set; } = null!;
        public virtual DbSet<Equipment> Equipment { get; set; } = null!;
        public virtual DbSet<User> Users { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseNpgsql("Server=localhost;Database=EquipmentBD;Username=postgres;Password=1337;");
            }
        }

        //protected override void OnModelCreating(ModelBuilder modelBuilder)
        //{
        // modelBuilder.Entity<Audience>(entity =>
        // {
        //  entity.ToTable("audiences");

        //  entity.HasIndex(e => e.Name, "audiences_name_key")
        //               .IsUnique();

        //  entity.HasIndex(e => e.Number, "audiences_number_key")
        //               .IsUnique();

        //  entity.Property(e => e.Id).HasColumnName("id");

        //  entity.Property(e => e.Name)
        //               .HasMaxLength(60)
        //               .HasColumnName("name");

        //  entity.Property(e => e.Number).HasColumnName("number");
        // });

        // modelBuilder.Entity<Categoryequipment>(entity =>
        // {
        //  entity.ToTable("categoryequipment");

        //  entity.HasIndex(e => e.Name, "categoryequipment_name_key")
        //               .IsUnique();

        //  entity.Property(e => e.Id).HasColumnName("id");

        //  entity.Property(e => e.Name)
        //               .HasMaxLength(60)
        //               .HasColumnName("name");
        // });

        // modelBuilder.Entity<Documentsequipment>(entity =>
        // {
        //  entity.ToTable("documentsequipment");

        //  entity.Property(e => e.Id).HasColumnName("id");

        //  entity.Property(e => e.Scan).HasColumnName("scan");
        // });

        // modelBuilder.Entity<Equipment>(entity =>
        // {
        //  entity.ToTable("equipment");

        //  entity.HasIndex(e => e.Qrcode, "equipment_qrcode_key")
        //               .IsUnique();

        //  entity.Property(e => e.Id).HasColumnName("id");

        //  entity.Property(e => e.AuditoryId).HasColumnName("auditory_id");

        //  entity.Property(e => e.CategoryId).HasColumnName("category_id");

        //  entity.Property(e => e.Dateaddedormoved).HasColumnName("dateaddedormoved");

        //  entity.Property(e => e.DocumentId).HasColumnName("document_id");

        //  entity.Property(e => e.Name)
        //               .HasMaxLength(60)
        //               .HasColumnName("name");

        //  entity.Property(e => e.Photo).HasColumnName("photo");

        //  entity.Property(e => e.Qrcode).HasColumnName("qrcode");

        //  entity.Property(e => e.Receiptdate).HasColumnName("receiptdate");

        //  entity.HasOne(d => d.Auditory)
        //               .WithMany(p => p.Equipment)
        //               .HasForeignKey(d => d.AuditoryId)
        //               .HasConstraintName("fk_equipment_id_audience");

        //  entity.HasOne(d => d.Category)
        //               .WithMany(p => p.Equipment)
        //               .HasForeignKey(d => d.CategoryId)
        //               .HasConstraintName("fk_equipment_id_category");

        //  entity.HasOne(d => d.Document)
        //               .WithMany(p => p.Equipment)
        //               .HasForeignKey(d => d.DocumentId)
        //               .HasConstraintName("fk_equipment_id_document");
        // });

        // modelBuilder.Entity<User>(entity =>
        // {
        //  entity.ToTable("users");

        //  entity.Property(e => e.Id).HasColumnName("id");

        //  entity.Property(e => e.Login)
        //               .HasMaxLength(16)
        //               .HasColumnName("login");

        //  entity.Property(e => e.Password)
        //               .HasMaxLength(16)
        //               .HasColumnName("password");
        // });

        // OnModelCreatingPartial(modelBuilder);
        //}

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
