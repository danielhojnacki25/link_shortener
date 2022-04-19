using LinkShortener.Common.Dtos.Links;
using MediatR;

namespace LinkShortener.Services.Links.Queries.GetLinks;

public class GetLinksQuery : IRequest<IList<LinkDto>>
{

}