using System.Linq.Expressions;
using EmployeeApi.Data;
using EmployeeApi.Entities;
using EmployeeApi.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmployeeApi.Repositories
{
    public class EmployeeRepository(AppDbContext dbContext) : IEmployeeRepository
    {
        public async Task<PagedUsersResult> GetEmployees(string? term, string? sort,string? sortOrder, int page = 1, int limit = 2)
        {
            IQueryable<EmployeeEntity> users;
        if (string.IsNullOrWhiteSpace(term))
            users = dbContext.Employees;
        else
        {
            term = term.Trim().ToLower();
            // filtering records with author or title
            users = dbContext.Employees
                .Where(b => b.Name.ToLower().Contains(term) || b.Phone.ToLower().Contains(term)|| b.Email.ToLower().Contains(term));
        }
        // sorting
        Expression<Func<EmployeeEntity, string>> keySelector = sort?.ToLower() switch
        {
            "name" => employee => employee.Name,
            "email" => employee => employee.Email,
            "phone" => employee => employee.Phone,
            _ => employee => employee.Id.ToString()
        };
        if (!string.IsNullOrWhiteSpace(sort))
        {
            if (sortOrder?.ToLower() == "desc")
            {
                users = dbContext.Employees.OrderByDescending(keySelector);
            }
            else
            {
                users = dbContext.Employees.OrderBy(keySelector);
            }
        }
        // apply pagination
        // totalCount=101 ,page=1,limit=10 (10 record per page)
        var totalCount = await dbContext.Employees.CountAsync(); 
        var totalPages = (int)Math.Ceiling(totalCount / (double)limit);
         var HasNextPage = page * limit < totalCount;
         var HasPreviousPage = page > 1;  
        // page=1 , skip=(1-1)*10=0, take=10
        // page=2 , skip=(2-1)*10=10, take=10
        // page=3 , skip=(3-1)*10=20, take=10
        var pagedEmployees = await users.Skip((page - 1) * limit).Take(limit).ToListAsync();

        var pagedEmployeeData = new PagedUsersResult
        {
            Employees = pagedEmployees,
            TotalCount = totalCount,
            TotalPages = totalPages,
            HasNextPage = HasNextPage,
            HasPreviousPage =HasPreviousPage
        };
        return pagedEmployeeData;
            // return await dbContext.Employees.ToListAsync();
        }

        public async Task<EmployeeEntity> GetEmployeeByIdAsync(int id)
        {
            return await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<EmployeeEntity> AddEmployeeAsync(EmployeeEntity entity)
        {
            // entity.Id = Guid.NewGuid();
            dbContext.Employees.Add(entity);

            await dbContext.SaveChangesAsync();

            return entity;
        }

        public async Task<EmployeeEntity> UpdateEmployeeAsync(int employeeId, EmployeeEntity entity)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee is not null)
            {
                employee.Name = entity.Name;
                employee.Email = entity.Email;
                employee.Phone = entity.Phone;

                await dbContext.SaveChangesAsync();

                return employee;
            }

            return entity;
        }

        public async Task<bool> DeleteEmployeeAsync(int employeeId)
        {
            var employee = await dbContext.Employees.FirstOrDefaultAsync(x => x.Id == employeeId);

            if (employee is not null)
            {
                dbContext.Employees.Remove(employee);

                return await dbContext.SaveChangesAsync() > 0;
            }

            return false;
        }
    }
}