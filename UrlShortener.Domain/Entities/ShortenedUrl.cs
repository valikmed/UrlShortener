using System;
namespace UrlShortener.Domain.Entities
{
    public class ShortenedUrl :IEntity<int>
    {
        public int ID { get; set; }
        public string Shortened { get; set; }
        public int UrlId { get; set; }
        public Url Url { get; set; }
        public string Key { get; set; }
    }
}

