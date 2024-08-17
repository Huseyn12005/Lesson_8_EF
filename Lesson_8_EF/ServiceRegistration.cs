using Lesson_8_EF.Datas;
using Lesson_8_EF.Repositories.Abstracts;
using Lesson_8_EF.Repositories.Concrets;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;

namespace Lesson_8_EF;

public static class ServiceRegistration
{
    public static WebApplicationBuilder AddServices(this WebApplicationBuilder builder)
    {


        builder.Services.AddDbContext<AppDbContext>(op =>
                    op.UseSqlServer(builder.Configuration.GetConnectionString("default")));

        //builder.Services.AddDbContext<AppDbContext>(op=>op.UseSqlServer(builder.Configuration.GetSection("a").GetSection("s").Value));

        builder.Services.AddScoped<IGroupRepository, GroupRepository>();
        builder.Services.AddScoped<IStudentRepository, StudentRepository>();
        builder.Services.AddScoped<ITeacherRepository, TeacherRepository>();
        return builder;
    }
}
