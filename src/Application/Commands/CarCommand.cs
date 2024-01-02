using Application.Dto_s.CarDto;
using MediatR;


namespace Application.Commands
{
    public record CreateCarCommand(AddUpdateCarDto dto):IRequest<Guid>;

    public record UpdateCarCommand(Guid Id, AddUpdateCarDto dto):IRequest<string>;

    public record DeleteCarCommand(Guid Id):IRequest<string>;
    public record SoftDeleteCarCommand(Guid Id):IRequest<string>;
}
