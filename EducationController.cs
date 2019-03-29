using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.DataAccess;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly DataContext _context;
        public EducationController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id == 0)
            {
                var result = _context.Education.ToList();
                return Ok(result);
            }
            else
            {
                var result = _context.Education.Find(id);
                if (result != null) return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Add(DbEducation Education)
        {
            if ((Education.Type == null) || (Education.University == null) || (Education.Specialty == null) || (Education.Employee == null))
                return BadRequest();
            _context.Education.Add(Education);
            var result = _context.SaveChanges();
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(int id, DbEducation Education)
        {
            var rem = _context.Education.Find(id);
            if (rem != null)
            {
                if (Education.Type != null) _context.Education.Find(id).Type = Education.Type;
                if (Education.University != null) _context.Education.Find(id).University = Education.University;
                if (Education.Specialty != null) _context.Education.Find(id).Specialty = Education.Specialty;
                if (Education.View != null) _context.Education.Find(id).View = Education.View;
                if (Education.Employee != null) _context.Education.Find(id).Employee = Education.Employee;
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var rem = _context.Education.Find(id);
            if (rem != null)
            {
                _context.Education.Remove(rem);
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();

        }
    }
}