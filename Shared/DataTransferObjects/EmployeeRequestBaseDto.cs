using System.ComponentModel.DataAnnotations;

namespace Shared.DataTransferObjects
{
    public abstract record EmployeeRequestBaseDto
    {
        [Required(ErrorMessage = "Employee `Name` is a required field.")]
        [MaxLength(30, ErrorMessage = "Maximum length for the Employee `Name` field is 30 characters.")]
        public string? Name { get; init; }

        [Range(18, int.MaxValue, ErrorMessage = "Employee `Age` field is required and it can't be lower than 18.")]
        public int Age { get; init; }

        [Required(ErrorMessage = "Employee `Position` is a required field.")]
        [MaxLength(20, ErrorMessage = "Maximum length for the Employee `Position` field is 20 characters.")]
        public string? Position { get; init; }
    }
}
