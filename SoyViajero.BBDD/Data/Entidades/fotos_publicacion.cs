using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class fotos_publicacion : EntityBase 
    {
    
        [Required(ErrorMessage = "Id publicacion es obligatorio")]
        public int PublicacionId { get; set; }

        [Column(TypeName = "nvarchar(450)")]
        public string Foto { get; set; }

        public Publicacion Publicaciones { get; set; }

    }
}

