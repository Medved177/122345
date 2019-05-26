using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.Data;
using Server.DataAccess;
using Server.Contracts;

namespace Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResultController : ControllerBase
    {
        private readonly IResultService _service;
        public ResultController(IResultService service)
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
        public ActionResult Add(DbResult Results)
        {
            var result = _service.Add(Results);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(DbResult Results)
        {
            var result = _service.Update(Results);
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
