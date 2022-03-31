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
    public class PhieuDienNuocController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public PhieuDienNuocController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet]
        public List<Phieudiennuoc> Get()
        {
           var listPhieu = _context.Phieudiennuoc.ToList();
            return listPhieu;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Phieudiennuoc> Get(int id)
        {
            var phieu = _context.Phieudiennuoc.Find(id);
            if (phieu == null)
            {
                return NotFound();
            }
            return phieu;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Phieudiennuoc phieu)
        {
            var t = _context.Phieudiennuoc.SingleOrDefault(i => i.Maphieu == phieu.Maphieu);
            if (phieu == null)
            {
                return BadRequest();
            }
            else
            {
                t.Maphieu = phieu.Maphieu;
                t.Manv = phieu.Manv;
                t.Maphong = phieu.Maphong;
                t.Ngaytaophieu = phieu.Ngaytaophieu;
                t.Sodien = phieu.Sodien;
                t.Sonuoc = phieu.Sonuoc;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Phieudiennuoc phieu)
        {
            _context.Phieudiennuoc.Add(phieu);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var phieu = _context.Phieudiennuoc.Where(i => i.Maphieu == id).First();
            if (phieu == null)
            {
                return NotFound();
            }
            _context.Phieudiennuoc.Remove(phieu);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
