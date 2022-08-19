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

        
    }
}
