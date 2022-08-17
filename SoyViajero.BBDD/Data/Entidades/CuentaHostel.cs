using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    [Index(nameof(CuentaId),  Name = "CuentaId_UQ", IsUnique = true)]
    public class CuentaHostel : BaseCuenta
    {
        #region Props
        [Required]
        public int Telefono { get; set; }   
        public bool Activo { get; set; }
        [Key]
        public int CuentaId { get; set; }

        #endregion

        public Cuenta Cuenta { get; set; }
    }
}


