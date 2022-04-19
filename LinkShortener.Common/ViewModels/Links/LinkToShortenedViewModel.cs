#nullable disable 
using System.ComponentModel.DataAnnotations;

namespace LinkShortener.Common.ViewModels.Links;

public class LinkToShortenedViewModel
{
    [Required]
    public string Link { get; set; }
}