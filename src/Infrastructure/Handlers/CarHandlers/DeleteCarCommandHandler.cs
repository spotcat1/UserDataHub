using Application.Commands;
using Application.Contracts;
using MediatR;


namespace Infrastructure.Handlers.CarHandlers
{
    internal class DeleteCarCommandHandler : IRequestHandler<DeleteCarCommand, string>
    {
        private readonly ICarRepository _carRepository;

        public DeleteCarCommandHandler(ICarRepository carRepositor)
        {
            _carRepository = carRepositor;
        }

        public async Task<string> Handle(DeleteCarCommand request, CancellationToken cancellationToken)
        {
            return await _carRepository.DeleteCar(request.Id);
        }
    }
}
