using MediatR;

namespace Dermastore.Application.Commands.Users
{
    public class UpdateUserStatusCommand : IRequest<bool>
    {
        public int Id { get; set; }
        public int Status { get; set; }

        public UpdateUserStatusCommand(int id, int status)
        {
            Id = id;
            Status = status;
        }
    }
}
