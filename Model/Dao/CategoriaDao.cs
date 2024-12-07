using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using TitoAlquiler.Model.Entities;

namespace TitoAlquiler.Model.Dao
{
    public class CategoriaDao
    {
        public CategoriaDao() { }

        public void InsertCategoria(Categoria categoria)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.categorias.Add(categoria);
                db.SaveChanges();
            }
        }

        public void UpdateCategoria(Categoria categoria)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Update(categoria);
                db.SaveChanges();
            }
        }

        public void SoftDeleteCategoria(Categoria categoria)
        {
            using (var db = new SistemaAlquilerContext())
            {
                categoria.deletedAt = DateTime.Now;
                db.Update(categoria);
                db.SaveChanges();
            }
        }

        public List<Categoria> LoadAllCategorias()
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.categorias
                    .Where(x => x.deletedAt == null)
                    .Include(x => x.items)
                    .ToList();
            }
        }

        public Categoria FindCategoriaById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            { 
                return db.categorias
                    .Where(x => x.id == id && x.deletedAt == null)
                    .Include(x => x.items)
                    .FirstOrDefault();
            }
        }

        public Categoria FindCategoriaByNombre(string nombre)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.categorias
                    .Where(x => x.nombre == nombre && x.deletedAt == null)
                    .FirstOrDefault();
            }
        }

        public List<Categoria> SearchCategorias(string search)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.categorias
                    .Where(x => x.nombre.Contains(search) && x.deletedAt == null)
                    .ToList();
            }
        }
    }
}

