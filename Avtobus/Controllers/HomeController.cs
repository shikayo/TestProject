using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Avtobus.Models;
using DataAccess;
using Domain;

namespace Avtobus.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private IRepository<Url> _repository;

    public HomeController(ILogger<HomeController> logger,IRepository<Url> repository)
    {
        _repository = repository;
        _logger = logger;
    }

    public IActionResult Index()
    {
        var model = new AllUrlsViewModel
        {
            Urls = _repository.GetAll()
        };
        return View(model);
    }

    public IActionResult Privacy()
    {
        return View();
    }
    
    public RedirectResult RedirectToOriginal(string shortUrl)
    {
        var url = _repository.GetUrlByShortUrl(shortUrl);
        url.Count++;
        _repository.Save();
        var fullUrl = url.FullUrl;
        if (!string.IsNullOrEmpty(fullUrl))
           return Redirect(fullUrl);
        return Redirect("/Home/Error");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}