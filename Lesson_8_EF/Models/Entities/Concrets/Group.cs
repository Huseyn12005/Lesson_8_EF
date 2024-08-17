using Lesson_8_EF.Models.Entities.Abstracts;

namespace Lesson_8_EF.Models.Entities.Concrets;

public class Group : BaseEntity
{
    public string? Name { get; set; }
    public string? Code { get; set; }

    // Foreign Keys
    public int? TeacherId { get; set; }
    // Navigation Properties
    public virtual Teacher? Teacher { get; set; }
    public virtual ICollection<Student> Students { get; set; }

}
