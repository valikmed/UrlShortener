using UrlShortener.Domain.Abstractions.Repositories;
using UrlShortener.Domain.Abstractions.Services;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Application.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly UrlShortenerService _urlShortenerService;
        private readonly IShortenedUrlRepository _shortenedUrlRepository;

        public UrlShortenerService(UrlShortenerService urlShortenerService, IShortenedUrlRepository shortenedUrlRepository)
        {
            _urlShortenerService = urlShortenerService;
            _shortenedUrlRepository = shortenedUrlRepository;
        }

        public string ShortenUrl(string longUrl)
        {
            return longUrl;
        }

        public Task ShortenUrl(object longUrl)
        {
            return (Task)longUrl;
        }
    }
}