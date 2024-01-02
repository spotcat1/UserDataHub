using Application.Commands;
using Application.Contracts;
using MediatR;

namespace Infrastructure.Handlers.CarHandlers
{
    internal class SoftDeleteCarCommandHandler:IRequestHandler<SoftDeleteCarCommand,string>
    {
        private readonly ICarRepository _carRepository;

        public SoftDeleteCarCommandHandler(ICarRepository carRepositor)
        {
            _carRepository = carRepositor;
        }

        public async Task<string> Handle(SoftDeleteCarCommand request, CancellationToken cancellationToken)
        {
            return await _carRepository.SoftDeleteCar(request.Id);
        }
    }
}
