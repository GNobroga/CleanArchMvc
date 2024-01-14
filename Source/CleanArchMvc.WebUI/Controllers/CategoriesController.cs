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
}