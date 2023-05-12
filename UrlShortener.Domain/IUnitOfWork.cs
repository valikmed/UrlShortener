using System;
using System;
using UrlShortener.Domain.Abstractions.Repositories;

namespace UrlShortener.Domain
{
    public interface IUnitOfWork : System.IDisposable
    {
        IUrlRepository urlRepository { get; }
        void Save();
    }
}
