using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

#nullable disable

namespace FoodWhale.Models
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

        public virtual DbSet<Admin> Admins { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Ingredient> Ingredients { get; set; }
        public virtual DbSet<Order> Orders { get; set; }
        public virtual DbSet<OrderDetail> OrderDetails { get; set; }
        public virtual DbSet<Recipe> Recipes { get; set; }
        public virtual DbSet<RecipeIngredient> RecipeIngredients { get; set; }
        public virtual DbSet<RecipeLike> RecipeLikes { get; set; }
        public virtual DbSet<User> Users { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
#warning To protect potentially sensitive information in your connection string, you should move it out of source code. You can avoid scaffolding the connection string by using the Name= syntax to read it from configuration - see https://go.microsoft.com/fwlink/?linkid=2131148. For more guidance on storing connection strings, see http://go.microsoft.com/fwlink/?LinkId=723263.
                optionsBuilder.UseSqlServer("server =(local); database = FoodWhale;uid=sa;pwd=123456;");
            }
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.HasAnnotation("Relational:Collation", "Latin1_General_CI_AS");

            modelBuilder.Entity<Admin>(entity =>
            {
                entity.HasNoKey();

                entity.ToTable("Admin");

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("password");

                entity.Property(e => e.Username)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("username");
            });

            modelBuilder.Entity<Category>(entity =>
            {
                entity.ToTable("Category");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.CName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .HasColumnName("cName");
            });

            modelBuilder.Entity<Ingredient>(entity =>
            {
                entity.HasKey(e => e.InId)
                    .HasName("PK__Ingredie__94BA3A360425A276");

                entity.ToTable("Ingredient");

                entity.Property(e => e.InId).HasColumnName("inID");

                entity.Property(e => e.CategoryId).HasColumnName("categoryID");

                entity.Property(e => e.Description)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("description");

                entity.Property(e => e.Guideline)
                    .IsRequired()
                    .HasColumnName("guideline");

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.InName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .HasColumnName("inName");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Ingredients)
                    .HasForeignKey(d => d.CategoryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Ingredient_Category");
            });

            modelBuilder.Entity<Order>(entity =>
            {
                entity.HasKey(e => e.OId)
                    .HasName("PK__Order__C2FECB1B07F6335A");

                entity.ToTable("Order");

                entity.Property(e => e.OId).HasColumnName("oID");

                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.Property(e => e.Status).HasDefaultValueSql("('0')");

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany(p => p.Orders)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_User");
            });

            modelBuilder.Entity<OrderDetail>(entity =>
            {
                entity.HasKey(e => e.OdId)
                    .HasName("PK__Order_De__8D163A310BC6C43E");

                entity.ToTable("Order_Detail");

                entity.Property(e => e.OdId).HasColumnName("odID");

                entity.Property(e => e.InId).HasColumnName("inID");

                entity.Property(e => e.OId).HasColumnName("oID");

                entity.HasOne(d => d.In)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.InId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Detail_Ingredient");

                entity.HasOne(d => d.OIdNavigation)
                    .WithMany(p => p.OrderDetails)
                    .HasForeignKey(d => d.OId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Order_Detail_Order");
            });

            modelBuilder.Entity<Recipe>(entity =>
            {
                entity.HasKey(e => e.RId)
                    .HasName("PK__Recipe__C2BEC9100F975522");

                entity.ToTable("Recipe");

                entity.Property(e => e.RId).HasColumnName("rID");

                entity.Property(e => e.CId).HasColumnName("cID");

                entity.Property(e => e.Difficulty)
                    .IsRequired()
                    .HasMaxLength(6)
                    .IsUnicode(false);

                entity.Property(e => e.Image)
                    .IsRequired()
                    .HasMaxLength(255)
                    .IsUnicode(false);

                entity.Property(e => e.LikeCount).HasDefaultValueSql("('0')");

                entity.Property(e => e.RDescription).HasColumnName("rDescription");

                entity.Property(e => e.RName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .HasColumnName("rName");

                entity.HasOne(d => d.CIdNavigation)
                    .WithMany(p => p.Recipes)
                    .HasForeignKey(d => d.CId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Category");
            });

            modelBuilder.Entity<RecipeIngredient>(entity =>
            {
                entity.HasKey(e => e.RiId)
                    .HasName("PK__Recipe_i__85AE2E37145C0A3F");

                entity.ToTable("Recipe_ingredient");

                entity.Property(e => e.RiId).HasColumnName("riID");

                entity.Property(e => e.InId).HasColumnName("inID");

                entity.Property(e => e.RId).HasColumnName("rID");

                entity.HasOne(d => d.In)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.InId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_ingredient_Ingredient");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.RecipeIngredients)
                    .HasForeignKey(d => d.RId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_ingredient_Recipe");
            });

            modelBuilder.Entity<RecipeLike>(entity =>
            {
                entity.HasKey(e => e.RlId)
                    .HasName("PK__Recipe_L__8460506C182C9B23");

                entity.ToTable("Recipe_Like");

                entity.Property(e => e.RlId).HasColumnName("rlID");

                entity.Property(e => e.Fav).HasDefaultValueSql("('0')");

                entity.Property(e => e.RId).HasColumnName("rID");

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.HasOne(d => d.RIdNavigation)
                    .WithMany(p => p.RecipeLikes)
                    .HasForeignKey(d => d.RId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Like_Recipe");

                entity.HasOne(d => d.UIdNavigation)
                    .WithMany(p => p.RecipeLikes)
                    .HasForeignKey(d => d.UId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Recipe_Like_User");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasKey(e => e.UId)
                    .HasName("PK__User__DD771E3C1BFD2C07");

                entity.ToTable("User");

                entity.Property(e => e.UId).HasColumnName("uID");

                entity.Property(e => e.Address)
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

                entity.Property(e => e.Password)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Phone)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Role)
                    .HasMaxLength(5)
                    .IsUnicode(false)
                    .HasDefaultValueSql("('User')");

                entity.Property(e => e.UName)
                    .IsRequired()
                    .HasMaxLength(30)
                    .IsUnicode(false)
                    .HasColumnName("uName");
            });

            OnModelCreatingPartial(modelBuilder);
        }

        partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
    }
}
