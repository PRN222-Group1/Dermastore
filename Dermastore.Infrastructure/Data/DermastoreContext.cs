using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Dermastore.Infrastructure.Data
{
    public class DermastoreContext : IdentityDbContext<User, IdentityRole<int>, int>
    {
        public DermastoreContext(DbContextOptions<DermastoreContext> options) : base(options)
        {
        }
        public DbSet<Question> Questions { get; set; }
        public DbSet<Answer> Answers { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<Promotion> Promotions { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Feedback> Feedbacks { get; set; }
        public DbSet<DeliveryMethod> DeliveryMethods { get; set; }
        public DbSet<QuizResult> QuizResults { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
