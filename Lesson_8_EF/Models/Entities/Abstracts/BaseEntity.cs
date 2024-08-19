namespace Lesson_8_EF.Models.Entities.Abstracts;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public bool IsDeleted { get; set; } = false;
    public DateTime? CreateDate { get; set; }
    public DateTime? UpdateDate { get; set; }
}
