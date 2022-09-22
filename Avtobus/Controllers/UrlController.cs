using Avtobus.Models;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.LinkShorter;

namespace Avtobus.Controllers;

public class UrlController : Controller
{
    private IRepository<Url> _repository;
    private IShortLink _shortLink;
    public UrlController(IRepository<Url> repository,IShortLink shortLink)
    {
        _repository = repository;
        _shortLink = shortLink;
    }

    public IActionResult Home()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(UrlViewModel model)
    {
        _shortLink.GenerateShortUrl(model.FullUrl);
        return RedirectToAction("Home");
    }
    
    
    
}