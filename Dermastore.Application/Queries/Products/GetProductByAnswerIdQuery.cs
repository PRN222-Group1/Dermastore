using MediatR;
using Dermastore.Application.DTOs;

namespace Dermastore.Application.Queries.Products
{
    public class GetProductByAnswerIdQuery : IRequest<IReadOnlyList<ProductForQuizResultDto>>
    {
        public List<int> answerIds {  get; set; }
        public GetProductByAnswerIdQuery(List<int> answerIds)
        {
            this.answerIds = answerIds;
        }
    }
}
