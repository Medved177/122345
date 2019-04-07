using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;
using Microsoft.EntityFrameworkCore;
using Server.Data;


namespace Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController  : ControllerBase
    {
        private readonly IEmployeeService _service;
        
        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id == 0)
            {
                var result1 = _service.List();
                return Ok(result1.ToArray());
            }
            else
            {
                var result = _service.Find(id);
                if (result != null) return Ok(result);
            }
            return BadRequest();
        }

        /* [HttpGet("{id}")]
         public IActionResult GetById(int id)
         {
             var result = _service.Find(id);
             return Ok(result);
         }
         */
        [HttpPost]
        public ActionResult Post(DbEmployee employee)
        {
            var result = _service.Add(employee);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(DbEmployee employee)
        {
            var result = _service.Update(employee);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var result = _service.Remove(id);
            if (result > 0) return Ok();
            return BadRequest();
        }
    }
}
