using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TitoAlquiler.Migrations
{
    /// <inheritdoc />
    public partial class InsertCategorias : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            // Inserta las categorías en la tabla Categorias
            migrationBuilder.InsertData(
                table: "Categorias",
                columns: new[] { "id", "nombre", "deletedAt" },  // Los nombres de las columnas
                values: new object[,]
                {
                { 1, "Transporte", null },  // id = 1, nombre = "Transporte", deletedAt = null
                { 2, "Electrodomestico", null },  // id = 2, nombre = "Electrodomesticos", deletedAt = null
                { 3, "Electronica", null },  // id = 3, nombre = "Electronica", deletedAt = null
                { 4, "Inmueble", null },  // id = 4, nombre = "Inmuebles", deletedAt = null
                { 5, "Indumentaria", null },  // id = 5, nombre = "Indumentaria", deletedAt = null
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            // Elimina las categorías insertadas si la migración se revierte
            migrationBuilder.DeleteData(
                table: "Categorias",
                keyColumn: "Id",  // columna de identificación
                keyValues: new object[] { 1, 2, 3, 4, 5 });  // Los valores de Id de las categorías que insertaste
        }
    }

}
