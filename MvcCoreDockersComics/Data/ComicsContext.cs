using Microsoft.EntityFrameworkCore;
using MvcCoreDockersComics.Models;

namespace MvcCoreDockersComics.Data
{
    public class ComicsContext: DbContext
    {
        public ComicsContext(DbContextOptions<ComicsContext> options)
            : base(options) { }

        public DbSet<Comic> Comics { get; set; }
    }
}
