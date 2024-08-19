using Lesson_8_EF.Models.Entities.Concrets;
using Lesson_8_EF.Models.ViewModels;
using Lesson_8_EF.Repositories.Abstracts;
using Microsoft.AspNetCore.Mvc;

namespace Lesson_8_EF.Controllers;

public class GroupController : Controller
{
    public readonly IGroupRepository? _groupRepo;

    public GroupController(IGroupRepository? groupRepo)
    {
        _groupRepo = groupRepo;
    }

    [HttpGet]
    public IActionResult Add()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Add(AddGroupVM model)
    {
        if(!ModelState.IsValid)
            return View(model);

        Group group = new Group()
        {
            Name = model.Name,
            Code = model.Code,
            CreateDate = DateTime.Now
        };

        await _groupRepo?.AddAsync(group)!;
        await _groupRepo.SaveChangeAsync();
        return RedirectToAction("GetAll");
    }

    [HttpGet]
    public async Task<IActionResult> GetAll()
    {
        var groups = await _groupRepo?.GetAllAsync()!;

        var groupsVm = new List<ShowGroupVM>();
        foreach (var group in groups)
        {
            var newG = new ShowGroupVM()
            {
                Id = group.Id,
                Name = group.Name,
                Code = group.Code,
                CreatedDate = group.CreateDate,
                TeacherName = group?.Teacher?.Name
            };
            groupsVm.Add(newG);
        }
        

        return View(groupsVm);
    }

    [HttpGet]
    public async Task<IActionResult> Delete(int id)
    {
        var entity = await _groupRepo?.GetByIdAsync(id)!;
        if(entity is null)
        {
            ViewBag.Error = $@"{id} -li Element tapilmadi";
            return RedirectToAction("GetAll");
        }

        await _groupRepo.DeleteAsync(entity);
        await _groupRepo.SaveChangeAsync();

        return RedirectToAction("GetAll");
    }

}
