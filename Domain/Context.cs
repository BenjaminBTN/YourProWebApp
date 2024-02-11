using Microsoft.EntityFrameworkCore;
using YourProWebApp.Domain.Entities;

namespace YourProWebApp.Domain {
    public class Context : DbContext {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TextField> Pages { get; set; }
        public DbSet<ProfessionItem> ProfessionItems { get; set;}
    }
}
