using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class Publicacion1 : EntityBase   //PUBLICAION1 POR EL NAME SPEACE
    {
        [Required]
        [MaxLength(500, ErrorMessage = "La publicacion no debe superar los {1} caracteres")]
        public string Texto { get; set; } //LONG TEXT??

        //CuentasId
        [Required(ErrorMessage = "Cuenta es obligatorio")]
        public int CuentasId { get; set; }

        public List<Comentario> Comentarios { get; set; }
        public List<fotos_publicacion> fotos_publicaciones { get; set; }
    }
}

