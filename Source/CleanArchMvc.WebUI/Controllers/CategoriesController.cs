using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class CategoriesController(ICategoryService categoryService) : Controller
{
    public async Task<ViewResult> Index() 
    {
        var categories = await categoryService.GetCategoriesAsync();
        return View(categories);
    }

    public ViewResult Create() => View();

    [ActionName(nameof(Create))]
    [HttpPost]
    public async Task<ActionResult> CreateAsync(CategoryDTO dto)
    {
        var result = await categoryService.AddAsync(dto);
        return RedirectToAction(nameof(Index));
    }
}