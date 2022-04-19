using LinkShortener.Common.Dtos.Links;
using MediatR;

namespace LinkShortener.Services.Links.Queries.GetLinkById;

public class GetLinkByIdQuery : IRequest<LinkDto?>
{
    public GetLinkByIdQuery(long linkId)
        => LinkId = linkId;
    public long LinkId { get; set; }
}