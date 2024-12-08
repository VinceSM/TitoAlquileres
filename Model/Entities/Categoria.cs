using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TitoAlquiler.Model.Entities
{
    public class Categoria
    {
        [Column("id")]
        public int id { get; set; }

        [Required]
        [StringLength(65)]
        public string? nombre { get; set; }

        public virtual ICollection<Item>? items { get; set; }

        public DateTime? deletedAt { get; set; }
    }
}