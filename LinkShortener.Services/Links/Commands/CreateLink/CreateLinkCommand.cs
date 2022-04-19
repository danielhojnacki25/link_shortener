using LinkShortener.Data.Models;
using MediatR;

namespace LinkShortener.Services.Links.Commands.CreateLink;

public class CreateLinkCommand : IRequest<Unit>
{
    public CreateLinkCommand(Link link)
        => Link = link;

    public Link Link { get; set; }
}