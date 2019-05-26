using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Server.Contracts;
using Microsoft.EntityFrameworkCore;
using Server.Data;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Cors;

namespace Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private readonly IEmployeeService _service;

        public EmployeeController(IEmployeeService service)
        {
            _service = service;
        }
        
        [HttpGet]
        public ActionResult Get([FromQuery]DataRequest request)
        {
            var result = _service.List(request);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public ActionResult GetById(int id)
        {
            if (id <= 0) return BadRequest();
            var result = _service.Find(id);
            if (result != null) return Ok(result);
            else return BadRequest();
        }
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
