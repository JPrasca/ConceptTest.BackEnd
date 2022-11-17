using System.Data;
using AutoMapper;
using Dapper;
using ConceptTest.BackEnd.Domain.Ports;
using MediatR;

namespace ConceptTest.BackEnd.Application.Person.Queries
{
    public class PersonQueryHandler : IRequestHandler<PersonQuery, PersonDto>
    {

        private readonly IDbConnection _dapperSource;
        private readonly IMapper _mapper;

        public PersonQueryHandler(IDbConnection dapperSource, IMapper mapper)
        {
            _dapperSource = dapperSource ?? throw new ArgumentNullException(nameof(dapperSource));
            _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        }

        public async Task<PersonDto> Handle(PersonQuery request, CancellationToken cancellationToken)
        {
            _ = request ?? throw new ArgumentNullException(nameof(request), "request object needed to handle this task");
            var personInfo = await _dapperSource.QuerySingleOrDefaultAsync<ConceptTest.BackEnd.Domain.Entities.Person>("select * from block.Person where Id = @id", new {Id = request.Id});            
            return _mapper.Map<PersonDto>(personInfo);
        }

        
    }
}