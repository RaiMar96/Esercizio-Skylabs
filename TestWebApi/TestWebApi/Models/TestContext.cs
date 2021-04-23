using Microsoft.EntityFrameworkCore;

namespace TestWebApi.Models
{
    public class TestContext : DbContext
    {
        public TestContext(DbContextOptions<TestContext> options) : base(options)
        {
        }

        public DbSet<TestWebItem> TestItems { get; set; }
    }
}
