using Dermastore.Domain.Entities;
using Dermastore.Domain.Entities.OrderAggregate;
using Dermastore.Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System.Reflection;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Dermastore.Infrastructure.Data
{
    public class DermastoreContextSeed
    {
        public static async Task SeedAsync(DermastoreContext context, 
            UserManager<User> userManager, RoleManager<IdentityRole<int>> roleManager)
        {
            var path = Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location);

            var options = new JsonSerializerOptions { PropertyNameCaseInsensitive = true };
            options.Converters.Add(new JsonStringEnumConverter());

            // Seed roles
            if (!roleManager.Roles.Any())
            {
                var data = await File.ReadAllTextAsync(path + @"/Data/SeedData/roles.json");

                var roles = JsonSerializer.Deserialize<List<IdentityRole<int>>>(data, options);

                if (roles == null) return;

                foreach (var item in roles)
                {
                    await roleManager.CreateAsync(item);
                }
            }

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
                var userList = new List<(User user, string password, string role)>
                {
                    // Customers
                    (new User
                    {
                        UserName = "john@test.com",
                        FirstName = "John",
                        LastName = "Pork",
                        Email = "john@test.com",
                        Address = "57 Something",
                        PhoneNumber = "0837129211",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Fmale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "john1234", "Customer"),

                    (new User
                    {
                        UserName = "jane@test.com",
                        FirstName = "Jane",
                        LastName = "Doe",
                        Email = "jane@test.com",
                        Address = "123 Elm Street",
                        PhoneNumber = "0837129212",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Ffemale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "jane1234", "Customer"),

                    (new User
                    {
                        UserName = "mike@test.com",
                        FirstName = "Mike",
                        LastName = "Smith",
                        Email = "mike@test.com",
                        Address = "456 Oak Avenue",
                        PhoneNumber = "0837129213",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Fmale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "mike1234", "Customer"),

                    // Staff
                    (new User
                    {
                        UserName = "alice.staff@test.com",
                        FirstName = "Alice",
                        LastName = "Johnson",
                        Email = "alice.staff@test.com",
                        Address = "789 Maple Road",
                        PhoneNumber = "0389234123",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Ffemale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "alice1234", "Staff"),

                    (new User
                    {
                        UserName = "bob.staff@test.com",
                        FirstName = "Bob",
                        LastName = "Williams",
                        Email = "bob.staff@test.com",
                        Address = "101 Pine Drive",
                        PhoneNumber = "0348453439",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Fmale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "bobby1234", "Staff"),

                    (new User
                    {
                        UserName = "carol.staff@test.com",
                        FirstName = "Carol",
                        LastName = "Brown",
                        Email = "carol.staff@test.com",
                        Address = "202 Cedar Lane",
                        PhoneNumber = "0483935183",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Ffemale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "carol1234", "Staff"),

                    // Manager
                    (new User
                    {
                        UserName = "dave.manager@test.com",
                        FirstName = "Dave",
                        LastName = "Clark",
                        Email = "dave.manager@test.com",
                        Address = "303 Birch Boulevard",
                        PhoneNumber = "0482553124",
                        ImageUrl = "https://firebasestorage.googleapis.com/v0/b/mechat-926e4.appspot.com/o/teamo%2Fimages%2Fplaceholders%2Fmale-user.jpg?alt=media",
                        MembershipId = 1
                    }, "dave1234", "Manager")
                };

                foreach (var account in userList)
                {
                    await userManager.CreateAsync(account.user, account.password);
                    await userManager.AddToRoleAsync(account.user, account.role);
                }
            }

            if (!context.Blogs.Any())
            {
                var blogData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/blogs.json");

                var blogs = JsonSerializer.Deserialize<List<Blog>>(blogData, options);

                if (blogs == null) return;

                context.Blogs.AddRange(blogs);

                await context.SaveChangesAsync();
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

            if (!context.SubCategories.Any())
            {
                var subCatData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/subcategories.json");

                var subCategories = JsonSerializer.Deserialize<List<SubCategory>>(subCatData);

                if (subCategories == null) return;

                context.SubCategories.AddRange(subCategories);

                await context.SaveChangesAsync();
            }

            if (!context.Brands.Any())
            {
                var brandData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/brands.json");

                var brands = JsonSerializer.Deserialize<List<Brand>>(brandData);

                if (brands == null) return;

                context.Brands.AddRange(brands);

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

            if (!context.QuizResults.Any())
            {
                var quizDatas = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/QuizResult.json");
                var quizResult = JsonSerializer.Deserialize<List<QuizResult>>(quizDatas);
                if (quizResult == null) return;
                context.QuizResults.AddRange(quizResult);
                await context.SaveChangesAsync();
            }

            if (!context.DeliveryMethods.Any())
            {
                var deliveryMethodData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/deliveryMethods.json");
                var deliveryMethods = JsonSerializer.Deserialize<List<DeliveryMethod>>(deliveryMethodData);
                if (deliveryMethods == null) return;
                context.DeliveryMethods.AddRange(deliveryMethods);
                await context.SaveChangesAsync();
            }

            if (!context.Promotions.Any())
            {
                var promotionData = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/promotions.json");
                var promotions = JsonSerializer.Deserialize<List<Promotion>>(promotionData, options);
                if (promotions == null) return;
                context.Promotions.AddRange(promotions);
                await context.SaveChangesAsync();
            }

            if (!context.Orders.Any())
            {
                var orderDatas = await File
                    .ReadAllTextAsync(path + @"/Data/SeedData/orders.json");
                var orderResult = JsonSerializer.Deserialize<List<Order>>(orderDatas);
                if (orderResult == null) return;
                context.Orders.AddRange(orderResult);
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
