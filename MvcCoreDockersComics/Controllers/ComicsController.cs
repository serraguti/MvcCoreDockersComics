using Microsoft.AspNetCore.Mvc;
using MvcCoreDockersComics.Models;
using MvcCoreDockersComics.Repositories;

namespace MvcCoreDockersComics.Controllers
{
    public class ComicsController : Controller
    {
        private RepositoryComics repo;

        public ComicsController(RepositoryComics repo)
        {
            this.repo = repo;
        }

        public IActionResult Index()
        {
            List<Comic> comics = this.repo.GetComics();
            return View(comics);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Comic comic)
        {
            await this.repo.InsertComicAsync(comic.Nombre, comic.Imagen);
            return RedirectToAction("Index");
        }

        public IActionResult Update(int idcomic)
        {
            Comic comic = this.repo.FindComic(idcomic);
            return View(comic);
        }

        [HttpPost]
        public async Task<IActionResult> Update(Comic comic)
        {
            await this.repo.UpdateComicAsync(comic.IdComic, comic.Nombre, comic.Imagen);
            return RedirectToAction("Index");
        }
    }
}
