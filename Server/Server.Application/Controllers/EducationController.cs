using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.Contracts;

namespace Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EducationController : ControllerBase
    {
        private readonly IEducationService _service;
        public EducationController(IEducationService service)
        {
            _service = service;
        }
        [HttpGet]
        public ActionResult Get([FromQuery]DataRequest request)
        {
            var result = _service.List(request);
            return Ok(result);
        }

        [HttpPost]
        public ActionResult Add(DbEducation Education)
        {
            var result = _service.Add(Education);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(DbEducation Education)
        {
            var result = _service.Update(Education);
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
