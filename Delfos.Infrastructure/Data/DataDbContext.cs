using Delfos.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Delfos.Infrastructure.Data
{
    public class DataDbContext : DbContext
    {
        public DataDbContext(DbContextOptions<DataDbContext> options) : base(options) { }

        public DbSet<PlayersModel> Players { get; set; }
    }
}
