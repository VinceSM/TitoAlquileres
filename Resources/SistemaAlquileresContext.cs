using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

public class SistemaAlquilerContext : DbContext
{
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Item>itemsAlquilables { get; set; }
    public DbSet<Alquiler> alquileres { get; set; } 
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
        // Configuración de Usuario
        modelBuilder.Entity<Usuario>(entity =>
        {
            entity.ToTable("usuario"); 
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.nombre).HasColumnName("nombre").HasMaxLength(65);
            entity.Property(e => e.dni).HasColumnName("dni");
            entity.Property(e => e.email).HasColumnName("email").HasMaxLength(65);
            entity.Property(e => e.tipoMembresia).HasColumnName("tipo_membresia").HasMaxLength(65);
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt").HasDefaultValue(null); 
        });

        // Configuración de Item
        modelBuilder.Entity<Item>(entity =>
        {
            entity.ToTable("itemAlquilable"); 
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.categoria).HasColumnName("categoria").HasMaxLength(65);
            entity.Property(e => e.nombre).HasColumnName("nombre").HasMaxLength(65);
            entity.Property(e => e.marca).HasColumnName("marca").HasMaxLength(65);
            entity.Property(e => e.modelo).HasColumnName("modelo").HasMaxLength(65);
            entity.Property(e => e.tarifa).HasColumnName("tarifa");
        });

        // Configuración de Alquiler
        modelBuilder.Entity<Alquiler>(entity =>
        {
            entity.ToTable("alquiler"); 
            entity.Property(e => e.id).HasColumnName("id");
            entity.Property(e => e.item_id).HasColumnName("item_id");
            entity.Property(e => e.usuario_id).HasColumnName("usuario_id");
            entity.Property(e => e.tiempo_dias).HasColumnName("tiempo_dias");
            entity.Property(e => e.fecha_inicio).HasColumnName("fecha_inicio");
            entity.Property(e => e.fecha_fin).HasColumnName("fecha_fin");
            entity.Property(e => e.precio_total).HasColumnName("precioTotal");
            entity.Property(e => e.deletedAt).HasColumnName("deletedAt").HasDefaultValue(null); 

            // Relaciones de Alquiler con Item y Usuario
            entity.HasOne(d => d.item_id)
                .WithMany()
                .HasForeignKey(d => d.item_id) 
                .OnDelete(DeleteBehavior.Restrict);

            entity.HasOne(d => d.usuario_id) 
                .WithMany() 
                .HasForeignKey(d => d.usuario_id) 
                .OnDelete(DeleteBehavior.Restrict); 
        });

        modelBuilder.Entity<Usuario>().HasQueryFilter(u => u.deletedAt == null);
        modelBuilder.Entity<Alquiler>().HasQueryFilter(a => a.deletedAt == null);
    }

}