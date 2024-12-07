using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;
using TitoAlquiler.Model.Entities;

public class SistemaAlquilerContext : DbContext
{
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Alquiler> Alquileres { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<ItemTransporte> ItemsTransporte { get; set; }
    public DbSet<ItemElectrodomesticos> ItemsElectrodomesticos { get; set; }
    public DbSet<ItemElectronica> ItemsElectronica { get; set; }
    public DbSet<ItemInmuebles> ItemsInmuebles { get; set; }

    //public DbSet<Indumentaria> indumentarias { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlServer(@"Server=GABRIELMUISE\SQLEXPRESS;Database=alquileres;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7GMGFPP\SQLEXPRESS;Database=alquileres;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Usuarios
        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.nombre).HasColumnName("nombre").HasMaxLength(100);
            entity.Property(e => e.dni).HasColumnName("dni");
            entity.Property(e => e.email).HasColumnName("email").HasMaxLength(100);
            entity.Property(e => e.membresiaPremium).HasColumnName("membresiaPremium");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");

            entity.HasMany(u => u.Alquileres)
                  .WithOne(a => a.usuario)
                  .HasForeignKey(a => a.usuarioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Item
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Items");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.nombreItem).HasColumnName("nombreItem").HasMaxLength(65);
            entity.Property(e => e.marca).HasColumnName("marca").HasMaxLength(65);
            entity.Property(e => e.modelo).HasColumnName("modelo").HasMaxLength(65);
            entity.Property(e => e.tarifaDia).HasColumnName("tarifaDia");
            entity.Property(e => e.categoriaId).HasColumnName("categoriaId");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");

            entity.HasOne(i => i.categoria)
                  .WithMany(c => c.items)
                  .HasForeignKey(i => i.categoriaId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(i => i.Alquileres)
                  .WithOne(a => a.item)
                  .HasForeignKey(a => a.itemId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Alquiler
        modelBuilder.Entity<Alquiler>(entity =>
        {
            entity.ToTable("Alquileres");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.itemId).HasColumnName("ItemID");
            entity.Property(e => e.usuarioId).HasColumnName("UsuarioID");
            entity.Property(e => e.tiempoDias).HasColumnName("tiempoDias");
            entity.Property(e => e.fechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.fechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.precioTotal).HasColumnName("precioTotal");
            entity.Property(e => e.tipoEstrategia).HasColumnName("tipoEstrategia").HasMaxLength(50);
            entity.Property(e => e.descuento).HasColumnName("descuento");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");
        });

        // Configuración de Categoria
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.nombre).HasColumnName("nombre").HasMaxLength(65);
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");
        });

        // Configuración específica para ItemTransporte
        modelBuilder.Entity<ItemTransporte>(entity =>
        {
            entity.ToTable("ItemsTransporte");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.descripcion).HasColumnName("descripcion");
            entity.HasOne(i => i.itemId).WithOne().HasForeignKey<ItemTransporte>("ItemId");
        });

        // Configuración específica para ItemElectrodomesticos
        modelBuilder.Entity<ItemElectrodomesticos>(entity =>
        {
            entity.ToTable("ItemsElectrodomesticos");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.descripcion).HasColumnName("descripcion");
            entity.HasOne(i => i.itemId).WithOne().HasForeignKey<ItemElectrodomesticos>("ItemId");
        });

        // Configuración específica para ItemElectronica
        modelBuilder.Entity<ItemElectronica>(entity =>
        {
            entity.ToTable("ItemsElectronica");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.descripcion).HasColumnName("descripcion");
            entity.HasOne(i => i.itemId).WithOne().HasForeignKey<ItemElectronica>("ItemId");
        });

        // Configuración específica para ItemInmuebles
        modelBuilder.Entity<ItemInmuebles>(entity =>
        {
            entity.ToTable("ItemsInmuebles");
            entity.Property(e => e.id).HasColumnName("ID");
            entity.Property(e => e.descripcion).HasColumnName("descripcion");
            entity.HasOne(i => i.itemId).WithOne().HasForeignKey<ItemInmuebles>("ItemId");
        });

        // Configuración de filtros globales para el borrado lógico
        modelBuilder.Entity<Usuarios>().HasQueryFilter(u => u.deletedAt == null);
        modelBuilder.Entity<Alquiler>().HasQueryFilter(a => a.deletedAt == null);
        modelBuilder.Entity<Item>().HasQueryFilter(i => i.deletedAt == null);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.deletedAt == null);
    }
}