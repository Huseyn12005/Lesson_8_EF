using Lesson_8_EF.Datas;
using Lesson_8_EF.Models.Entities.Concrets;
using Lesson_8_EF.Repositories.Abstracts;

namespace Lesson_8_EF.Repositories.Concrets;

public class TeacherRepository : GenericRepository<Teacher>, ITeacherRepository
{
    public TeacherRepository(AppDbContext? context) : base(context)
    {
    }
}
