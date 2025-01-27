using Dermastore.Domain.Entities;
using MediatR;

namespace Dermastore.Application.Queries.Products
{
    public class GetCategoriesQuery : IRequest<IReadOnlyList<Category>>
    {
    }
}
