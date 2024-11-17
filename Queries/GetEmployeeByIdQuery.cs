using EmployeeApi.Entities;
using EmployeeApi.Interfaces;
using MediatR;

namespace EmployeeApi.Queries
{
    public record GetEmployeeByIdQuery(int EmployeeId) : IRequest<EmployeeEntity>;

    public class GetEmployeeByIdQueryHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<GetEmployeeByIdQuery, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(GetEmployeeByIdQuery request, CancellationToken cancellationToken)
        {
            return await employeeRepository.GetEmployeeByIdAsync(request.EmployeeId);
        }
    }
}