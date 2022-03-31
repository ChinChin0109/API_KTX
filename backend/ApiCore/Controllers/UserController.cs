using ApiCore.Models;
using ApiCore.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using BC = BCrypt.Net.BCrypt;

namespace ApiCore.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _conf;
        private readonly WebApiChinChinContext _context;

        public UserController(WebApiChinChinContext context, IConfiguration conf)
        {
            _context = context;
            _conf = conf;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<UserInfo> Get(int id)
        {
            var user = _context.UserInfo.Find(id);
            if (user == null)
            {
                return NotFound();
            }
            return user;
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpGet]
        public List<UserInfo> GetUser()
        {
            var user = _context.UserInfo.ToList();
            return user;
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("register")]
        public ActionResult Register(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                if (string.IsNullOrWhiteSpace(userInfo.Password))
                    throw new Exception("Password is required");

                if (_context.UserInfo.Any(x => x.Email == userInfo.Email))
                    throw new Exception("Email \"" + userInfo.Email + "\" is already taken");

                var check = _context.UserInfo.FirstOrDefault(s => s.Email == userInfo.Email);
                if (check == null)
                {

                    userInfo.Password = BC.HashPassword(userInfo.Password);
                    _context.UserInfo.Add(userInfo);
                    _context.SaveChanges();
                }
                else
                {
                    return BadRequest();
                }
            }
            return Ok();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(UserInfo userInfo, string pass = null)
        {
            var user = _context.UserInfo.Find(userInfo.UserId);

            if (user == null)
                throw new Exception("User not found");

            // update email if it has changed
            if (!string.IsNullOrWhiteSpace(userInfo.Email) && userInfo.Email != user.Email)
            {
                // throw error if the new email is already taken
                if (_context.UserInfo.Any(x => x.Email == userInfo.Email))
                    throw new Exception("Email " + userInfo.Email + " is already taken");

                user.Email = userInfo.Email;
            }

            // update user properties if provided
            if (!string.IsNullOrWhiteSpace(userInfo.FirstName))
                user.FirstName = userInfo.FirstName;

            if (!string.IsNullOrWhiteSpace(userInfo.LastName))
                user.LastName = userInfo.LastName;

            if (!string.IsNullOrWhiteSpace(userInfo.Permission))
                user.Permission = userInfo.Permission;

            // update password if provided
            if (!string.IsNullOrWhiteSpace(pass))
            {
                userInfo.Password = BC.HashPassword(userInfo.Password);
            }

            _context.UserInfo.Update(user);
            _context.SaveChanges();
            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var user = _context.UserInfo.Find(id);
            if (user != null)
            {
                _context.UserInfo.Remove(user);
                _context.SaveChanges();
            }
            return NoContent();
        }

        [AllowAnonymous]
        [HttpPost]
        [Route("login")]
        public ActionResult Login(UserInfo userInfo)
        {
            if (ModelState.IsValid)
            {
                AuthenticateModel auth = new AuthenticateModel()
                {
                    Email = userInfo.Email,
                    PassWord = userInfo.Password
                };
                var user = _context.UserInfo.SingleOrDefault(s => s.Email == auth.Email);
                if (user == null || !BC.Verify(auth.PassWord, user.Password))
                {
                    // authentication failed
                    ModelState.AddModelError("Unauthorized", "You are not unauthorized.");
                    return Unauthorized(ModelState);
                }
                else
                {
                    // authentication successful
                    auth.UserId = user.UserId;
                    auth.PassWord = user.Password;
                    auth.Permission = user.Permission;
                    auth.Token = GenerateJwtToken(user);
                    return Ok(auth);
                }
            }
            else
            {
                return BadRequest();
            }
        }

        private string GenerateJwtToken(UserInfo user)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_conf["Jwt:Key"]));

            var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim("Email", user.Email),
                new Claim("Permission", user.Permission)
            };

            var token = new JwtSecurityToken(
                _conf["Jwt:Issuer"],
                _conf["Jwt:Audience"],
                claims,
                expires: DateTime.UtcNow.AddDays(1),
                signingCredentials: signIn);

            var tk = new JwtSecurityTokenHandler().WriteToken(token);

            return tk;
        }

    }
}
