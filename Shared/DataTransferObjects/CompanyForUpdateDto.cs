namespace Shared.DataTransferObjects
{
    public record CompanyForUpdateDto : CompanyRequestBaseDto
    {
        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
