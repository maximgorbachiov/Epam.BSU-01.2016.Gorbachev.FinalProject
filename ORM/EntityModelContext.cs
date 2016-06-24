using System.Data.Entity;

namespace ORM
{
    public class EntityModelContext : DbContext
    {
        public DbSet<Test> Tests { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Client> Clients { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<PassedTest> PassedTests { get; set; }

        public EntityModelContext() : base("DefaultConnection") { }
    }
}
