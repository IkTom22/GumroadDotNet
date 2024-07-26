using GumroadDotNet.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
namespace GumroadDotNet.Controllers;

public class ProductsController : Controller
{
    // public IActionResult Index()
    // {
    //     return View();
    // }

     private readonly GumroadDotNetContext _context;

    public ProductsController(GumroadDotNetContext context)
    {
        _context = context;
    }
     // GET: Products
    public async Task<IActionResult> Index()
    {
        return View(await _context.Product.ToListAsync());
    }
}