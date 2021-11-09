using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FoodWhale.Model
{
    public partial class FoodWhaleContext : DbContext
    {
        public FoodWhaleContext()
        {
        }

        public FoodWhaleContext(DbContextOptions<FoodWhaleContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeImage> RecipeImages { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<UserAccess> UserAccesses { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("server =(local); database = FoodWhale;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "SQL_Latin1_General_CP1_CI_AS");

            modelBuilder.Entity<Category>(entity =>
            {
                entity.HasKey(e => e.Cid)
                    .HasName("PK_Category_1");

                entity.ToTable("Category");

                entity.Property(e => e.Cid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CID");

                entity.Property(e => e.Cname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CName");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.InId);

                entity.ToTable("Ingredient");

                entity.Property(e => e.InId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InID");

                entity.Property(e => e.InName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Price)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.Oid);

                entity.ToTable("Order");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.Property(e => e.Date).HasColumnType("date");

                entity.Property(e => e.Status)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Order_Detail");

                entity.Property(e => e.InId)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InID");

                entity.Property(e => e.Odid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("ODID");

                entity.Property(e => e.Oid).HasColumnName("OID");

                entity.HasOne(d => d.In)
                    .WithMany()
                    .HasForeignKey(d => d.InId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Detail_Ingredient");

                entity.HasOne(d => d.OidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Oid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Detail_Order");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.Rid);

                entity.ToTable("Recipe");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.Property(e => e.Cid)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("CID");

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ImageId).HasColumnName("imageID");

                entity.Property(e => e.Rdescription)
                    .IsRequired()
                    .IsUnicode(false)
                    .HasColumnName("RDescription");

                entity.Property(e => e.Rname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("RName");

                entity.Property(e => e.VideoUrl)
                    .IsUnicode(false)
                    .HasColumnName("VideoURL");

                entity.HasOne(d => d.CidNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.Cid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Category");
            });

            modelBuilder.Entity<RecipeImage>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Recipe_Image");

                entity.Property(e => e.ImageUrl).HasColumnName("imageURL");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany()
                    .HasForeignKey(d => d.Rid)
                    .HasConstraintName("FK__Recipe_Imag__RID__5BE2A6F2");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => new { e.Rid, e.InId });

                entity.ToTable("Recipe_Ingredient");

                entity.Property(e => e.Rid).HasColumnName("RID");

                entity.Property(e => e.InId)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("InID");

                entity.HasOne(d => d.In)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.InId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Ingredient_Ingredient");

                entity.HasOne(d => d.RidNavigation)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.Rid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Ingredient_Recipe");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.Uid);

                entity.ToTable("User");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.Property(e => e.Address)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.City)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DoB).HasColumnType("date");

                entity.Property(e => e.Email)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Gender)
                    .HasMaxLength(1)
                    .IsUnicode(false)
                    .IsFixedLength(true);

                entity.Property(e => e.ImageUrl).HasColumnName("imageURL");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Uname)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("UName");
            });

            modelBuilder.Entity<UserAccess>(entity =>
            {
                entity.HasKey(e => e.Aid);

                entity.ToTable("User_Access");

                entity.Property(e => e.Aid)
                    .HasMaxLength(50)
                    .IsUnicode(false)
                    .HasColumnName("AID");

                entity.Property(e => e.DateAccess)
                    .HasColumnType("date")
                    .HasColumnName("Date_access");

                entity.Property(e => e.Uid).HasColumnName("UID");

                entity.HasOne(d => d.UidNavigation)
                    .WithMany(p => p.UserAccesses)
                    .HasForeignKey(d => d.Uid)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Access_User");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
