using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Kobe.Domain.Dtos;
using Kobe.Service.Abstract;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Kobe.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IMembershipService _membershipService;
        private readonly IConfiguration _configuration;
        public AccountController(IMembershipService membershipService, IConfiguration configuration)
        {
            _membershipService = membershipService;
            _configuration = configuration;
        }

        [HttpPost]
        [Route("Create")]
        public async Task<IActionResult> CreateUser([FromBody] LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _membershipService.CreateUser(model.Username, model.email, model.Password);
                if (result != null)
                {
                    //return BuildToken(model);
                    ModelState.AddModelError(string.Empty, "Registration successful");
                    return Ok(ModelState);
                }
                else
                {
                    ModelState.AddModelError(string.Empty, "Username or password invalid");
                    return BadRequest(ModelState);
                }
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _membershipService.Login(model.Username, model.email, model.Password);
                    if (user != null)
                    {
                        var tokenObj = BuildToken(model);                        
                        return Ok(model);
                    }
                    else
                    {
                        return BadRequest("Invalid user");
                    }
                }
                else
                {
                    return BadRequest();
                }
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        private LoginViewModel BuildToken(LoginViewModel model)
        {
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.UniqueName, model.email),
                new Claim("miValor", "Lo que yo quiera"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var expirationTimeToken = DateTime.UtcNow.AddHours(8);

            JwtSecurityToken token = new JwtSecurityToken(
               issuer: "https://localhost:43567",
               audience: "https://localhost:43567",
               claims: claims,
               expires: expirationTimeToken,
               signingCredentials: creds);

            //return Ok(new
            //{
            //    token = new JwtSecurityTokenHandler().WriteToken(token),
            //    expiration = expirationTimeToken
            //});       

            model.TokenInfo = new
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = expirationTimeToken
            };
            return model;
        }
    }
}