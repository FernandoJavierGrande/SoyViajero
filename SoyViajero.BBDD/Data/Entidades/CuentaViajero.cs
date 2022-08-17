using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    [Index(nameof(CuentaId), Name = "CuentaId_UQ", IsUnique = true)] 
    public class CuentaViajero : EntityBase
    {
        #region Props
        public int Edad { get; set; }
        public string Apellido { get; set; }
        public int CuentaId { get; set; }
        public Cuenta Cuenta { get; set; }
        #endregion
    }
}
