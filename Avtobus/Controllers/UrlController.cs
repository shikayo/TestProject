using System.Diagnostics;
using Avtobus.Models;
using DataAccess;
using Domain;
using Microsoft.AspNetCore.Http.Extensions;
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
        if (ModelState.IsValid)
        {
            var domen = HttpContext.Request.Host.ToString();
            _shortLink.GenerateShortUrl(domen, model.FullUrl);
            return RedirectToAction("Index","Home");
        }
        return View("Home",model);
    }

    [HttpPost]
    public IActionResult Delete(Guid id)
    {
        _repository.Delete(id);
        _repository.Save();
        return RedirectToAction("Index", "Home");
    }
}