using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class Usuario
    {
        public int Id { get; set; }
        
        public string NombreUser { get; set; }

        public string Mail { get; set; }

        public string Pass { get; set; }

        public DateTime fechaCreacion { get; set; }



        #region Lista
        public List<Cuenta> cuentas { get; set; }
        #endregion
    }
}
