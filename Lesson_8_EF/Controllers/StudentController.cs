using Lesson_8_EF.Models.Entities.Concrets;
using Lesson_8_EF.Models.ViewModels;
using Lesson_8_EF.Models.ViewModels.Student;
using Lesson_8_EF.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;
using System.Text.RegularExpressions;

namespace Lesson_8_EF.Controllers;

public class StudentController : Controller
{

    public readonly IStudentRepository? _stRepo;

    public StudentController(IStudentRepository? stRepo)
    {
        _stRepo = stRepo;
    }
    public IActionResult Index()
    {
        return View();
    }


    [HttpGet]
    public async Task<IActionResult> AllStudents()
    {
        var students = await _stRepo!.GetAllAsync();

        var studentsVM = new List<ShowStViewModel>();
        foreach (var st in students)
        {
            var newSt = new ShowStViewModel()
            {
                Id = st.Id,
                Name = st.Name,
                Surname = st.Surname,
                FateherName = st.FateherName,
            };
            studentsVM.Add(newSt);
        }

        return View(studentsVM);
    }





    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddStViewModel StudentviewModel)
    {
        if (ModelState.IsValid)
        {
            var student = new Student()
            {

                Name = StudentviewModel.Name,
                Surname = StudentviewModel.Surname,
                FateherName = StudentviewModel.FateherName,
                CreateDate = DateTime.Now,
            };

            await _stRepo!.AddAsync(student);
            await _stRepo.SaveChangeAsync();
            return RedirectToAction("AllStudents");
        }

        return View(StudentviewModel);
    }


    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var student = await _stRepo!.GetByIdAsync(id);
        if (student is null)
        {
            ViewBag.Error = $@"{id} -li Element tapilmadi";
            return RedirectToAction("GetAll");
        }

        await _stRepo.DeleteAsync(student);
        await _stRepo.SaveChangeAsync();

        return RedirectToAction("AllStudents");
    }




    [HttpGet]
    public async Task<IActionResult> UpdateStudent(int id)
    {
        var entity = await _stRepo?.GetByIdAsync(id)!;
        return View(entity);
    }

    [HttpPost]
    public async Task<IActionResult> UpdateStudent(AddStViewModel student, int id)
    {

        var entity = await _stRepo?.GetByIdAsync(id)!;

        entity.Name = student.Name;
        entity.Surname = student.Surname;
        entity.FateherName = student.FateherName;
        entity.UpdateDate = DateTime.Now;


        await _stRepo!.UpdateAsync(entity);
        await _stRepo.SaveChangeAsync();

        return RedirectToAction("AllStudents");
    }
}
