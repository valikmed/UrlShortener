
using UrlShortener.Domain.Abstractions.Repositories;
using UrlShortener.Domain.Entities;
using UrlShortener.Domain.Abstractions.Services;

namespace UrlShortener.Application.Services
{
    public class ShortUrlInfoService :IShortUrlInfoService
    {
        private readonly IShortenedUrlRepository _shortenedUrlRepository;
        private readonly IUrlRepository _urlRepository;

        public ShortUrlInfoService(IShortenedUrlRepository shortenedUrlRepository, IUrlRepository urlRepository)
        {
            _shortenedUrlRepository = shortenedUrlRepository;
            _urlRepository = urlRepository;
        }

        public async Task<IEnumerable<ShortenedUrl>> GetAllShortenedUrlsAsync()
        {
            return await _shortenedUrlRepository.GetShortenedUrlsAsync();
        }

        public async Task<ShortenedUrl> GetShortenedUrlAsync(int id)
        {
            return await _shortenedUrlRepository.GetShortenedUrlAsync(id);
        }

        public async Task AddShortenedUrlAsync(string longUrl)
        {
            // Generate a short key using MD5 hash
            var md5 = System.Security.Cryptography.MD5.Create();
            var inputBytes = System.Text.Encoding.ASCII.GetBytes(longUrl);
            var hashBytes = md5.ComputeHash(inputBytes);
            var shortKey = BitConverter.ToString(hashBytes).Replace("-", "").Substring(0, 6);

            // Create and save the long URL and the short key to the database
            var url = new Url { LongUrl = longUrl };
            await _urlRepository.AddUrlAsync(url);

            var shortenedUrl = new ShortenedUrl { Key = shortKey, Url = url };
            await _shortenedUrlRepository.AddShortenedUrlAsync(shortenedUrl);
        }

        public async Task DeleteShortenedUrlAsync(int id)
        {
            await _shortenedUrlRepository.DeleteShortenedUrlAsync(id);
        }
    }
}

