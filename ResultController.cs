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
    public class ResultController : ControllerBase
    {
        private readonly DataContext _context;
        public ResultController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id == 0)
            {
                var result = _context.Results.ToList();
                return Ok(result);
            }
            else
            {
                var result = _context.Results.Find(id);
                if (result != null) return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Add(DbResult Results)
        {
            if ((Results.Result1 == null) || (Results.Employee == null) || (Results.Vacancy == null))
                return BadRequest();
            _context.Results.Add(Results);
            var result = _context.SaveChanges();
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(int id, DbResult Results)
        {
            var rem = _context.Results.Find(id);
            if (rem != null)
            {
                if (Results.Test != null) _context.Results.Find(id).Test = Results.Test;
                if (Results.Result1 != null) _context.Results.Find(id).Result1 = Results.Result1;
                if (Results.Employee != null) _context.Results.Find(id).Employee = Results.Employee;
                if (Results.Vacancy != null) _context.Results.Find(id).Vacancy = Results.Vacancy;
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var rem = _context.Results.Find(id);
            if (rem != null)
            {
                _context.Results.Remove(rem);
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();

        }
    }
}