using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    //[Index(nameof(Id),  Name = "CuentaId_UQ", IsUnique = true)]
    public class CuentaHostel : BaseCuenta
    {
        #region Props
        [Required]
        public int Telefono { get; set; }   
        public bool Activo { get; set; }
        public int UsuarioId { get; set; }


        #endregion

        //public List<Publicacion> publicacionesH { get; set; }
        //public List<Comentario> comentariosH { get; set; }
    }
}


