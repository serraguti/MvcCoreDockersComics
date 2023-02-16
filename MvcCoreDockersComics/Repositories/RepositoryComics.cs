using MvcCoreDockersComics.Data;
using MvcCoreDockersComics.Models;

namespace MvcCoreDockersComics.Repositories
{
    public class RepositoryComics
    {
        private ComicsContext context;

        public RepositoryComics(ComicsContext context)
        {
            this.context = context;
        }

        public List<Comic> GetComics()
        {
            var consulta = from datos in this.context.Comics
                           select datos;
            return consulta.ToList();
        }

        public Comic FindComic(int id)
        {
            var consulta = from datos in this.context.Comics
                           where datos.IdComic == id
                           select datos;
            return consulta.FirstOrDefault();
        }

        private int GetMaxIdComic()
        {
            int maximo = (from datos in this.context.Comics
                          select datos.IdComic).Max() + 1;
            return maximo;
        }

        public async Task InsertComicAsync(string nombre, string imagen)
        {
            Comic comic = new Comic();
            comic.IdComic = this.GetMaxIdComic();
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            this.context.Comics.Add(comic);
            await this.context.SaveChangesAsync();
        }

        public async Task UpdateComicAsync(int id, string nombre, string imagen)
        {
            Comic comic = this.FindComic(id);
            comic.Nombre = nombre;
            comic.Imagen = imagen;
            await this.context.SaveChangesAsync();
        }
    }
}
