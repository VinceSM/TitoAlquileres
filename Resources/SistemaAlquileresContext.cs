using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;
using TitoAlquiler.Model.Entities;

public class SistemaAlquilerContext : DbContext
{
    public DbSet<UserType> UserTypes { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Empleado> Empleados { get; set; }
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
            //optionsBuilder.UseSqlServer(@"Server=GABRIELMUISE\SQLEXPRESS;Database=alquileres;Trusted_Connection=True;TrustServerCertificate=True;");
            optionsBuilder.UseSqlServer(@"Server=DESKTOP-7GMGFPP\SQLEXPRESS;Database=alquileres;Trusted_Connection=True;TrustServerCertificate=True;");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        ConfigureUserTypes(modelBuilder);
        ConfigureUsuarios(modelBuilder);
        ConfigureEmpleados(modelBuilder);
        ConfigureItems(modelBuilder);
        ConfigureAlquileres(modelBuilder);
        ConfigureCategorias(modelBuilder);
        ConfigureItemTypes(modelBuilder);
        ConfigureGlobalFilters(modelBuilder);
    }

    private void ConfigureUserTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserType>(entity =>
        {
            entity.ToTable("UserTypes");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.nombre).HasColumnName("Nombre").HasMaxLength(65);
            entity.Property(e => e.dni).HasColumnName("Dni");
            entity.Property(e => e.email).HasColumnName("Email").HasMaxLength(65);
            entity.Property(e => e.deletedAt).HasColumnName("DeletedAt");
        });
    }

    private void ConfigureUsuarios(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("Usuarios");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.userTypeId).HasColumnName("userId");
            entity.Property(e => e.membresiaPremium).HasColumnName("MembresiaPremium");
            entity.HasMany(u => u.Alquileres)
                  .WithOne(a => a.usuario)
                  .HasForeignKey(a => a.usuarioId)
                  .OnDelete(DeleteBehavior.Restrict);
        });
    }

    private void ConfigureEmpleados(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Empleado>(entity =>
        {
            entity.ToTable("Empleados");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.userTypeId).HasColumnName("userId");
        });
    }

    private void ConfigureItems(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("Items");
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
    }

    private void ConfigureAlquileres(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Alquiler>(entity =>
        {
            entity.ToTable("Alquileres");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.tiempoDias).HasColumnName("TiempoDias");
            entity.Property(e => e.fechaInicio).HasColumnName("FechaInicio");
            entity.Property(e => e.fechaFin).HasColumnName("FechaFin");
            entity.Property(e => e.precioTotal).HasColumnName("PrecioTotal");
            entity.Property(e => e.tipoEstrategia).HasColumnName("TipoEstrategia").HasMaxLength(50);
            entity.Property(e => e.descuento).HasColumnName("Descuento");
            entity.Property(e => e.deletedAt).HasColumnName("DeletedAt");
        });
    }

    private void ConfigureCategorias(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Categoria>(entity =>
        {
            entity.ToTable("Categorias");
            entity.Property(e => e.id).HasColumnName("Id");
            entity.Property(e => e.nombre).HasColumnName("Nombre").HasMaxLength(65);
            entity.Property(e => e.deletedAt).HasColumnName("DeletedAt");
        });
    }

    private void ConfigureItemTypes(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<ItemTransporte>(entity =>
        {
            entity.ToTable("ItemTransportes");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });

        modelBuilder.Entity<ItemElectrodomesticos>(entity =>
        {
            entity.ToTable("ItemElectrodomesticos");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });

        modelBuilder.Entity<ItemElectronica>(entity =>
        {
            entity.ToTable("ItemElectronica");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });

        modelBuilder.Entity<ItemInmuebles>(entity =>
        {
            entity.ToTable("ItemInmuebles");
            entity.Property(e => e.descripcion).HasColumnName("Descripcion").HasMaxLength(255);
        });
    }

    private void ConfigureGlobalFilters(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<UserType>().HasQueryFilter(u => u.deletedAt == null);
        modelBuilder.Entity<Alquiler>().HasQueryFilter(a => a.deletedAt == null);
        modelBuilder.Entity<Item>().HasQueryFilter(i => i.deletedAt == null);
        modelBuilder.Entity<Categoria>().HasQueryFilter(c => c.deletedAt == null);
    }
}