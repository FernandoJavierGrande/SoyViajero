using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        //PublicacionId
        [Required(ErrorMessage = "Id publicacion es obligatorio")]
        public int Publicacion1Id { get; set; }
        public Publicacion1 Publicaciones { get; set; }

        //CuentasId
        [Required(ErrorMessage = "Cuenta es obligatorio")]
        public int CuentasId { get; set; }
    }
}
