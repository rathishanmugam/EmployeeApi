using EmployeeApi.Entities;
using EmployeeApi.Interfaces;
using MediatR;

namespace EmployeeApi.Queries
{
    public record GetAllEmployeesQuery(string? term, string? sort,string? sortOrder, int page = 1, int limit = 2) : IRequest<PagedUsersResult>;
    public class GetAllEmployeesQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetAllEmployeesQuery, PagedUsersResult>
    {
        public async Task<PagedUsersResult> Handle(GetAllEmployeesQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployees(request.term, request.sort,request.sortOrder, request.page, request.limit);
        }
    }
}