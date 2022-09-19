using Avtobus.Models;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Services.UrlShorter;

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
        var url = new Url();
        
        url.FullUrl = model.FullUrl;
        url.ShortUrl=_shortLink.GetShortUrl(model.FullUrl);
        url.DateOfCreate=DateTime.Now;
        url.Count = 0;
        
        _repository.Create(url);
        _repository.Save();


        return RedirectToAction("Home");
    }
    
    
    
}