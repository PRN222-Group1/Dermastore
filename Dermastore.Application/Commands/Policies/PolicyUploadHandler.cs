using Dermastore.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Policies
{
    public class PolicyUploadHandler : IRequestHandler<PolicyUploadCommand, string>
    {
        private readonly IFirebaseService _firebaseService;
        public PolicyUploadHandler(IFirebaseService firebaseService)
        {
            _firebaseService = firebaseService;
        }
        public async Task<string> Handle(PolicyUploadCommand request, CancellationToken cancellationToken)
        {
            return await _firebaseService.UploadFile(request.fileUploadDto.fileStream, request.fileUploadDto.fileName, request.fileUploadDto.isImageUpload);
        }
    }
}
