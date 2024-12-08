using Microsoft.EntityFrameworkCore;
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
       
    }
}