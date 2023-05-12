using System;
using Microsoft.EntityFrameworkCore;
using UrlShortener.Domain.Abstractions.Repositories;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Infrastructure.Repositories
{
    public class UrlRepository : IUrlRepository
    {
        private readonly UrlShortenerDbContext _dbContext;

        public UrlRepository(UrlShortenerDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Add(ShortenedUrl shortenedUrl)
        {
            _dbContext.ShortenedUrls.Add(shortenedUrl);
            _dbContext.SaveChanges();
        }

        public async Task AddUrlAsync(Url url)
        {
            _dbContext.Urls.Add(url);
            await _dbContext.SaveChangesAsync();
        }
        //Should be implemented
        public Task DeleteUrlAsync(Url url)
        {
            throw new NotImplementedException();
        }

        public async Task<Url> GetUrlAsync(int id)
        {
            return await _dbContext.Urls.FindAsync(id);
        }

        public async Task<Url> GetUrlByShortenedAsync(string shortened)
        {
            return await _dbContext.Urls.SingleOrDefaultAsync(u => u.ShortenedUrl == shortened);
        }

        public async Task<IEnumerable<Url>> GetUrlsAsync()
        {
            return await _dbContext.Urls.ToListAsync();
        }

        public async Task UpdateUrlAsync(Url url)
        {
            _dbContext.Entry(url).State = EntityState.Modified;
            await _dbContext.SaveChangesAsync();
        }
    }

}

