using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;

public class SistemaAlquilerContext : DbContext
{
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Item> Items { get; set; }
    public DbSet<Alquileres> Alquileres { get; set; }
    public DbSet<Categoria> Categorias { get; set; }

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
        // Configuración de Item
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Items");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombreItem).HasColumnName("nombreItem");
            entity.Property(e => e.marca).HasColumnName("marca");
            entity.Property(e => e.modelo).HasColumnName("modelo");
            entity.Property(e => e.tarifaDia).HasColumnName("tarifaDia");
            entity.Property(e => e.categoriaId).HasColumnName("categoriaId");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");

            entity.HasOne(i => i.categoria)
                  .WithMany(c => c.items)
                  .HasForeignKey(i => i.categoriaId)
                  .OnDelete(DeleteBehavior.Restrict);

            entity.HasMany(i => i.Alquileres)
                  .WithOne(a => a.item)
                  .HasForeignKey(a => a.ItemID)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Categoria
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre).HasColumnName("nombre");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");
        });

        // Configuración de Usuarios
        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre).HasColumnName("nombre");
            entity.Property(e => e.dni).HasColumnName("dni");
            entity.Property(e => e.email).HasColumnName("email");
            entity.Property(e => e.membresiaPremium).HasColumnName("membresiaPremium");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");

            entity.HasMany(u => u.Alquileres)
                  .WithOne(a => a.usuario)
                  .HasForeignKey(a => a.UsuarioID)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Alquiler
        modelBuilder.Entity<Alquileres>(entity =>
        {
            entity.ToTable("Alquileres");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.ItemID).HasColumnName("itemId");
            entity.Property(e => e.UsuarioID).HasColumnName("usuarioId");
            entity.Property(e => e.tiempoDias).HasColumnName("tiempoDias");
            entity.Property(e => e.fechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.fechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.precioTotal).HasColumnName("precioTotal");
            entity.Property(e => e.tipoEstrategia).HasColumnName("tipoEstrategia");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");
        });

        // Configuración de filtros globales para el borrado lógico
        modelBuilder.Entity<Usuarios>().HasQueryFilter(u => u.deletedAt == null);
        modelBuilder.Entity<Alquileres>().HasQueryFilter(a => a.deletedAt == null);
        modelBuilder.Entity<Item>().HasQueryFilter(i => i.deletedAt == null);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.deletedAt == null);
    }
}

