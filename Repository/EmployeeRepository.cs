﻿using Contracts;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repository.Extensions;
using Shared.RequestFeatures;

namespace Repository;

internal sealed class EmployeeRepository : RepositoryBase<Employee>, IEmployeeRepository
{
    public EmployeeRepository(RepositoryContext repositoryContext)
        : base(repositoryContext)
    {
    }

    public async Task<PagedList<Employee>> GetEmployeesAsync(Guid companyId, EmployeeParameters employeeParameters, bool trackChanges)
    {
        var employees = await FindByCondition(
            e => e.CompanyId.Equals(companyId) &&
            (e.Age >= employeeParameters.MinAge && e.Age <= employeeParameters.MaxAge), trackChanges            )
            .FilterEmployees(employeeParameters.MinAge, employeeParameters.MaxAge)
            .Search(employeeParameters.SearchTerm!)
            .Sort(employeeParameters.OrderBy!)
            .ToListAsync();
        return PagedList<Employee>
            .ToPagedList(employees, employeeParameters.PageNumber, employeeParameters.PageSize);
    }

    public async Task<Employee?> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges) =>
    await FindByCondition(e => e.CompanyId.Equals(companyId) && e.Id.Equals(employeeId), trackChanges)
    .SingleOrDefaultAsync();

    public void CreateEmployeeForCompany(Guid companyId, Employee employee)
    {
        employee.CompanyId = companyId;
        Create(employee);
    }

    public void DeleteEmployee(Employee employee) => Delete(employee);
}
