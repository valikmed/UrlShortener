using System;
using UrlShortener.Domain.Entities;

namespace UrlShortener.Domain.Abstractions.Repositories
{
	public class IShortenedUrlRepository
	{
		public IShortenedUrlRepository()
		{
		}

        public Task AddShortenedUrlAsync(ShortenedUrl shortenedUrl)
        {
            throw new NotImplementedException();
        }

        public Task DeleteShortenedUrlAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<ShortenedUrl> GetShortenedUrlAsync(int id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<ShortenedUrl>> GetShortenedUrlsAsync()
        {
            throw new NotImplementedException();
        }
    }
}

