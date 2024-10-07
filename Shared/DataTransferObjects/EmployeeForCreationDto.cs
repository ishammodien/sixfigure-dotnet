namespace Shared.DataTransferObjects
{
    //public record EmployeeForCreationDto(
    //    [Required(ErrorMessage = "Employee `Name` is a required field.")]
    //    [MaxLength(30, ErrorMessage = "Maximum length for Employee `Name` is 30 characters.")]
    //    string Name,

    //    [Required(ErrorMessage = "Employee `Age` is a required field.")]
    //    int Age,

    //    [Required(ErrorMessage = "Employee `Position` is a required field.")]
    //    [MaxLength(20,ErrorMessage = "Maximum length for the `Employee` Position is 20 characters.")]
    //    string Position
    //);

    public record EmployeeForCreationDto : EmployeeRequestBaseDto
    {

    }
}
