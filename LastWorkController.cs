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
    public class LastWorkController : ControllerBase
    {
        private readonly DataContext _context;
        public LastWorkController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id == 0)
            {
                var result = _context.LastWork.ToList();
                return Ok(result);
            }
            else
            {
                var result = _context.LastWork.Find(id);
                if (result != null) return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Add(DbLastWork LastWork)
        {
            if (LastWork.Employee == null)
                return BadRequest();
            _context.LastWork.Add(LastWork);
            var result = _context.SaveChanges();
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(int id, DbLastWork LastWork)
        {
            var rem = _context.LastWork.Find(id);
            if (rem != null)
            {
                if (LastWork.Name != null) _context.LastWork.Find(id).Name = LastWork.Name;
                if (LastWork.Experience != null) _context.LastWork.Find(id).Experience = LastWork.Experience;
                if (LastWork.Employee != null) _context.LastWork.Find(id).Employee = LastWork.Employee;
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var rem = _context.LastWork.Find(id);
            if (rem != null)
            {
                _context.LastWork.Remove(rem);
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();

        }
    }
}