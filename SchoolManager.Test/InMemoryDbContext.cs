using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Castle.Components.DictionaryAdapter;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using SchoolManager.Infrastructure.Data;

namespace SchoolManager.Test
{
    public class InMemoryDbContext
    {
        private readonly SqliteConnection connection;
        private readonly DbContextOptions<ApplicationDbContext> contextOptions;

        public InMemoryDbContext()
        {
            connection = new SqliteConnection("Filename:memory:");
            connection.Open();

            contextOptions = new DbContextOptionsBuilder<ApplicationDbContext>()
                .UseSqlite(connection)
                .Options;

            using var context = new ApplicationDbContext(contextOptions);

            context.Database.EnsureCreated();
        }

        public ApplicationDbContext CreateContext()
            => new ApplicationDbContext(contextOptions);

        public void Dispose() => connection.Dispose();
    }
}
