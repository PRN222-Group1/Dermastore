using Dermastore.Domain.Entities;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dermastore.Infrastructure.Data
{
    public class DermastoreContextSeed
    {
        public static async Task SeedAsync(DermastoreContext context, UserManager<User> userManager)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new JsonStringEnumConverter());

            if (!context.Memberships.Any())
            {
                var memData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/memberships.json");

                var memberships = JsonSerializer.Deserialize<List<Membership>>(memData);

                if (memberships == null) return;

                context.Memberships.AddRange(memberships);

                await context.SaveChangesAsync();
            }

            if (!userManager.Users.Any(x => x.UserName == "john@test.com"))
            {
                var user = new User
                {
                    UserName = "john@test.com",
                    FirstName = "John",
                    LastName = "Pork",
                    Email = "john@test.com",
                    Address = "57 Something",
                    ImageUrl = "abq123",
                    MembershipId = 1
                };

                await userManager.CreateAsync(user, "Pa$$w0rd");
                await userManager.AddToRoleAsync(user, "Customer");
            }

            if (!context.Categories.Any())
            {
                var catData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/categories.json");

                var categories = JsonSerializer.Deserialize<List<Category>>(catData);

                if (categories == null) return;

                context.Categories.AddRange(categories);

                await context.SaveChangesAsync();
            }

            if (!context.Questions.Any())
            {
                var questData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/questions.json");

                var questions = JsonSerializer.Deserialize<List<Question>>(questData);

                if (questions == null) return;

                context.Questions.AddRange(questions);

                await context.SaveChangesAsync();
            }

            if (!context.Answers.Any())
            {
                var ansData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/answers.json");

                var answers = JsonSerializer.Deserialize<List<Answer>>(ansData);

                if (answers == null) return;

                context.Answers.AddRange(answers);

                await context.SaveChangesAsync();
            }

            if (!context.Products.Any())
            {
                var productsData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/products.json");

                var products = JsonSerializer.Deserialize<List<Product>>(productsData, options);
                    

                if (products == null) return;

                context.Products.AddRange(products);

                await context.SaveChangesAsync();
            }
        }
    }
}
