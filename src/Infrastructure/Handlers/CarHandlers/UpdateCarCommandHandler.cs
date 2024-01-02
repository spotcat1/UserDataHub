using Application.Commands;
using Application.Services.Interfaces;
using MediatR;


namespace Infrastructure.Handlers.CarHandlers
{
    internal class UpdateCarCommandHandler:IRequestHandler<UpdateCarCommand,string>
    {
        private readonly ICar _car;

        public UpdateCarCommandHandler(ICar car)
        {
            _car = car;
        }

        public async Task<string> Handle(UpdateCarCommand request, CancellationToken cancellationToken)
        {
            return await _car.UpdateCar(request.Id, request.dto);
        }
    }
}
