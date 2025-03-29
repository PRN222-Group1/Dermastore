using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.Commands.Blogs
{
    public class DeleteBlogCommand : IRequest<bool>
    {
        public int Id { get; set; }

        public DeleteBlogCommand(int id)
        {
            this.Id = id;
        }
    }
}
