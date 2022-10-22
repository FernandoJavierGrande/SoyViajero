using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<CuentaHostel> CuentasHostel { get; set; }
        public DbSet<CuentaViajero> CuentasViajeros { get; set; }
        public DbSet<Publicacion> Publicaciones { get; set; }
        //public DbSet<fotos_publicacion> fotos_publicaciones { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


        //protected override void OnModelCreating(ModelBuilder modelBuilder) //crea las relaciones fk
        //{
        //    modelBuilder.Entity<Publicacion>()
        //        .HasOne(p => p.cuentaHostel)
        //        .WithMany(b => b.publicacionesH);
        //    modelBuilder.Entity<Publicacion>()
        //        .HasOne(p => p.cuentaViajero)
        //        .WithMany(b => b.publicacionesV);
        //}
    }
}
