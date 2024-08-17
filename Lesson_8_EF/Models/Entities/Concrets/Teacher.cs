using Lesson_8_EF.Models.Entities.Abstracts;

namespace Lesson_8_EF.Models.Entities.Concrets;

public class Teacher : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FateherName { get; set; }
    public double? Salary { get; set; }

    // Foreign Keys
    // Navigation Properties
    public virtual ICollection<Student> Students { get; set; }
    public virtual ICollection<Group> Groups { get; set; }
}
