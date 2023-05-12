using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using UrlShortener.Domain.Abstractions.Repositories;
using UrlShortener.Domain.Abstractions.Services;
using UrlShortener.Domain.Entities;
using UrlShortener.Presentation.Models;

namespace UrlShortener.Presentation.Controllers
{
    public class ShortUrlInfoController : Controller
    {
        private readonly IUrlShortenerService _urlShortenerService;
        private readonly IUrlRepository _urlRepository;
        private readonly UserManager<IdentityUser> _userManager;

        public ShortUrlInfoController(
            IUrlShortenerService urlShortenerService,
            IUrlRepository urlRepository,
            UserManager<IdentityUser> userManager)
        {
            _urlShortenerService = urlShortenerService;
            _urlRepository = urlRepository;
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var urls = await _urlRepository.GetUrlsAsync();
            var model = urls.Select(u => new ShortUrlViewModel
            {
                Id = u.ID,
                LongUrl = u.LongUrl,
                ShortUrl = $"{Request.Scheme}://{Request.Host}/{u.ShortenedUrl}"
            });

            return View(model);
        }

        [Authorize]
        public IActionResult Create()
        {
            return View();
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Create(CreateUrlViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var shortUrl =  _urlShortenerService.ShortenUrl(model.LongUrl);
            var url = new Url
            {
                LongUrl = model.LongUrl,
                ShortenedUrl = shortUrl
            };

            await _urlRepository.AddUrlAsync(url);

            return RedirectToAction(nameof(Index));
        }

        [Authorize]
        public async Task<IActionResult> Delete(int id)
        {
            var url = await _urlRepository.GetUrlAsync(id);

            if (url != null)
            {
                await _urlRepository.DeleteUrlAsync(url);
            }

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int id)
        {
            var url = await _urlRepository.GetUrlAsync(id);

            if (url == null)
            {
                return NotFound();
            }

            var model = new ShortUrlViewModel
            {
                Id = url.ID,
                LongUrl = url.LongUrl,
                ShortUrl = $"{Request.Scheme}://{Request.Host}/{url.ShortenedUrl}"
            };

            return View(model);
        }
    }
}
