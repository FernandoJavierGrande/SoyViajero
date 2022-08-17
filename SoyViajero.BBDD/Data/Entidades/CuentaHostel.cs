using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    [Index(nameof(CuentaId),  Name = "CuentaId_UQ", IsUnique = true)]
    public class CuentaHostel : EntityBase
    {
        #region Props 
        public int Telefono { get; set; }   
        public bool Activo { get; set; }
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
        #endregion
    }
}


