using LinkShortener.Common.Dtos.Links;
using LinkShortener.Data;
using LinkShortener.Mappers.Links;
using MediatR;

namespace LinkShortener.Services.Links.Queries.GetLinkById;

public class GetLinkByIdQueryHandler : IRequestHandler<GetLinkByIdQuery, LinkDto?>
{
    private readonly ApplicationDbContext _context;

    public GetLinkByIdQueryHandler(ApplicationDbContext context)
        => _context = context;

    public async Task<LinkDto?> Handle(GetLinkByIdQuery request, CancellationToken cancellationToken)
        => (await _context.Links.FindAsync(request.LinkId))?.MapToDto();
}