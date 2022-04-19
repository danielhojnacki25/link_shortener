#nullable disable 
using LinkShortener.Common.Dtos.Common;

namespace LinkShortener.Common.Dtos.Links;

public class LinkDto : EntityDto
{
    public string OriginalUrl { get; set; }
    public string ShortenedUrl { get; set; }
    public DateTime CreationDate { get; set; }
}