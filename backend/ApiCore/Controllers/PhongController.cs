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
    public class PhongController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public PhongController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet]
        public List<Phong> Get()
        {
           var listPhong = _context.Phong.ToList();
            return listPhong;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Phong> Get(int id)
        {
            var phong = _context.Phong.Find(id);
            if (phong == null)
            {
                return NotFound();
            }
            return phong;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Phong p)
        {
            //  var department = _context.Department.Where(i => i.DepartmentId == dep.DepartmentId).First();
            var phong = _context.Phong.SingleOrDefault(i => i.Maphong == p.Maphong);
            if (phong == null)
            {
                return BadRequest();
            }
            else
            {
                phong.Maphong = p.Maphong;
                phong.Tenphong = p.Tenphong;
                phong.Matoa = p.Matoa;
                phong.Tang = p.Tang;
                phong.Tsogiuong = p.Tsogiuong;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Phong dep)
        {
            _context.Phong.Add(dep);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var p = _context.Phong.Where(i => i.Maphong == id).First();
            if (p == null)
            {
                return NotFound();
            }
            _context.Phong.Remove(p);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
