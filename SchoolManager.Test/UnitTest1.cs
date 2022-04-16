using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using SchoolManager.Core.Contracts;
using SchoolManager.Core.Services;
using SchoolManager.Infrastructure.Data;
using SchoolManager.Infrastructure.Data.Identity;
using SchoolManager.Infrastructure.Data.Repositories;

namespace SchoolManager.Test
{
    public class Tests
    {
        private ServiceProvider serviceProvider;
        private InMemoryDbContext dbContext;
        private UserManager<ApplicationUser> _userManager;
        private IApplicationDbRepository repo;

        [SetUp]
        public async Task Setup()
        {
            dbContext = new InMemoryDbContext();

            var serviceCollection = new ServiceCollection();
            serviceProvider = serviceCollection
                .AddSingleton(sp => dbContext.CreateContext())
                .AddSingleton<IApplicationDbRepository, ApplicationDbRepository>()
                .AddSingleton<IClassService, ClassService>()
                .BuildServiceProvider();

            repo = serviceProvider.GetService<IApplicationDbRepository>();
            await SeedDbAsync(repo);
        }

        [Test]
        public void InvalidClassIdMustThrow()
        {
            var service = serviceProvider.GetService<IClassService>();

            var classId = "notvalid";
            var user = repo.All<ApplicationUser>()
                .FirstOrDefault(u => u.Email == "teacher@teacher.bg");


            Assert.CatchAsync<ArgumentException>(async ()=> await service.JoinClass(classId, user), 
                "Invalid teacher or class");
        }

        [TearDown]
        public void TearDown()
        {

        }

        private async Task SeedDbAsync(IApplicationDbRepository repo)
        {
            var user = new ApplicationUser()
            {
                AccessFailedCount = 0,
                ConcurrencyStamp = ToString(),
                Email = "testuser@gmail.com",
                EmailConfirmed = true,
                Id = Guid.NewGuid().ToString(),
            };
            //await repo.AddAsync();
            await repo.SaveChangesAsync();
        }
    }
}