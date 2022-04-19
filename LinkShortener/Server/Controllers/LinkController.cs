using LinkShortener.Common.Dtos.Links;
using LinkShortener.Data.Models;
using LinkShortener.Services.Links.Commands.CreateLink;
using LinkShortener.Services.Links.Commands.SetShortenedLink;
using LinkShortener.Services.Links.Queries.GetByShortLink;
using LinkShortener.Services.Links.Queries.GetLinkById;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace LinkShortener.Server.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LinkController : Controller

{
    private readonly IMediator _mediator;
    private readonly ILogger<LinkController> _logger;

    public LinkController(IMediator mediator, ILogger<LinkController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet("{shortLink}")]
    public async Task<IActionResult> GetLink(string shortLink)
    {
        var link = await _mediator.Send(new GetByShortLinkQuery(shortLink));
        _logger.LogInformation($"Someone send request for {link.OriginalUrl}");
        return Ok(link);
    }

    [HttpPost]
    public async Task<ActionResult<LinkDto>> CreateLink(LinkDto linkDto)
    {
        var newLink = new Link();
        newLink.SetOriginalLink(linkDto.OriginalUrl);
        await _mediator.Send(new CreateLinkCommand(newLink));
        await _mediator.Send(new SetShortenedLinkCommand(newLink.Id));

        return Ok(await _mediator.Send(new GetLinkByIdQuery(newLink.Id)));
    }
}