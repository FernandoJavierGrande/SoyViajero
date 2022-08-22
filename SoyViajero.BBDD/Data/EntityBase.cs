using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data
{
    public class EntityBase
    {
        [Required]
        public string ID { get; set; }
        public DateTime FechaCreacion { get; set; }
    }
}

