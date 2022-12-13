using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class Comentario : EntityBase
    {
        [Required]
        [MaxLength(300, ErrorMessage = "El comentario no debe superar los {1} caracteres")]
        public string texto { get; set; }

        [Required(ErrorMessage = "Id publicacion es obligatorio")]
        public int PublicacionId { get; set; }

        [Required(ErrorMessage = "Cuenta es obligatorio")]
        public string CuentasId { get; set; }

        [NotMapped]
        public string Nombre { get; set; } 

    }
}
