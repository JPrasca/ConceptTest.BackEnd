using System.ComponentModel.DataAnnotations;
using MediatR;

namespace ConceptTest.BackEnd.Application.Person.Queries {
    public record PersonQuery([Required] Guid Id) : IRequest<PersonDto>;
    
}