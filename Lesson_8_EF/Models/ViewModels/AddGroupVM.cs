using System.ComponentModel.DataAnnotations;

namespace Lesson_8_EF.Models.ViewModels;

public class AddGroupVM
{
    [Required]
    public string? Name { get; set; }
    [Required]
    [MinLength(5)]
    public string? Code { get; set; }
}
