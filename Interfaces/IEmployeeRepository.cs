
using EmployeeApi.Entities;

namespace EmployeeApi.Interfaces
{
    public interface IEmployeeRepository
    {
          Task<PagedUsersResult> GetEmployees(string? term, string? sort,string? sortOrder, int page = 1, int limit = 2);
        Task<EmployeeEntity> GetEmployeeByIdAsync(int id);
        Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity);
        Task<EmployeeEntity> UpdateEmployeeAsync(int employeeId, EmployeeEntity entity);
        Task<bool> DeleteEmployeeAsync(int employeeId);
    }
}