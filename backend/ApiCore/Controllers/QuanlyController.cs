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
    public class QuanlyController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public QuanlyController(WebApiChinChinContext context)
        {
            _context = context;
        }


        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Quanly> Get(int id)
        {
            var ql = _context.Quanly.Find(id);
            if (ql == null)
            {
                return NotFound();
            }
            return ql;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Quanly ql)
        {
            //  var department = _context.Department.Where(i => i.DepartmentId == dep.DepartmentId).First();
            var t = _context.Quanly.SingleOrDefault(i => i.Maql == ql.Maql);
            if (ql == null)
            {
                return BadRequest();
            }
            else
            {
                t.Maql = ql.Maql;
                t.Matk = ql.Matk;
                t.Hoten = ql.Hoten;
                t.Sdt = ql.Sdt;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Quanly ql)
        {
            _context.Quanly.Add(ql);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var ql = _context.Quanly.Where(i => i.Maql == id).First();
            if (ql == null)
            {
                return NotFound();
            }
            _context.Quanly.Remove(ql);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
