using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitoAlquiler.Model.Entities
{
    public class Item
    {
        public int id { get; set; }
        public string? nombreItem { get; set; }
        public string? marca { get; set; }
        public string? modelo { get; set; }
        public double tarifaDia { get; set; }
        public int categoriaId { get; set; }
        public virtual Categoria? categoria { get; set; }
        public virtual ICollection<Alquileres>? Alquileres { get; set; }
        public DateTime? deletedAt { get; set; }
    }
}