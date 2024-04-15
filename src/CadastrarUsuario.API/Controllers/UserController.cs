using CadastrarUsuario.Domain.Models;
using CadastrarUsuario.Domain.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CadastrarUsuario.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController(IUserService userService) : ControllerBase
    {
        private readonly IUserService _userService = userService;
        [HttpGet]
        public IActionResult Get()
        {
            var result = _userService.GetAll();
            return Ok(result);
        }

        [HttpPost]
        public IActionResult Add(User user)
        {
            _userService.Add(user.Name, user.Password, user.Email, user.Cpf, user.PhoneNumber);
            
            return Ok(user);
        }

        [HttpDelete("{id:guid}")]
        public IActionResult Delete(Guid id) 
        {
            var result = _userService.Delete(id);

            if(result == false)
                return NotFound();

            return Ok(result);
        }

        [HttpGet("{id:guid}")]
        public IActionResult GetById(Guid id)
        {
            var result = _userService.GetById(id);

            if(result == null) 
                return NotFound();

            return Ok(result);
        }

        [HttpPut("{id:guid}")]
        public IActionResult Update(Guid id, User user) 
        {
            var result = _userService.Update(id, user.Name, user.Password, user.Email, user.Cpf, user.PhoneNumber);

            if (result == false)
                return NotFound();

            return Ok(result);
        }
    }
}
