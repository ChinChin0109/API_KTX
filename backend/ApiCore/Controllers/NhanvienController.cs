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
    public class NhanvienController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public NhanvienController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpGet]
        public List<Nhanvien> Get()
        {
           var listNV = _context.Nhanvien.ToList();
            return listNV;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Nhanvien> Get(int id)
        {
            var nv = _context.Nhanvien.Find(id);
            if (nv == null)
            {
                return NotFound();
            }
            return nv;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Nhanvien nv)
        {
            //  var department = _context.Department.Where(i => i.DepartmentId == dep.DepartmentId).First();
            var t = _context.Nhanvien.SingleOrDefault(i => i.Manv == nv.Manv);
            if (nv == null)
            {
                return BadRequest();
            }
            else
            {
                t.Manv = nv.Manv;
                t.Matk = nv.Matk;
                t.Hoten = nv.Hoten;
                t.Sdt = nv.Sdt;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Nhanvien nv)
        {
            _context.Nhanvien.Add(nv);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var nv = _context.Nhanvien.Where(i => i.Manv == id).First();
            if (nv == null)
            {
                return NotFound();
            }
            _context.Nhanvien.Remove(nv);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
