using EmployeeApi.Entities;
using EmployeeApi.Interfaces;
using MediatR;

namespace EmployeeApi.Commands
{
    public record AddEmployeeCommand(EmployeeEntity Employee) : IRequest<EmployeeEntity>;


    public class AddEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<AddEmployeeCommand, EmployeeEntity>
    {
        public async Task<EmployeeEntity> Handle(AddEmployeeCommand request, CancellationToken cancellationToken)
        {
            var user = await employeeRepository.AddEmployeeAsync(request.Employee);
            return user;
        }
    }
}