namespace Shared.DataTransferObjects
{
    public record CompanyForCreationDto : CompanyRequestBaseDto
    {
        public IEnumerable<EmployeeForCreationDto>? Employees { get; init; }
    }
}
