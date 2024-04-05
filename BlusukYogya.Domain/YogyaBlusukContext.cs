using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace BlusukYogya.Domain;

public partial class YogyaBlusukContext : DbContext
{
    public YogyaBlusukContext()
    {
    }

    public YogyaBlusukContext(DbContextOptions<YogyaBlusukContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Category> Categories { get; set; }

    public virtual DbSet<Image> Images { get; set; }

    public virtual DbSet<Place> Places { get; set; }

    public virtual DbSet<PlaceReview> PlaceReviews { get; set; }

    public virtual DbSet<PlanItem> PlanItems { get; set; }

    public virtual DbSet<Role> Roles { get; set; }

    public virtual DbSet<Tag> Tags { get; set; }

    public virtual DbSet<User> Users { get; set; }

    public virtual DbSet<VacationPlan> VacationPlans { get; set; }

//    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
//#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see https://go.microsoft.com/fwlink/?LinkId=723263.
//        => optionsBuilder.UseSqlServer("Data Source=.\\BSISqlExpress;Initial Catalog=YogyaBlusuk;Integrated Security=True;TrustServerCertificate=True;");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Category>(entity =>
        {
            entity.HasKey(e => e.CategoryId).HasName("PK__Category__19093A2BBA2C4FDD");

            entity.ToTable("Category");

            entity.HasIndex(e => e.CategoryName, "UQ__Category__8517B2E0E33575D2").IsUnique();

            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.CategoryName).HasMaxLength(50);
        });

        modelBuilder.Entity<Image>(entity =>
        {
            entity.ToTable("Image");

            entity.Property(e => e.ImageId).HasColumnName("ImageID");
            entity.Property(e => e.ImageUrl).HasColumnName("ImageURL");
            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");

            entity.HasOne(d => d.Place).WithMany(p => p.Images)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Image_Place");
        });

        modelBuilder.Entity<Place>(entity =>
        {
            entity.ToTable("Place");

            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            entity.Property(e => e.AveragePrice).HasColumnType("decimal(15, 2)");
            entity.Property(e => e.Location).HasMaxLength(255);
            entity.Property(e => e.Name).HasMaxLength(255);

            entity.HasOne(d => d.CategoryTypeNavigation).WithMany(p => p.Places)
                .HasForeignKey(d => d.CategoryType)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Place_Category");

            entity.HasMany(d => d.Tags).WithMany(p => p.Places)
                .UsingEntity<Dictionary<string, object>>(
                    "PlaceTag",
                    r => r.HasOne<Tag>().WithMany()
                        .HasForeignKey("TagId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PlaceTag_Tags"),
                    l => l.HasOne<Place>().WithMany()
                        .HasForeignKey("PlaceId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_PlaceTag_Place"),
                    j =>
                    {
                        j.HasKey("PlaceId", "TagId");
                        j.ToTable("PlaceTag");
                        j.IndexerProperty<int>("PlaceId").HasColumnName("PlaceID");
                        j.IndexerProperty<int>("TagId").HasColumnName("TagID");
                    });
        });

        modelBuilder.Entity<PlaceReview>(entity =>
        {
            entity.HasKey(e => e.ReviewId);

            entity.ToTable("PlaceReview");

            entity.Property(e => e.ReviewId).HasColumnName("ReviewID");
            entity.Property(e => e.Date).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            entity.Property(e => e.Rating).HasColumnType("decimal(3, 2)");
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.Place).WithMany(p => p.PlaceReviews)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaceReview_Place");

            entity.HasOne(d => d.User).WithMany(p => p.PlaceReviews)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlaceReview_Users");
        });

        modelBuilder.Entity<PlanItem>(entity =>
        {
            entity.HasKey(e => e.ItemId);

            entity.ToTable("PlanItem");

            entity.Property(e => e.ItemId).HasColumnName("ItemID");
            entity.Property(e => e.PlaceId).HasColumnName("PlaceID");
            entity.Property(e => e.PlanId).HasColumnName("PlanID");

            entity.HasOne(d => d.Place).WithMany(p => p.PlanItems)
                .HasForeignKey(d => d.PlaceId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanItem_Place");

            entity.HasOne(d => d.Plan).WithMany(p => p.PlanItems)
                .HasForeignKey(d => d.PlanId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_PlanItem_VacationPlan");
        });

        modelBuilder.Entity<Role>(entity =>
        {
            entity.HasKey(e => e.RoleId).HasName("PK__Role__8AFACE3ADE9D7EB9");

            entity.ToTable("Role");

            entity.HasIndex(e => e.RoleName, "UQ__Role__8A2B616043F8B263").IsUnique();

            entity.Property(e => e.RoleId).HasColumnName("RoleID");
            entity.Property(e => e.RoleName).HasMaxLength(50);
        });

        modelBuilder.Entity<Tag>(entity =>
        {
            entity.HasKey(e => e.TagId).HasName("PK__Tags__657CFA4C2C54D05D");

            entity.Property(e => e.TagId).HasColumnName("TagID");
            entity.Property(e => e.CategoryId).HasColumnName("CategoryID");
            entity.Property(e => e.TagName).HasMaxLength(50);

            entity.HasOne(d => d.Category).WithMany(p => p.Tags)
                .HasForeignKey(d => d.CategoryId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_Category");
        });

        modelBuilder.Entity<User>(entity =>
        {
            entity.HasKey(e => e.UserId).HasName("PK__Users__1788CCAC9B632B02");

            entity.HasIndex(e => e.Username, "UQ_Username").IsUnique();

            entity.Property(e => e.UserId).HasColumnName("UserID");
            entity.Property(e => e.Email).HasMaxLength(100);
            entity.Property(e => e.FirstName).HasMaxLength(50);
            entity.Property(e => e.LastName).HasMaxLength(50);
            entity.Property(e => e.Password).HasMaxLength(255);
            entity.Property(e => e.Username).HasMaxLength(50);

            entity.HasMany(d => d.Roles).WithMany(p => p.Users)
                .UsingEntity<Dictionary<string, object>>(
                    "UserRole",
                    r => r.HasOne<Role>().WithMany()
                        .HasForeignKey("RoleId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_Role"),
                    l => l.HasOne<User>().WithMany()
                        .HasForeignKey("UserId")
                        .OnDelete(DeleteBehavior.ClientSetNull)
                        .HasConstraintName("FK_UserRole_User"),
                    j =>
                    {
                        j.HasKey("UserId", "RoleId");
                        j.ToTable("UserRole");
                        j.IndexerProperty<int>("UserId").HasColumnName("UserID");
                        j.IndexerProperty<int>("RoleId")
                            .HasDefaultValue(2)
                            .HasColumnName("RoleID");
                    });
        });

        modelBuilder.Entity<VacationPlan>(entity =>
        {
            entity.HasKey(e => e.PlanId);

            entity.ToTable("VacationPlan");

            entity.Property(e => e.PlanId).HasColumnName("PlanID");
            entity.Property(e => e.CreateData).HasDefaultValueSql("(getdate())");
            entity.Property(e => e.Name).HasMaxLength(50);
            entity.Property(e => e.UserId).HasColumnName("UserID");

            entity.HasOne(d => d.User).WithMany(p => p.VacationPlans)
                .HasForeignKey(d => d.UserId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_VacationPlan_Users");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
