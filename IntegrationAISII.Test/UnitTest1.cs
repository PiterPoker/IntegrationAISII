using IntegrationAISII.Infrastructure;
using Microsoft.EntityFrameworkCore;
using NUnit.Framework;
using System.Threading.Tasks;

namespace IntegrationAISII.Test
{
    public class Tests
    {
        DbContextOptions<IntegrationAISIIContext> _options;
        [SetUp]
        public void Setup()
        {
            var optionsBuilder = new DbContextOptionsBuilder<IntegrationAISIIContext>();

            _options = optionsBuilder
                .UseNpgsql("Host=127.0.0.1;Port=5432;Database=IntegrationAISIIDb;Username=postgres;Password=Qq123456")
                .Options;
        }

        [Test]
        public async Task Test1()
        {
            using(var db = new IntegrationAISIIContext(_options))
            {
                var document = await db.OutgoingDocuments.ToListAsync();
            }

            Assert.Pass();
        }
    }
}