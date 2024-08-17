using Lesson_8_EF.Datas;
using Lesson_8_EF.Models.Entities.Concrets;
using Lesson_8_EF.Repositories.Abstracts;

namespace Lesson_8_EF.Repositories.Concrets;

public class StudentRepository : GenericRepository<Student>, IStudentRepository
{
    public StudentRepository(AppDbContext? context) : base(context)
    {
    }
}
