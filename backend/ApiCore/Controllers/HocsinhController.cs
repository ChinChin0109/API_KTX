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
    public class HocsinhController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public HocsinhController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet]
        public List<Hocsinh> Get()
        {
           var lisths = _context.Hocsinh.ToList();
            return lisths;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Hocsinh> Get(int id)
        {
            var hs = _context.Hocsinh.Find(id);
            if (hs == null)
            {
                return NotFound();
            }
            return hs;

        }

        [Authorize(Policy = "AccessCommon")]
        [HttpPut]
        public ActionResult Put(Hocsinh hs)
        {
            var t = _context.Hocsinh.SingleOrDefault(i => i.Masv == hs.Masv);
            if (hs == null)
            {
                return BadRequest();
            }
            else
            {
                t.Masv = hs.Masv;
                t.Maphong = hs.Maphong;
                t.Hoten = hs.Hoten;
                t.Lop = hs.Lop;
                t.Ngaysinh = hs.Ngaysinh;
                t.Gioitinh = hs.Gioitinh;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpPost]
        public ActionResult Post(Hocsinh hs)
        {
            _context.Hocsinh.Add(hs);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var hs = _context.Hocsinh.Where(i => i.Masv == id).First();
            if (hs == null)
            {
                return NotFound();
            }
            _context.Hocsinh.Remove(hs);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
