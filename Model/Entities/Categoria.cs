using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TitoAlquiler.Model.Entities
{
    public class Categoria
    {
        public int id { get; set; }

        [Required]
        [StringLength(65)]
        public string? nombre { get; set; }

        public virtual ICollection<Item>? items { get; set; }

        public DateTime? deletedAt { get; set; }
    }
}