

using Application.Commands;
using Application.Services.Interfaces;
using MediatR;

namespace Infrastructure.Handlers.CarHandlers
{
    internal class CreateCarCommandHandler:IRequestHandler<CreateCarCommand,Guid>
    {
        private readonly ICar _car;

        public CreateCarCommandHandler(ICar car)
        {
            _car = car;
        }

        public async Task<Guid> Handle(CreateCarCommand request, CancellationToken cancellationToken)
        {
            return await _car.AddCar(request.dto);
        }
    }
}
