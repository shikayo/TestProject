using System.ComponentModel.DataAnnotations;

namespace Avtobus.Models;

public class UrlViewModel
{
    [Required]
    public string FullUrl { get; set; }
}