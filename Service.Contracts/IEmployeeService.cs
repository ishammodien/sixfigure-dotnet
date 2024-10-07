﻿using System.Dynamic;
using Entities.Models;
using Shared.DataTransferObjects;
using Shared.RequestFeatures;

namespace Service.Contracts;

public interface IEmployeeService
{
    Task<(IEnumerable<Entity> employees, MetaData metaData)> GetEmployeesAsync(
        Guid companyId,
        EmployeeParameters employeeParameters,
        bool trackChanges
    );

    Task<EmployeeDto> GetEmployeeAsync(Guid companyId, Guid employeeId, bool trackChanges);

    Task<EmployeeDto> CreateEmployeeForCompanyAsync(
        Guid companyId,
        EmployeeForCreationDto employeeForCreation,
        bool trackChanges
    );

    Task DeleteEmployeeForCompanyAsync(Guid companyId, Guid id, bool trackChanges);

    Task UpdateEmployeeForCompanyAsync(
        Guid companyId,
        Guid id,
        EmployeeForUpdateDto employeeForUpdate,
        bool trackCompanyChanges,
        bool trackEmployeeChanges
    );

    Task<(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity)> GetEmployeeForPatchAsync(
        Guid companyId,
        Guid id,
        bool trackCompanyChanges,
        bool trackEmployeeChanges
    );

    Task SaveChangesForPatchAsync(EmployeeForUpdateDto employeeToPatch, Employee employeeEntity);
}