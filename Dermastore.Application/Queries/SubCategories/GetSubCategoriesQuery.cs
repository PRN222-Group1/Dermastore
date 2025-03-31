using Dermastore.Application.DTOs;
using MediatR;

namespace Dermastore.Application.Queries.SubCategories
{
    public class GetSubCategoriesQuery : IRequest<IReadOnlyList<SubCategoryDto>>
    {
    }
}
