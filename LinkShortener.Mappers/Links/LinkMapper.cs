using LinkShortener.Common.Dtos.Links;
using LinkShortener.Data.Models;

namespace LinkShortener.Mappers.Links;

public static class LinkMapper
{
    public static LinkDto MapToDto(this Link link) => new()
    {
        Id = link.Id,
        CreationDate = link.CreationDate,
        OriginalUrl = link.OriginalUrl,
        ShortenedUrl = link.ShortenedUrl,
    };
}