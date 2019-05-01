using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Server.DataAccess;
using Server.Contracts;
using Server.Data;

namespace Server.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VacancyController : ControllerBase
    {
        private readonly IVacancyService _service;
        public VacancyController(IVacancyService service)
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
        public ActionResult Add(DbVacancy vacancy)
        {

            var result = _service.Add(vacancy);
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(DbVacancy vacancy)
        {
            var result = _service.Update(vacancy);
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
