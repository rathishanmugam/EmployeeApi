using EmployeeApi.Interfaces;
using EmployeeApi.Models;
using MediatR;

namespace EmployeeApi.Queries
{
    public record GetPostQuery() : IRequest<List<Post>>;
    public class GetPostQueryHandler(IExternalVendorRepository externalVendorRepository)
        : IRequestHandler<GetPostQuery, List<Post>>
    {
        public async Task<List<Post>> Handle(GetPostQuery request, CancellationToken cancellationToken)
        {
            return await externalVendorRepository.GetPost();
        }
    }
}