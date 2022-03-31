using ApiCore.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiCore.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class TheNoiTruController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public TheNoiTruController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet]
        public List<Thenoitru> Get()
        {
           var listThe = _context.Thenoitru.ToList();
            return listThe;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Thenoitru> Get(int id)
        {
            var the = _context.Thenoitru.Find(id);
            if (the == null)
            {
                return NotFound();
            }
            return the;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Thenoitru the)
        {
            //  var department = _context.Department.Where(i => i.DepartmentId == dep.DepartmentId).First();
            var t = _context.Thenoitru.SingleOrDefault(i => i.Mathe == the.Mathe);
            if (the == null)
            {
                return BadRequest();
            }
            else
            {
                t.Mathe = the.Mathe;
                t.Masv = the.Masv;
                t.Hoten = the.Hoten;
                t.Lop = the.Lop;
                t.Ngaysinh = the.Ngaysinh;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Thenoitru the)
        {
            _context.Thenoitru.Add(the);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var the = _context.Thenoitru.Where(i => i.Mathe == id).First();
            if (the == null)
            {
                return NotFound();
            }
            _context.Thenoitru.Remove(the);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
