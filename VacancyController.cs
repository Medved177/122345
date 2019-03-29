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
    public class VacancyController : ControllerBase
    {
        private readonly DataContext _context;
        public VacancyController(DataContext context)
        {
            _context = context;
        }
        [HttpGet]
        public ActionResult Get(int id)
        {
            if (id == 0)
            {
                var result = _context.Vacancies.ToList();
                return Ok(result);
            }
            else
            {
                var result = _context.Vacancies.Find(id);
                if (result != null) return Ok(result);
            }
            return BadRequest();
        }

        [HttpPost]
        public ActionResult Add(DbVacancy vacancy)
        {
            if ((vacancy.Name == null) || (vacancy.Salary == null) || (vacancy.Task == null))
                return BadRequest();
            _context.Vacancies.Add(vacancy);
            var result = _context.SaveChanges();
            if (result > 0) return Ok();
            return BadRequest();
        }

        [HttpPut]
        public ActionResult Put(int id, DbVacancy vacancy)
        {
            var rem = _context.Vacancies.Find(id);
            if (rem != null)
            {
                if (vacancy.Name != null) _context.Vacancies.Find(id).Name = vacancy.Name;
                if (vacancy.Salary != null) _context.Vacancies.Find(id).Salary = vacancy.Salary;
                if (vacancy.Education != null) _context.Vacancies.Find(id).Education = vacancy.Education;
                if (vacancy.Experience != null) _context.Vacancies.Find(id).Experience = vacancy.Experience;
                if (vacancy.Know != null) _context.Vacancies.Find(id).Know = vacancy.Know;
                if (vacancy.Task != null) _context.Vacancies.Find(id).Task = vacancy.Task;
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();
        }

        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var rem = _context.Vacancies.Find(id);
            if (rem != null)
            {
                _context.Vacancies.Remove(rem);
                var result = _context.SaveChanges();
                if (result > 0) return Ok();
            }
            return BadRequest();

        }
    }
}