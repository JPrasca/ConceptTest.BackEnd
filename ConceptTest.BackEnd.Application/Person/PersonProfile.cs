using ConceptTest.BackEnd.Application.Person.Queries;
using AutoMapper;

namespace ConceptTest.BackEnd.Application.Person
{

    public class PersonProfile : Profile
    {
        public PersonProfile()
        {
            CreateMap<ConceptTest.BackEnd.Domain.Entities.Person, PersonDto>().ReverseMap();
        }
    }
}