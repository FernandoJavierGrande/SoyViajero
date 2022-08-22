using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{   

    //[Index(nameof(Id), Name = "CuentaId_UQ", IsUnique = true)] 
    public class CuentaViajero : BaseCuenta
    {
        #region Props
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Apellido { get; set; }
        public int UsuarioId { get; set; }


        #endregion
        public List<Publicacion> publicacionesV { get; set; }
        public List<Comentario> comentariosV{ get; set; }
    }
}
