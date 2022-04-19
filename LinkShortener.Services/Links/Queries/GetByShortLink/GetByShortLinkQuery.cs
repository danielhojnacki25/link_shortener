using LinkShortener.Common.Dtos.Links;
using MediatR;

namespace LinkShortener.Services.Links.Queries.GetByShortLink;

public class GetByShortLinkQuery : IRequest<LinkDto?>
{
    public GetByShortLinkQuery(string shortLink)
        => ShortLink = shortLink;
    public string ShortLink { get; set; }
}