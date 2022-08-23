﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SoyViajero.BBDD.Data.Entidades
{
    public class Publicacion : EntityBase   //PUBLICAION1 POR EL NAME SPEACE
    {
        [Required]
        [Column(TypeName ="nvarchar(450)")]
        [MaxLength(500, ErrorMessage = "La publicacion no debe superar los {1} caracteres")]
        public string Texto { get; set; } //LONG TEXT??

        //CuentasId

        [ForeignKey("CuentaHostel")]
        [Required(ErrorMessage = "Cuenta es obligatorio")]
        public int CuentasId { get; set; }


        public CuentaHostel cuentaHostel { get; set; }
        public CuentaViajero cuentaViajero { get; set; }


        public List<Comentario> Comentarios { get; set; }
        public List<fotos_publicacion> fotos_publicaciones { get; set; }
    }
}
