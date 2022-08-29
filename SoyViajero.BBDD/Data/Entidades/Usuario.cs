using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    [Index(nameof(NombreUser), Name = "uqUser", IsUnique = true)]
    public class Usuario
    {

        public int Id { get; set; }
        [Required(ErrorMessage ="El nombre de usuario es obligatorio")]
        [MinLength(2, ErrorMessage = "El usuario no puede tener menos de {1} caracteres")]
        public string NombreUser { get; set; }
        [Required(ErrorMessage ="La cuenta del mail es obligatoia")]
        public string Mail { get; set; }
        [Required]
        [MinLength(4, ErrorMessage ="La contraseña debe contener {1} caraceres o mas.")]
        public string Pass { get; set; }

        public DateTime fechaCreacion { get; set; }



        #region Lista
        public List<CuentaHostel> cuentasHostel { get; set; }
        public CuentaViajero cuentaViajero { get; set; }
        #endregion
    }
}
