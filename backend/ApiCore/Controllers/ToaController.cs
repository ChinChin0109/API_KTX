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
    public class ToaController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public ToaController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet]
        public List<Toanha> Get()
        {
           var listToa = _context.Toanha.ToList();
            return listToa;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Toanha> Get(int id)
        {
            var toa = _context.Toanha.Find(id);
            if (toa == null)
            {
                return NotFound();
            }
            return toa;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Toanha toa)
        {
            //  var department = _context.Department.Where(i => i.DepartmentId == dep.DepartmentId).First();
            var t = _context.Toanha.SingleOrDefault(i => i.Matoa == toa.Matoa);
            if (toa == null)
            {
                return BadRequest();
            }
            else
            {
                t.Matoa = toa.Matoa;
                t.Tentoa = toa.Tentoa;
                t.Vitri = toa.Vitri;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Toanha dep)
        {
            _context.Toanha.Add(dep);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var dep = _context.Toanha.Where(i => i.Matoa == id).First();
            if (dep == null)
            {
                return NotFound();
            }
            _context.Toanha.Remove(dep);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
