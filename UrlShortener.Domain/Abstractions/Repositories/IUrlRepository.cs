using System;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Abstractions.Repositories
{
    public interface IUrlRepository
    {
        void Add(ShortenedUrl shortenedUrl);
        Task AddUrlAsync(Url url);
        Task DeleteUrlAsync(Url url);
        Task<Url> GetUrlAsync(int id);
        Task<Url> GetUrlByShortenedAsync(string shortened);
        Task<IEnumerable<Url>> GetUrlsAsync();
        Task UpdateUrlAsync(Url url);
    }

}

