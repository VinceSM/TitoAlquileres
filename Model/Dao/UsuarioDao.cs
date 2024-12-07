using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using SistemaAlquileres.Model.Entities;

namespace SistemaAlquileres.Model.Dao
{
    public class UsuarioDao
    {
        public UsuarioDao() { }

        public void InsertUsuario(Usuario usuario)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Usuarios.Add(usuario);
                db.SaveChanges();
            }
        }

        public void UpdateUsuario(Usuario usuario)
        {
            using (var db = new SistemaAlquilerContext())
            {
                db.Update(usuario);
                db.SaveChanges();
            }
        }

        public void SoftDeleteUsuario(Usuario usuario)
        {
            using (var db = new SistemaAlquilerContext())
            {
                usuario.deletedAt = DateTime.Now;
                db.Update(usuario);
                db.SaveChanges();
            }
        }

        public List<Usuario> LoadAllUsuarios()
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Usuarios.Where(x => x.deletedAt == null).ToList();
            }
        }

        public Usuario FindUsuarioById(int id)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Usuarios
                    .Where(x => x.id == id && x.deletedAt == null)
                    .Include(x => x.Alquileres)
                    .FirstOrDefault();
            }
        }

        public Usuario FindUsuarioByDNI(int dni)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Usuarios
                    .Where(x => x.dni == dni && x.deletedAt == null)
                    .Include(x => x.Alquileres)
                    .FirstOrDefault();
            }
        }

        public List<Usuario> SearchUsuarios(string search)
        {
            using (var db = new SistemaAlquilerContext())
            {
                return db.Usuarios
                    .Where(x => (x.nombre.Contains(search) || x.email.Contains(search)) && x.deletedAt == null)
                    .ToList();
            }
        }
    }
}

