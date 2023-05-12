using System;
namespace UrlShortener.Domain.Entities
{
    public class Url : IEntity<int>
    {
        public int ID { get; set; }
        public string OriginalUrl { get; set; }
        public string ShortenedUrl { get; set; }
        public string LongUrl { get; set; }
    }
}

