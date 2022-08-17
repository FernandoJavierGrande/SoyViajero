using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data
{
    public class EntityBase
    {
        #region Props
        public int ID { get; set; }
        public string Nombre { get; set; }  
        public string Mail { get; set; } //Preguntar lo del mail 
        public string Ciudad { get; set; }
        public string Provincia { get; set; }
        public string Pais { get; set; }
        public string Descripcion { get; set; }
        #endregion
    }
}
