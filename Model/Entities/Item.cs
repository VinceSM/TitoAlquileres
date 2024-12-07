using TitoAlquiler.Model.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitoAlquiler.Model.Entities
{
    public abstract class Item
    {
        [Column("ID")]
        public int id { get; set; }

        [Required]
        [StringLength(65)]
        public string? nombreItem { get; set; }

        [StringLength(65)]
        public string? marca { get; set; }

        [StringLength(65)]
        public string? modelo { get; set; }

        [Required]
        public double tarifaDia { get; set; }

        [Required]
        public int categoriaId { get; set; }

        [ForeignKey("categoriaId")]
        public virtual Categoria? categoria { get; set; }

        public virtual ICollection<Alquiler>? Alquileres { get; set; }

        public DateTime? deletedAt { get; set; }
    }
}