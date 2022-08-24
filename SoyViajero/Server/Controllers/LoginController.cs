﻿using Microsoft.AspNetCore.Mvc;
using SoyViajero.BBDD.Data.Entidades;
using System.Security.Cryptography;
using System.Text;
using Microsoft.EntityFrameworkCore;
using SoyViajero.BBDD.Data;

namespace SoyViajero.Server.Controllers
{
    [ApiController]
    [Route("api/Login")]
    public class LoginController : ControllerBase
    {
        private readonly Context context;

        public  LoginController(Context context) => this.context = context;




        #region get
        [HttpGet]
        public async Task<ActionResult<int>> Get(string usuario,string pass)
        {
            {
                int IdUser;
                try
                {
                    pass = ConvertirSha256(pass);

                    IdUser = (from u in context.Usuarios where u.NombreUser == usuario && u.Pass == pass select u).First().Id;



                }
                catch (Exception)
                {

                    return BadRequest("El usuario o contraseña no son correctos");
                }

                return IdUser;
            }
        }
            #endregion

            #region post
            [HttpPost]
        public ActionResult Registro(Usuario usuario)
        {
            usuario.Pass = ConvertirSha256(usuario.Pass);

            try
            {
                if (!UserExist(usuario.NombreUser))
                {
                    return BadRequest($"El nombre de usuario '{usuario.NombreUser}' ya existe.");
                }
                context.Usuarios.Add(usuario);

                context.SaveChangesAsync();
                return Ok();
            }
            catch (Exception)
            {
                return BadRequest("Error, vuelva a intentar");
            }
        }
        #endregion



        public static string ConvertirSha256(string texto)
        {
            StringBuilder sb = new StringBuilder();
            using (SHA256 hash = SHA256.Create())
            {
                Encoding enc = Encoding.UTF8;
                byte[] result = hash.ComputeHash(enc.GetBytes(texto));
                foreach (byte b in result)
                {
                    sb.Append(b.ToString("x2"));
                }
            }
            return sb.ToString();
        }
        private bool UserExist(string userName) //confirma si el usuario con nombre x existe
        {
            var user = context.Usuarios.Where(u => u.NombreUser == userName).FirstOrDefault();
            if (user != null)
                return false;
            return true;
        }
    }
}
