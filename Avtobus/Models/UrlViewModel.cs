using System.ComponentModel.DataAnnotations;

namespace Avtobus.Models;

public class UrlViewModel
{
    [Required]
    [RegularExpression(@"(https?:\/\/|ftps?:\/\/|\.)((?![.,?!;:()]*(\s|$))[^\s]){2,}", ErrorMessage = "Некорректный адрес")]
    public string FullUrl { get; set; }
}