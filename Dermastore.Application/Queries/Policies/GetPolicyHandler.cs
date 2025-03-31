using Dermastore.Domain.Interfaces;
using MediatR;

namespace Dermastore.Application.Queries.Policies
{
    public class GetPolicyHandler : IRequestHandler<GetPolicyQuery, string>
    {
        private readonly IFirebaseService firebaseService;
        public GetPolicyHandler(IFirebaseService firebaseService)
        {
            this.firebaseService = firebaseService;
        }
        public async Task<string> Handle(GetPolicyQuery request, CancellationToken cancellationToken)
        {
            return await firebaseService.GetPolicyUrlAsync(request.fileName);
        }
    }
}
