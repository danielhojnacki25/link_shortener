using LinkShortener.Data;
using LinkShortener.Helpers.Links;
using MediatR;

namespace LinkShortener.Services.Links.Commands.SetShortenedLink;

public class SetShortenedLinkCommandHandler : IRequestHandler<SetShortenedLinkCommand, Unit>
{
    private readonly ApplicationDbContext _context;
    private readonly ILinkHelper _linkHelper;

    public SetShortenedLinkCommandHandler(ApplicationDbContext context, ILinkHelper helper)
    {
        _context = context;
        _linkHelper = helper;
    }

    public async Task<Unit> Handle(SetShortenedLinkCommand request, CancellationToken cancellationToken)
    {
        var link = await _context.Links.FindAsync(request.LinkId);
        if (link == null) return Unit.Value;

        var linkChunk = _linkHelper.GetUrlChunk(link.Id);
        link.SetShortLink(linkChunk);
        _context.Update(link);
        await _context.SaveChangesAsync(cancellationToken);

        return Unit.Value;
    }
}