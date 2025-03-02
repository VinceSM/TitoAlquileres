using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;
using TitoAlquiler.Model.Entities.Categorias;

public class SistemaAlquilerContext : DbContext
{
    public DbSet<Usuarios> Usuarios { get; set; }
    public DbSet<Transporte> Transportes { get; set; }
    public DbSet<Indumentaria> Indumentarias { get; set; }
    public DbSet<Inmueble> Inmuebles { get; set; }
    public DbSet<Electrodomestico> Electrodomesticos { get; set; }
    public DbSet<Electronica> Electronicas { get; set; }
    public DbSet<Alquileres> Alquileres { get; set; }
    public DbSet<Categoria> Categorias { get; set; }
    public DbSet<Item> Items { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            //optionsBuilder.UseSqlServer(@"Server=GABRIELMUISE\SQLEXPRESS;Database=alquileres1;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7GMGFPP\SQLEXPRESS;Database=alquileres1;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>().UseTptMappingStrategy();

        modelBuilder.Entity<Transporte>(entity =>
        {
            entity.ToTable("Transportes");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.itemId).HasColumnName("itemId"); // Cambiado a itemId
            entity.Property(e => e.capacidadPasajeros).HasColumnName("capacidadPasajeros");
            entity.Property(e => e.tipoCombustible).HasColumnName("tipoCombustible");
            entity.HasOne(e => e.item)
                  .WithOne()
                  .HasForeignKey<Transporte>(t => t.itemId) // Cambiado a itemId
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Electrodomestico>(entity =>
        {
            entity.ToTable("Electrodomesticos");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.itemId).HasColumnName("itemId"); // Asegúrate de que la propiedad se llame itemId
            entity.Property(e => e.potenciaWatts).HasColumnName("potenciaWatts");
            entity.Property(e => e.tipoElectrodomestico).HasColumnName("tipoElectrodomestico");
            entity.HasOne(e => e.item)
                  .WithOne()
                  .HasForeignKey<Electrodomestico>(e => e.itemId) // Cambiado a itemId
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Indumentaria>(entity =>
        {
            entity.ToTable("Indumentarias");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.itemId).HasColumnName("itemId"); // Asegúrate de que la propiedad se llame itemId
            entity.Property(e => e.talla).HasColumnName("talla");
            entity.Property(e => e.material).HasColumnName("material");
            entity.HasOne(e => e.item)
                  .WithOne()
                  .HasForeignKey<Indumentaria>(i => i.itemId) // Cambiado a itemId
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Inmueble>(entity =>
        {
            entity.ToTable("Inmuebles");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.itemId).HasColumnName("itemId"); // Cambiado a itemId
            entity.Property(e => e.metrosCuadrados).HasColumnName("metrosCuadrados");
            entity.Property(e => e.ubicacion).HasColumnName("ubicacion");
            entity.HasOne(e => e.item)
                  .WithOne()
                  .HasForeignKey<Inmueble>(i => i.itemId) // Cambiado a itemId
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Electronica>(entity =>
        {
            entity.ToTable("Electronicas");
            entity.HasKey(e => e.id);
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.itemId).HasColumnName("itemId"); // Asegúrate de que la propiedad se llame itemId
            entity.Property(e => e.resolucionPantalla).HasColumnName("resolucionPantalla");
            entity.Property(e => e.almacenamientoGB).HasColumnName("almacenamientoGB");
            entity.HasOne(e => e.item)
                  .WithOne()
                  .HasForeignKey<Electronica>(e => e.itemId) // Cambiado a itemId
                  .OnDelete(DeleteBehavior.Cascade);
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");
            entity.HasKey(e => e.id);
            entity.Property(e => e.nombre).HasColumnName("nombre");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");

            // Agregar datos semilla
            entity.HasData(
                new Categoria { id = 1, nombre = "Transporte" },
                new Categoria { id = 2, nombre = "Electrodomestico" },
                new Categoria { id = 3, nombre = "Electronica" },
                new Categoria { id = 4, nombre = "Inmueble" },
                new Categoria { id = 5, nombre = "Indumentaria" }
            );
        });

        modelBuilder.Entity<Usuarios>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.HasKey(e => e.id);
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

        modelBuilder.Entity<Alquileres>(entity =>
        {
            entity.ToTable("Alquileres");
            entity.HasKey(e => e.id);
            entity.Property(e => e.ItemID).HasColumnName("itemId");
            entity.Property(e => e.UsuarioID).HasColumnName("usuarioId");
            entity.Property(e => e.tiempoDias).HasColumnName("tiempoDias");
            entity.Property(e => e.fechaInicio).HasColumnName("fechaInicio");
            entity.Property(e => e.fechaFin).HasColumnName("fechaFin");
            entity.Property(e => e.precioTotal).HasColumnName("precioTotal");
            entity.Property(e => e.tipoEstrategia).HasColumnName("tipoEstrategia");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");
        });

        // Filtros de consulta
        modelBuilder.Entity<Usuarios>().HasQueryFilter(u => u.deletedAt == null);
        modelBuilder.Entity<Alquileres>().HasQueryFilter(a => a.deletedAt == null);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.deletedAt == null);
        modelBuilder.Entity<Item>().HasQueryFilter(i => i.deletedAt == null);
    }
}