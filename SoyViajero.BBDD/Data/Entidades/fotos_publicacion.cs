using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class fotos_publicacion : EntityBase //AGREGAR FOTO 
    {
        // public abstract class fotos ; 

        //id publicacion
        [Required(ErrorMessage = "Id publicacion es obligatorio")]
        public int Publicacion1Id { get; set; }
        public Publicacion1 Publicaciones { get; set; }
    }
}

