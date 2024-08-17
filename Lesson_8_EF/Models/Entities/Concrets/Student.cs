
using Lesson_8_EF.Models.Entities.Abstracts;

namespace Lesson_8_EF.Models.Entities.Concrets;

public class Student : BaseEntity
{
    public string? Name { get; set; }
    public string? Surname { get; set; }
    public string? FateherName { get; set; }

    // Foreign Keys
    public int? GroupId { get; set; }

    // Navigation Properties
    public Group? Group { get; set; }
    public virtual ICollection<Teacher> Teachers { get; set; }
    public virtual ICollection<Mark> Marks { get; set; }

}
