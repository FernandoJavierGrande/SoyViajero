using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data
{
    public class BaseCuenta
    {
        #region Props
        [Key]
        public string Id { get; set; }
        [Required(ErrorMessage ="El Nombre es un campo obligatorio")]
        [MinLength(2, ErrorMessage = $"El nombre no puede tener menos de [1] caracteres")]
        public string Nombre { get; set; }
        [Required(ErrorMessage = "El Mail es un campo obligatorio")]
        public string Mail { get; set; } //Preguntar lo del mail 
        [Required(ErrorMessage = "Ciudad es un campo obligatorio")]
        public string Ciudad { get; set; }
        [Required(ErrorMessage = "Provincia es un campo obligatorio")]
        public string Provincia { get; set; }
        [Required(ErrorMessage = "Pais es un campo obligatorio")]
        public string Pais { get; set; }
        public string Descripcion { get; set; }
        public string FotoPerfil { get; set; }
        #endregion
    }
}
