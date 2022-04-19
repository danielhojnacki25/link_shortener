using LinkShortener.Data;
using MediatR;

namespace LinkShortener.Services.Links.Commands.CreateLink;

public class CreateLinkCommandHandler : IRequestHandler<CreateLinkCommand, Unit>
{
    private readonly ApplicationDbContext _context;

    public CreateLinkCommandHandler(ApplicationDbContext context)
        => _context = context;

    public async Task<Unit> Handle(CreateLinkCommand request, CancellationToken cancellationToken)
    {
        await _context.AddAsync(request.Link, cancellationToken);
        await _context.SaveChangesAsync(cancellationToken);
        return Unit.Value;
    }
}