

using Application.Dto_s.UserDto;
using Domain.Models;
using MediatR;

namespace Application.Commands
{
    public record CreateUserCommand(AddUpdateUserDto dto):IRequest<Guid>;

    public record UpdateUserCommand(Guid Id, AddUpdateUserDto dto):IRequest<string>;

    public record DeleteUserCommand(Guid Id):IRequest<string>;
    public record SoftDeleteUserCommand(Guid Id):IRequest<string>;
}
