using ConceptTest.BackEnd.Domain.Entities;
using ConceptTest.BackEnd.Domain.Exception;
using ConceptTest.BackEnd.Domain.Ports;

namespace ConceptTest.BackEnd.Domain.Services
{
    [DomainService]
    public class PersonService
    {
        readonly IGenericRepository<Person> _repository;
        public PersonService(IGenericRepository<Person> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository), "No repo available");
        }

        public async Task<Person> RegisterPersonAsync(Person person)
        {
            if (!person.IsUnderAge)
            {             
                return await _repository.AddAsync(person);
            }
            throw new UnderAgeException("The person you're trying to register is not of 18 year or older");
        }

    }
}
