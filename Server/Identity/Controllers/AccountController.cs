using Microsoft.AspNetCore.Identity;
using Identity.Models;
using Microsoft.AspNetCore.Authorization;
using Server.Contracts;
using Server.Data;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Identity.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly IEmployeeService _service;
        public AccountController (UserManager<IdentityUser> userManager,
            SignInManager<IdentityUser> signInManager,
            IEmployeeService service)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _service = service;
        }
        [HttpPost]
        public async Task<IActionResult> Register(ModelUser model)
        {
            var user = new IdentityUser { Email = model.Email, UserName = model.Login };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                var employee = new DbEmployee
                  { Email = model.Email ,
                    Family = model.Family,
                    Name = model.Name,
                    Mname = model.Mname,
                    Year = model.Year  };
                _service.Add(employee);
                await _signInManager.SignInAsync(user, false);
                return Ok();
            }
            else return BadRequest();
        }

    }
}
