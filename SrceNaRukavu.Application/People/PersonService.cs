using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Application.Persistence;
using SrceNaRukavu.Domain;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace SrceNaRukavu.Application.People
{
    public class PersonService : IPersonService
    {
        private readonly SrceNaRukavuDbContext dbContext;

        public PersonService(SrceNaRukavuDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Person> AuthenticateUser(AuthenticateLogin authentication)
        {
            return await dbContext.Persons.Include(p => p.Role).FirstOrDefaultAsync(auth => auth.Username == authentication.Username);
        }

        public async Task<bool> CheckUsernameExistAsync(string username)
        {
            return await dbContext.Persons.AnyAsync(auth => auth.Username == username);
        }

        public string CreateJwtToken(Person user)
        {
            var jwtTokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes("WE NEED AT LEAST FORTY DIFFERENT CHARS!!");
            var identity = new ClaimsIdentity(new Claim[]
            {
                new Claim(ClaimTypes.Role, $"{(user.Role.Id)}"),
                new Claim(ClaimTypes.Name, $"{user.Name} {user.Surname}"),
                new Claim("Id", $"{user.Id}")
            });

            var credentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = identity,
                Expires = DateTime.Now.AddDays(1),
                SigningCredentials = credentials
            };

            var token = jwtTokenHandler.CreateToken(tokenDescriptor);
            return jwtTokenHandler.WriteToken(token);
        }   
        public async Task<int> CreatePerson(CreatePersonDTO createPersonDTO, CancellationToken cancellationToken)
        {
            ArgumentNullException.ThrowIfNull(createPersonDTO,nameof(createPersonDTO));

            Person person = new Person()
            {
                Name = createPersonDTO.Name,
                Surname = createPersonDTO.Surname,
                Address = createPersonDTO.Address,
                City = createPersonDTO.City,
                Email = createPersonDTO.Email,
                Telephone = createPersonDTO.Telephone,
                RoleId = createPersonDTO.Role.Id,
                Username = createPersonDTO.Username,
                Password = createPersonDTO.Password
            };
            dbContext.Add(person);
            await dbContext.SaveChangesAsync();
            return person.Id;
        }

        public async Task<bool> DeletePerson(int id, CancellationToken cancellationToken)
        {
           Person person = await dbContext.Persons.Where(person => person.Id == id).FirstOrDefaultAsync(cancellationToken);
            if(person  == null)
            {
                return false;
            }
            dbContext.Persons.Remove(person);
            await dbContext.SaveChangesAsync(cancellationToken);
            return true;
        }

        public async Task<PersonDTO> GetPersonById(int id, CancellationToken cancellationToken)
        {
            return await dbContext.Persons.Where(person => person.Id == id)
               .Select(person => new PersonDTO
               {
                   Id = person.Id,
                   Name = person.Name,
                   Surname = person.Surname,
                   Email = person.Email,
                   Role = person.Role,
                   Telephone = person.Telephone,
                   Address = person.Address,
                   City = person.City,
                   Username = person.Username,
                   Password = person.Password,
               }).FirstOrDefaultAsync(cancellationToken);
        }

        public async Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken cancellationToken)
        {
            return await dbContext.Persons.AsNoTracking()
                .Select(person => new PersonDTO
                {
                    Id = person.Id,
                    Name = person.Name,
                    Surname = person.Surname,
                    Email = person.Email,
                    Role = person.Role,
                    Telephone = person.Telephone,
                    Address = person.Address,
                    City = person.City,
                    Username = person.Username,
                    Password = person.Password
                }).ToListAsync(cancellationToken);
        }

        public async Task UpdatePerson(UpdatePersonDTO updatePersonDTO, CancellationToken cancellationToken)
        {
            Person person = await dbContext.Persons.FindAsync(new object[] { updatePersonDTO.Id}, cancellationToken: cancellationToken);

            if (person != null) {
                person.Name = updatePersonDTO.Name;
                person.Surname = updatePersonDTO.Surname;
                person.Email = updatePersonDTO.Email;  
                person.Address = updatePersonDTO.Address; 
                person.City = updatePersonDTO.City;
                person.Telephone = updatePersonDTO.Telephone;
                person.Role = updatePersonDTO.Role;
                person.Username = updatePersonDTO.Username;
                person.Password = updatePersonDTO.Password;
            }

            await dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
