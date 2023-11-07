using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using SrceNaRukavu.API.Hasher;
using SrceNaRukavu.Application.People;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Domain;
using System.Runtime.CompilerServices;

namespace SrceNaRukavu.API.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : Controller
    {
       private readonly IPersonService _personService;

        public PersonController(IPersonService personService) { 
           _personService = personService;
        }

        [HttpGet(Name = nameof(GetPersons))]
        public async Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken token)
        {
            return await _personService.GetPersons(token);
        }
        [HttpGet("{id}", Name = nameof(GetPersonById))]
        public async Task<IActionResult> GetPersonById([FromRoute] int id, CancellationToken token)
        {
            PersonDTO person = await _personService.GetPersonById(id, token);
            return person != null ? Ok(person) : NotFound();
        }

        [HttpPost(Name = nameof(CreatePerson))]
        public async Task<IActionResult> CreatePerson([FromBody] CreatePersonDTO person, CancellationToken token)
        {
            if (await _personService.CheckUsernameExistAsync(person.Username))
                return BadRequest(new { Message = "Username already exist" });

            person.Password = PasswordHasher.HashPassword(person.Password);
            person.Token = "";
            await _personService.CreatePerson(person, token);
            return Ok();
        }
        
        [HttpPut(Name = nameof(UpdatePerson))]
        public async Task<IActionResult> UpdatePerson([FromBody] UpdatePersonDTO person, CancellationToken token)
        {
            await _personService.UpdatePerson(person, token);
            return Ok();
        }

        [HttpDelete("{id}", Name = nameof(DeletePerson))]
        public async Task<IActionResult> DeletePerson([FromRoute] int id, CancellationToken token)
        {
            bool deleted = await _personService.DeletePerson(id, token);
            return deleted ? Ok() : NotFound();
        }


        [HttpPost("login")]
        public async Task<IActionResult> AuthenticateUser([FromBody] AuthenticateLogin model)
        {
            if (model == null)
            {
                return NotFound();
            }

            Person person = await _personService.AuthenticateUser(model);

            if (person == null)
            {
                return NoContent();
            }
            if (!PasswordHasher.VerifyPassword(model.Password, person.Password))
            {
                return BadRequest(new { Message = "Password is not correct" });
            }
            person.Token = _personService.CreateJwtToken(person);

            return Ok(
                new
                {
                    Token = person.Token,
                    Message = "Successful login!"
                });
        }
    }
}
