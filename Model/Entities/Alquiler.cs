﻿using SistemaAlquileres.Model.Strategy;
using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using TitoAlquiler.Model.Entities;

namespace SistemaAlquileres.Model.Entities
{
    public class Alquiler
    {
        internal readonly object fecha_inicio;

        public int id { get; set; }

        [Required]
        public int itemId { get; set; }

        [ForeignKey("ItemId")]
        public virtual Item item { get; set; }

        [Required]
        public int usuarioId { get; set; }

        [ForeignKey("UsuarioId")]
        public virtual Usuario usuario { get; set; }

        [Required]
        public int tiempoDias { get; set; }

        [Required]
        public DateTime fechaInicio { get; set; }

        [Required]
        public DateTime fechaFin { get; set; }

        [Required]
        public double precioTotal { get; set; }

        [StringLength(50)]
        public string tipoEstrategia { get; set; }

        public bool descuento { get; set; }

        public DateTime? deletedAt { get; set; }

        public void CalcularPrecioTotal(IEstrategiaAlquiler estrategia)
        {
            precioTotal = estrategia.CalcularPrecio(this, item);
            tipoEstrategia = estrategia.getEstrategia();
        }
    }
}