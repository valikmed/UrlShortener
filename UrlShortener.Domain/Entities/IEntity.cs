using System;
using System.Collections.Generic;
using System.Text;
namespace UrlShortener.Domain.Entities
{
    public interface IEntity<T>
    {
        public T ID { get; set; }
    }
}