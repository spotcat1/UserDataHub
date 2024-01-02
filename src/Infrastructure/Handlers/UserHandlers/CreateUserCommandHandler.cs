

using Application.Commands;
using Application.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handlers
{
    internal class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUser _user;


        public CreateUserCommandHandler(IUser user)
        {
            _user = user;
        }

        public async Task<Guid> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            return await _user.AddUser(request.dto);
        }
    }
}

