using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Linq;
using TalendingBarbershop.Data.DTOs;
using TalendingBarbershop.Data.Models;
using TalendingBarbershop.Data.Responses;
using Microsoft.IdentityModel.Tokens;
using Microsoft.Extensions.Configuration;
using Microsoft.AspNetCore.DataProtection;
using System.Security.Cryptography;
using TalendingBarbershop.Data.Security;

namespace TalendingBarbershop.Services.Login
{
    public class Login : ILogin
    {
        private DbTalendigBarbershopContext _dbContext;
        private IConfiguration _configuration;
        private TblUsers _users;
        private Encrypt _encrypt;

        public Login(IConfiguration configuration)
        {
            //...
            _dbContext = new DbTalendigBarbershopContext();
            _configuration = configuration;
            _encrypt = new Encrypt();
        }
        public ResponseToken BuilderToken(LoginPerson loginPerson)
        {
            var claims = new List<Claim>{
            new Claim( JwtRegisteredClaimNames.UniqueName, "aquí agregamos un valor único" ),
            new Claim( "email", loginPerson.Email ),
            new Claim( JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString() )
            };

            string userName = "nombre de usuario";
            string rolName = "rol asignado";
            var rolAsignado = SearchUser(loginPerson);

            if (rolAsignado == null)
            {
                return new ResponseToken()
                {
                    // La clase que es se esta retornando fue la creada en el curso
                    Token = string.Empty,
                    Expiration = DateTime.Now.Date,
                    RolPerson = 0
                };
            }

            claims.Add( new Claim( userName, rolAsignado.Username) );
            claims.Add( new Claim( rolName, rolAsignado.RoleId.ToString() ) );

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWTkey"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expiration = DateTime.UtcNow.AddHours(1);

            JwtSecurityToken token = new JwtSecurityToken(
                issuer: null,
                audience: null,
                claims: claims, // es la información segura que guardamos más arriba.
                expires: expiration,
                signingCredentials: creds);

            return new ResponseToken()
            {
                // La clase que es se esta retornando fue la creada en el curso
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = expiration,
                RolPerson = rolAsignado.RoleId
            };
        }

        private TblUsers SearchUser(LoginPerson login)
        {
            try
            {
                string passwordProtected = _encrypt.EncriptingPassword(login.Password);
                _users = _dbContext.TblUsers.Where(u => u.Email == login.Email && u.Password == passwordProtected).FirstOrDefault();
                if (_users != null)
                {
                    return _users;
                }
            }
            catch (Exception e)
            {
            }
            return null;
        }
    }
}
