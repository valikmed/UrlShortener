using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using UrlShortener.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

//Add this in a feature
//using Infrastructure.EntityConfigurations;

namespace UrlShortener.Infrastructure
{
    public class UrlShortenerContext :IdentityDbContext<IdentityUser>
    {

        public UrlShortenerContext(DbContextOptions<UrlShortenerContext> options) : base(options)
        {
        }
        private const string connectionString = @"server=localhost; database=ProfileData; User ID=sa; Password=Yukon900; TrustServerCertificate=true;";

        public DbSet<Url> Urls { get; set; }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }

    public class UrlShortenerDbContext : DbContext
    {
        public UrlShortenerDbContext(DbContextOptions<UrlShortenerDbContext> options)
            : base(options)
        {
        }

        public DbSet<Url> Urls { get; set; }
        public DbSet<ShortenedUrl> ShortenedUrls { get; set; }
    }

}

