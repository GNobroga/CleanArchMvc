using CleanArchMvc.Application.DTOs;
using CleanArchMvc.Application.Interfaces;
using CleanArchMvc.Domain.Entities;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    public async Task<ViewResult> Index()
    {
        var products = await productService.GetAllAsync();
        return View(products);
    }

    public ViewResult Create() => View();

    [HttpPost]
    [ActionName("Create")]
    public async Task<ActionResult> CreateAsync(ProductDTO dto)
    {
        if (dto.Id != 0)
        {
            await productService.UpdateAsync(dto.Id, dto);
            return RedirectToAction(nameof(Index));
        }

        await productService.AddAsync(dto);

        return RedirectToAction(nameof(Index));
    }


    [ActionName("Update")]
    public async Task<ActionResult> UpdateAsync(int id)
    {
        var product = await productService.GetByIdAsync(id);

        return View("Create", product);
    }

    [ActionName("Remove")]
    public async Task<ActionResult> DeleteAsync(int id)
    {
        await productService.RemoveAsync(id);

        return RedirectToAction("Index");
    }
    
}