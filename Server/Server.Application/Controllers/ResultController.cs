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
