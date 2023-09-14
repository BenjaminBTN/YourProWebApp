using Microsoft.EntityFrameworkCore;
using YourProfessionWebApp.Domain.Entities;

namespace YourProfessionWebApp.Domain {
    public class Context : DbContext {

        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<TextField> Pages { get; set; }
        public DbSet<ProfessionItem> ProfessionItems { get; set;}
    }
}
