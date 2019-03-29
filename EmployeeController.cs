using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.DataAccess;

namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly DataContext _context;
        public EmployeeController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id == 0)
            {
                var result = _context.Employees.ToList();
                return Ok(result);
            }
           else
            {
                var result = _context.Employees.Find(id);
                if (result != null) return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Add(DbEmployee employee)
        {
            if ((employee.Family == null) || (employee.Name == null) || (employee.Email == null))
                return BadRequest();
            _context.Employees.Add(employee);
            var result = _context.SaveChanges();
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(int id, DbEmployee employee)
        {
            var rem = _context.Employees.Find(id);
            if (rem != null)
            {
                if (employee.Family != null) _context.Employees.Find(id).Family = employee.Family;
                if (employee.Name != null) _context.Employees.Find(id).Name = employee.Name;
                if (employee.Mname != null) _context.Employees.Find(id).Mname = employee.Mname;
                if (employee.Year != null) _context.Employees.Find(id).Year = employee.Year;
                if (employee.Email != null) _context.Employees.Find(id).Email = employee.Email;
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var rem = _context.Employees.Find(id);
            if (rem != null)
            {
                _context.Employees.Remove(rem);
                var result = _context.SaveChanges();
                if (result >0) return Ok();
            }
            return BadRequest();
            
        }
    }
}
