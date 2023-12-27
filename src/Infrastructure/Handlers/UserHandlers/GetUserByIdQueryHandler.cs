


using Application.Dto_s.UserDto;
using Application.Queries;
using Application.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handlers
{
    internal class GetUserByIdQueryHandler : IRequestHandler<GetUserByIdQuery, GetUserbyIdDto>
    {
        private readonly IUser _user;


        public GetUserByIdQueryHandler(IUser user)
        {

            _user = user;
        }
        public async Task<GetUserbyIdDto> Handle(GetUserByIdQuery request, CancellationToken cancellationToken)
        {
            return await _user.GetUserById(request.Id, request.ShowIfIsDeleted);
        }
    }
}
