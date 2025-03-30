using MediatR;

namespace Dermastore.Application.Queries.Policies
{
    public class GetPolicyQuery : IRequest<string>
    {
        public string fileName { get; set; }
        public GetPolicyQuery(string fileName)
        {
            this.fileName = fileName;
        }
    }
}
