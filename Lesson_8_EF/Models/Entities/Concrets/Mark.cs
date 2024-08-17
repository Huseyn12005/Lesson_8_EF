using Lesson_8_EF.Models.Entities.Abstracts;

namespace Lesson_8_EF.Models.Entities.Concrets;

public class Mark : BaseEntity
{
    public int Value { get; set; }

    // Foreign Keys
    public int? TeacherId { get; set; }
    public int? StudentId { get; set; }
    // Navigation Properties
    public virtual Teacher? Teacher { get; set; }
    public virtual Student? Student { get; set; }
}
