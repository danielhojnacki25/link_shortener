using MediatR;

namespace LinkShortener.Services.Links.Commands.SetShortenedLink;

public class SetShortenedLinkCommand : IRequest<Unit>
{
    public SetShortenedLinkCommand(long linkId)
        => LinkId = linkId;

    public long LinkId { get; set; }
}