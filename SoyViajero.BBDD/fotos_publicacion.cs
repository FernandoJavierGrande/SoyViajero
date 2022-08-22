using SoyViajero.BBDD.Data;
using SoyViajero.BBDD.Data.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD
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
