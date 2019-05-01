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
    public class LastWorkController : ControllerBase
    {
        private readonly ILastWorkService _service;
        public LastWorkController(ILastWorkService service)
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
        public ActionResult Add(DbLastWork LastWork)
        {
            var result = _service.Add(LastWork);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(DbLastWork LastWork)
        {
            var result = _service.Update(LastWork);
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
