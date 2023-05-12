using System;
using UrlShortener.Domain;
using UrlShortener.Domain.Abstractions.Repositories;
using UrlShortener.Infrastructure.Repositories;

namespace UrlShortener.Infrastructure
{
	public class UnitOfWork: IUnitOfWork
    {
        private IUrlRepository urlRepository;
        private UrlShortenerDbContext _context;

        public UnitOfWork(UrlShortenerDbContext context)
		{
            _context = context;

        }

        IUrlRepository IUnitOfWork.urlRepository
        {
            get
            {
                return urlRepository ??= new UrlRepository(_context);
            }
        }


        public void Dispose()
        {
            if (_context != null)
            {
                _context.Dispose();
                _context = null;
            }
        }

        public void Save()
        {
            _context.SaveChanges();
        }
    }
}

