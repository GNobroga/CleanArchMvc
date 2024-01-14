using CleanArchMvc.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.WebUI.Controllers;

public class ProductsController(IProductService productService) : Controller
{
    public async Task<ViewResult> Index()
    {
        var products = await productService.GetProductsAsync();
        return View(products);
    }
}