using Dermastore.Application.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Policies
{
    public class PolicyUploadCommand : IRequest<string>
    {
        public FileUploadDto fileUploadDto { get; set; }
        public PolicyUploadCommand(FileUploadDto fileUploadDto)
        {
            this.fileUploadDto = fileUploadDto;
        }
    }
}
