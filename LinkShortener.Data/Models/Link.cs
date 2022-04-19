#nullable disable 
using LinkShortener.Data.Models.Common;

namespace LinkShortener.Data.Models;

public sealed class Link : Entity
{
    public string OriginalUrl { get; private set; }
    public string ShortenedUrl { get; private set; }
    public DateTime CreationDate { get; init; }

    public Link()
    {
        CreationDate = DateTime.Now;
    }

    public void SetOriginalLink(string originalLink)
        => OriginalUrl = originalLink;

    public void SetShortLink(string shortLink)
        => ShortenedUrl = shortLink;
}