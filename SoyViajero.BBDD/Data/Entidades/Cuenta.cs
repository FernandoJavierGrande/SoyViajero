using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class Cuenta
    {
        #region Prop

        public int Id { get; set; }
        [Required]
        public int UsuarioId { get; set; }
        [Required]
        public string TipoDeCuenta { get; set; }
        [Required]
        public DateTime FechaCreacion { get; set; }
        #endregion

        #region ListNav

        //descomentar cuando esten puestas las clases/entidades

        //public CuentaHostel CuentaHotel { get; set; }
        //public CuentaViajero CuentaViajero { get; set; }
        //public List<Comentario> Comentarios { get; set; }
        //public List<Publicacion> Publicaciones { get; set; }

        #endregion

    }
}
