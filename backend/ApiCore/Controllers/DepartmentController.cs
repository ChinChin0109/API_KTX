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
    public class DepartmentController : ControllerBase
    {
        private readonly WebApiChinChinContext _context;

        public DepartmentController(WebApiChinChinContext context)
        {
            _context = context;
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet]
        public List<Department> Get()
        {
           var listDep = _context.Department.ToList();
            return listDep;
            
        }

        [Authorize(Policy = "AccessCommon")]
        [HttpGet("{id}")]
        public ActionResult<Department> Get(int id)
        {
            var dep = _context.Department.Find(id);
            if (dep == null)
            {
                return NotFound();
            }
            return dep;

        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPut]
        public ActionResult Put(Department dep)
        {
            //  var department = _context.Department.Where(i => i.DepartmentId == dep.DepartmentId).First();
            var department = _context.Department.SingleOrDefault(i => i.DepartmentId == dep.DepartmentId);
            if (department == null)
            {
                return BadRequest();
            }
            else
            {
                department.DepartmentId = dep.DepartmentId;
                department.DepartmentName = dep.DepartmentName;
                _context.SaveChanges();

                return NoContent();
            }
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpPost]
        public ActionResult Post(Department dep)
        {
            _context.Department.Add(dep);
            _context.SaveChanges();

            return NoContent();
        }

        [Authorize(Policy = "AdminAccess")]
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            var dep = _context.Department.Where(i => i.DepartmentId == id).First();
            if (dep == null)
            {
                return NotFound();
            }
            _context.Department.Remove(dep);
            _context.SaveChanges();

            return NoContent();
        }

    }
}
