using EmployeeApi.Interfaces;
using MediatR;

namespace EmployeeApi.Commands
{
    public record DeleteEmployeeCommand(int EmployeeId) : IRequest<bool>;

    internal class DeleteEmployeeCommandHandler(IEmployeeRepository employeeRepository)
        : IRequestHandler<DeleteEmployeeCommand, bool>
    {
        public async Task<bool> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
        {
            return await employeeRepository.DeleteEmployeeAsync(request.EmployeeId);
        }
    }
}