using LinkShortener.Common.Dtos.Links;
using LinkShortener.Data;
using LinkShortener.Mappers.Links;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Services.Links.Queries.GetByShortLink;

public class GetByShortLinkQueryHandler : IRequestHandler<GetByShortLinkQuery, LinkDto?>
{
    private readonly ApplicationDbContext _context;

    public GetByShortLinkQueryHandler(ApplicationDbContext context)
        => _context = context;

    public async Task<LinkDto?> Handle(GetByShortLinkQuery request, CancellationToken cancellationToken)
        => (await _context.Links.Where(x => x.ShortenedUrl.Equals(request.ShortLink)).FirstOrDefaultAsync(cancellationToken: cancellationToken))?.MapToDto();
}