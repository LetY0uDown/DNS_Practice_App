using Microsoft.EntityFrameworkCore;

namespace DNS_Practice_App.Models;

public record class DBConnectionData (string Server, string User, string Password, string Database)
{
    public string ConnectionString => $"server={Server};user={User};password={Password};database={Database}";

    public bool IsNotEmpty => !string.IsNullOrWhiteSpace(Server) &&
                              !string.IsNullOrWhiteSpace(User) &&
                              !string.IsNullOrWhiteSpace(Password) &&
                              !string.IsNullOrWhiteSpace(Database);
}

public class DNS_practiceContext_One : DbContext
{
    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<Document> Documents { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<ProductReserve> ProductReserves { get; set; } = null!;
    public virtual DbSet<ProductStorage> ProductStorages { get; set; } = null!;
    public virtual DbSet<Storage> Storages { get; set; } = null!;

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseMySql(App.FirstConnection.ConnectionString, ServerVersion.AutoDetect(App.FirstConnection.ConnectionString));
        }
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<City>(entity => {
            entity.ToTable("city");

            entity.HasIndex(e => e.Id, "UK_city_id")
                .IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Document>(entity => {
            entity.ToTable("document");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Product>(entity => {
            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ProductReserve>(entity => {
            entity.HasNoKey();

            entity.ToTable("product_reserve");

            entity.HasIndex(e => e.DocumentId, "FK_product_reserve_DocumentID");

            entity.HasIndex(e => e.ProductId, "FK_product_reserve_ProductID2");

            entity.Property(e => e.DocumentId)
                .HasColumnName("DocumentID")
                .HasDefaultValueSql("''");

            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.Document)
                .WithMany()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_reserve_DocumentID");

            entity.HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_reserve_ProductID");
        });

        modelBuilder.Entity<ProductStorage>(entity => {
            entity.HasNoKey();

            entity.ToTable("product_storage");

            entity.HasIndex(e => e.ProductId, "FK_product_storage_ProductID2");

            entity.HasIndex(e => e.DocumentId, "FK_product_storage_documentID");

            entity.Property(e => e.DocumentId)
                .HasColumnName("documentID")
                .HasDefaultValueSql("''");

            entity.Property(e => e.DocumentType).HasColumnName("documentType");

            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.Document)
                .WithMany()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_storage_documentID");

            entity.HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_storage_ProductID2");

            modelBuilder.Entity<Storage>(entity => {
                entity.ToTable("storages");

                entity.HasIndex(e => e.CityId, "FK_storages_cityID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityID")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_storages_cityID");
            });
        });
    }
}

public class DNS_practiceContext_Two : DbContext
{
    public virtual DbSet<City> Cities { get; set; } = null!;
    public virtual DbSet<Document> Documents { get; set; } = null!;
    public virtual DbSet<Product> Products { get; set; } = null!;
    public virtual DbSet<ProductReserve> ProductReserves { get; set; } = null!;
    public virtual DbSet<ProductStorage> ProductStorages { get; set; } = null!;
    public virtual DbSet<Storage> Storages { get; set; } = null!;

    protected override void OnConfiguring (DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured) {
            optionsBuilder.UseMySql(App.SecondConnection.ConnectionString, ServerVersion.AutoDetect(App.SecondConnection.ConnectionString));
        }
    }

    protected override void OnModelCreating (ModelBuilder modelBuilder)
    {
        modelBuilder.UseCollation("utf8mb4_0900_ai_ci")
            .HasCharSet("utf8mb4");

        modelBuilder.Entity<City>(entity => {
            entity.ToTable("city");

            entity.HasIndex(e => e.Id, "UK_city_id")
                .IsUnique();

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<Document>(entity => {
            entity.ToTable("document");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Type).HasColumnName("type");
        });

        modelBuilder.Entity<Product>(entity => {
            entity.ToTable("product");

            entity.Property(e => e.Id)
                .HasColumnName("id")
                .HasDefaultValueSql("''");

            entity.Property(e => e.Name)
                .HasMaxLength(50)
                .HasColumnName("name")
                .HasDefaultValueSql("''");
        });

        modelBuilder.Entity<ProductReserve>(entity => {
            entity.HasNoKey();

            entity.ToTable("product_reserve");

            entity.HasIndex(e => e.DocumentId, "FK_product_reserve_DocumentID");

            entity.HasIndex(e => e.ProductId, "FK_product_reserve_ProductID2");

            entity.Property(e => e.DocumentId)
                .HasColumnName("DocumentID")
                .HasDefaultValueSql("''");

            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.Document)
                .WithMany()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_reserve_DocumentID");

            entity.HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_reserve_ProductID");
        });

        modelBuilder.Entity<ProductStorage>(entity => {
            entity.HasNoKey();

            entity.ToTable("product_storage");

            entity.HasIndex(e => e.ProductId, "FK_product_storage_ProductID2");

            entity.HasIndex(e => e.DocumentId, "FK_product_storage_documentID");

            entity.Property(e => e.DocumentId)
                .HasColumnName("documentID")
                .HasDefaultValueSql("''");

            entity.Property(e => e.DocumentType).HasColumnName("documentType");

            entity.Property(e => e.ProductId)
                .HasColumnName("ProductID")
                .HasDefaultValueSql("''");

            entity.HasOne(d => d.Document)
                .WithMany()
                .HasForeignKey(d => d.DocumentId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_storage_documentID");

            entity.HasOne(d => d.Product)
                .WithMany()
                .HasForeignKey(d => d.ProductId)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("FK_product_storage_ProductID2");

            modelBuilder.Entity<Storage>(entity => {
                entity.ToTable("storages");

                entity.HasIndex(e => e.CityId, "FK_storages_cityID");

                entity.Property(e => e.Id)
                    .HasColumnName("id")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.CityId)
                    .HasColumnName("cityID")
                    .HasDefaultValueSql("''");

                entity.Property(e => e.Name)
                    .HasMaxLength(50)
                    .HasColumnName("name")
                    .HasDefaultValueSql("''");

                entity.HasOne(d => d.City)
                    .WithMany(p => p.Storages)
                    .HasForeignKey(d => d.CityId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_storages_cityID");
            });
        });
    }
}