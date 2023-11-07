using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SrceNaRukavu.Application.People.Models;
using SrceNaRukavu.Domain;

namespace SrceNaRukavu.Application.People
{
    public interface IPersonService
    {
        public Task<IReadOnlyList<PersonDTO>> GetPersons(CancellationToken cancellationToken);
        public Task<PersonDTO> GetPersonById(int id, CancellationToken cancellationToken);
        public Task<int> CreatePerson(CreatePersonDTO createPersonDTO, CancellationToken cancellationToken);
        public Task UpdatePerson(UpdatePersonDTO updatePersonDTO, CancellationToken cancellationToken);
        public Task<bool> DeletePerson(int id, CancellationToken cancellationToken);
        public Task<Person> AuthenticateUser(AuthenticateLogin authentication);
        public Task<bool> CheckUsernameExistAsync(string username);
        public string CreateJwtToken(Person user);

    }
}
