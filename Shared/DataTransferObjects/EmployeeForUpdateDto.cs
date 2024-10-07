using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    //public record EmployeeForUpdateDto(string Name, int Age, string Position);
    public record EmployeeForUpdateDto : EmployeeRequestBaseDto
    {
       
    }
}
