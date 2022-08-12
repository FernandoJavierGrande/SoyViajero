using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class Cuenta
    {
        #region Prop

        public int Id { get; set; }
        public int UsuarioId { get; set; }

        public string TipoDeCuenta { get; set; }

        public DateTime FechaCreacion { get; set; }
        #endregion

        #region Listas
        //descomentar cuando esten puestas las clases/entidades

        //public List<Cuenta_H> Cuentas_H { get; set; }
        //public List<Cuenta_V> Cuentas_V { get; set; }
        //public List<Comentario> Comentarios { get; set; }
        //public List<Publicacion> Publicaciones { get; set; }

        #endregion

    }
}
