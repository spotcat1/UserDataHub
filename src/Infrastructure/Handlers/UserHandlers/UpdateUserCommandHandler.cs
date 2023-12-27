

using Application.Commands;
using Application.Contracts;
using Application.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handlers
{
    internal class UpdateUserCommandHandler : IRequestHandler<UpdateUserCommand, string>
    {

        private readonly IUser _user;

        public UpdateUserCommandHandler(IUserRepository userRepository, IUser user )
        {
            
            _user = user;
        }


        public async Task<string> Handle(UpdateUserCommand request, CancellationToken cancellationToken)
        {
            return await _user.UpdateUser(request.Id,request.dto);
        }
    }
}
