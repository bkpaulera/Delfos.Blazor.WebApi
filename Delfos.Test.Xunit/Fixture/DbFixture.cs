using Delfos.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;

namespace Delfos.Test.Xunit.Fixture
{
    public class DbFixture : IDisposable
    {
        private readonly DataDbContext _context;
        private readonly string DatabaseName = $"DelfosDbTest-{Guid.NewGuid()}";
        public readonly string ConnectionString;
        private bool _disposed;
        public DbFixture()
        {
            ConnectionString = $"Server=(localdb)\\mssqllocaldb;Database={DatabaseName};Trusted_Connection=True;MultipleActiveResultSets=true";

            var builder = new DbContextOptionsBuilder<DataDbContext>();
            builder.UseSqlServer(ConnectionString);

            _context = new DataDbContext(builder.Options);

            _context.Database.Migrate();

        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                if (disposing)
                {
                    _context.Database.EnsureDeleted();

                }

                _disposed = true;
            }


        }
    }
}
