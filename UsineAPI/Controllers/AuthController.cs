using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;

namespace UsineAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        [HttpPost("token")]
        public ActionResult GetToken()
        {

            //security key
            string securityKey = "le_cle_de_securite_de_gestion_usine";

            //symmetric security key

            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));

            //signing creadentials

            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256Signature);

            //create token

            var token = new JwtSecurityToken(
                issuer: "med.rami",
                audience: "readers",
                expires: DateTime.Now.AddDays(1),
                signingCredentials: signingCredentials




                );


            //return token
            return Ok(new JwtSecurityTokenHandler().WriteToken(token));
        }
    }
}