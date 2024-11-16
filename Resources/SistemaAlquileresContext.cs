using System;
using System.Data.Entity;
using Microsoft.Data.SqlClient;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres
{
    public class SistemaAlquilerContext : DbContext
    {
        public SistemaAlquilerContext() : base(GetConnectionString())
        {
        }

        public DbSet<Alquiler> alquiler { get; set; }
        public DbSet<Usuario> usuario { get; set; }
        public DbSet<Item> itemAlquilable { get; set; }

        private static string GetConnectionString()
        {
            string server = "DESKTOP-7GMGFPP";
            string database = "alquileres";
            string uid = "root";
            string password = "";

            return $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }

        public SqlConnection GetConnection()
        {
            return (SqlConnection)Database.Connection;
        }

        public bool TestConnection()
        {
            try
            {
                Database.Connection.Open();
                return true;
            }
            catch (SqlException)
            {
                return false;
            }
            finally
            {
                Database.Connection.Close();
            }
        }
    }
}