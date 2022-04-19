using LinkShortener.Common.Dtos.Links;
using LinkShortener.Data;
using LinkShortener.Mappers.Links;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace LinkShortener.Services.Links.Queries.GetLinks;

public class GetLinksQueryHandler : IRequestHandler<GetLinksQuery, IList<LinkDto>>
{
    private readonly ApplicationDbContext _context;

    public GetLinksQueryHandler(ApplicationDbContext context)
        => _context = context;

    public async Task<IList<LinkDto>> Handle(GetLinksQuery request, CancellationToken cancellationToken)
        => await _context.Links.Select(x => x.MapToDto()).ToListAsync(cancellationToken: cancellationToken);
}