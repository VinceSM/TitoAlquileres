using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;
using TitoAlquiler.Model.Entities;

public class SistemaAlquilerContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Item> itemsAlquilables { get; set; }
    public DbSet<Alquiler> alquileres { get; set; }
    public DbSet<Categoria> categorias { get; set; }
    public DbSet<ItemTransporte> transportes { get; set; }
    public DbSet<ItemElectrodomesticos> electrodomesticos { get; set; }
    public DbSet<ItemElectronica> electronica { get; set; }
    public DbSet<ItemInmuebles> inmuebles { get; set; }

    //public DbSet<Indumentaria> indumentarias { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(@"Server=GABRIELMUISE\SQLEXPRESS;Database=alquileres;Trusted_Connection=True;TrustServerCertificate=True;");
            //optionsBuilder.UseSqlServer(@"Server=DESKTOP-7GMGFPP\SQLEXPRESS;Database=alquileres;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configuración de Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuario");
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre).HasColumnName("nombre").HasMaxLength(65);
            entity.Property(e => e.dni).HasColumnName("dni");
            entity.Property(e => e.email).HasColumnName("email").HasMaxLength(65);
            entity.Property(e => e.membresiaPremium).HasColumnName("tipo_membresia").HasMaxLength(65);
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt");

            entity.HasMany(u => u.Alquileres)
                  .WithOne(a => a.usuario)
                  .HasForeignKey(a => a.usuarioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });

        // Configuración de Item
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.nombreItem).HasColumnName("NombreItem").HasMaxLength(65);
            entity.Property(e => e.marca).HasColumnName("Marca").HasMaxLength(65);
            entity.Property(e => e.modelo).HasColumnName("Modelo").HasMaxLength(65);
            entity.Property(e => e.tarifaDia).HasColumnName("TarifaDia");

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
            entity.ToTable("Alquiler");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.tiempoDias).HasColumnName("TiempoDias");
            entity.Property(e => e.fechaInicio).HasColumnName("FechaInicio");
            entity.Property(e => e.fechaFin).HasColumnName("FechaFin");
            entity.Property(e => e.precioTotal).HasColumnName("PrecioTotal");
            entity.Property(e => e.tipoEstrategia).HasColumnName("TipoEstrategia").HasMaxLength(50);
            entity.Property(e => e.descuento).HasColumnName("Descuento");
            entity.Property(e => e.deletedAt).HasColumnName("DeletedAt");
        });

        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categoria");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.nombre).HasColumnName("Nombre").HasMaxLength(65);
            entity.Property(e => e.deletedAt).HasColumnName("DeletedAt");
        });

        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Item");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.nombreItem).HasColumnName("NombreItem").HasMaxLength(65);
            entity.Property(e => e.marca).HasColumnName("Marca").HasMaxLength(65);
            entity.Property(e => e.modelo).HasColumnName("Modelo").HasMaxLength(65);
            entity.Property(e => e.tarifaDia).HasColumnName("TarifaDia");
        });

        // Configuración específica para ItemTransporte
        modelBuilder.Entity<ItemTransporte>(entity =>
        {
            entity.ToTable("ItemTransporte");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });

        // Configuración específica para ItemElectrodomesticos
        modelBuilder.Entity<ItemElectrodomesticos>(entity =>
        {
            entity.ToTable("ItemElectrodomesticos");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });

        // Configuración específica para ItemElectronica
        modelBuilder.Entity<ItemElectronica>(entity =>
        {
            entity.ToTable("ItemElectronica");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });

        // Configuración específica para ItemInmuebles
        modelBuilder.Entity<ItemInmuebles>(entity =>
        {
            entity.ToTable("ItemInmuebles");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });


        modelBuilder.Entity<ItemTransporte>().Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        modelBuilder.Entity<ItemElectrodomesticos>().Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        modelBuilder.Entity<ItemElectronica>().Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        modelBuilder.Entity<ItemInmuebles>().Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);

        // Configuración de filtros globales para el borrado lógico
        modelBuilder.Entity<Usuario>().HasQueryFilter(u => u.deletedAt == null);
        modelBuilder.Entity<Alquiler>().HasQueryFilter(a => a.deletedAt == null);
        modelBuilder.Entity<Item>().HasQueryFilter(i => i.deletedAt == null);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.deletedAt == null);
    }
}