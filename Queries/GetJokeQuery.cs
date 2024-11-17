using EmployeeApi.Interfaces;
using EmployeeApi.Models;
using MediatR;

namespace EmployeeApi.Queries
{
    public record GetJokeQuery() : IRequest<Joke>;
    public class GetJokeQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetJokeQuery, Joke>
    {
        public async Task<Joke> Handle(GetJokeQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetJoke();
        }
    }
}