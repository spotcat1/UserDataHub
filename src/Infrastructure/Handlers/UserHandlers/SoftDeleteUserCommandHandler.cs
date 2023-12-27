
using Application.Commands;
using Application.Contracts;
using MediatR;


namespace Infrastructure.Handlers
{
    internal class SoftDeleteUserCommandHandler : IRequestHandler<SoftDeleteUserCommand, string>
    {
        private readonly IUserRepository _userRepository;

        public SoftDeleteUserCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        public async Task<string> Handle(SoftDeleteUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.SoftDeleteUser(request.Id);
        }
    }
}
