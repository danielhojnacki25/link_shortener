using Microsoft.AspNetCore.WebUtilities;

namespace LinkShortener.Helpers.Links;

public class LinkHelper : ILinkHelper
{
    public string GetUrlChunk(long id)
        => WebEncoders.Base64UrlEncode(BitConverter.GetBytes(id));
}