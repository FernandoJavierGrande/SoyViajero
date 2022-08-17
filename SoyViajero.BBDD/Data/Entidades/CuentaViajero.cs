using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    [Index(nameof(CuentaId), Name = "CuentaId_UQ", IsUnique = true)] 
    public class CuentaViajero : BaseCuenta
    {
        #region Props
        [Required]
        public int Edad { get; set; }
        [Required]
        public string Apellido { get; set; }
        [Key]
        public int CuentaId { get; set; }

        #endregion

        public Cuenta Cuenta { get; set; }
    }
}
