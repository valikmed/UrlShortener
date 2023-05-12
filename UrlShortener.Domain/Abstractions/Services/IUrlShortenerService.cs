using System;

namespace UrlShortener.Domain.Abstractions.Services
{
    public interface IUrlShortenerService
    {
        string ShortenUrl(string longUrl);
        Task ShortenUrl(object longUrl);
    }
}

