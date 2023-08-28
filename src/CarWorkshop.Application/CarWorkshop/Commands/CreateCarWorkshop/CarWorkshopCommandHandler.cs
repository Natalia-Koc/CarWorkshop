using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkShop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkshop
{
    public class CarWorkshopCommandHandler : IRequestHandler<CreateCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWorkshopCommandHandler( ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(CreateCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(request);
            carWorkshop.EncodeName();
            await _carWorkshopRepository.Create(carWorkshop);

            return Unit.Value;
        }
    }
}
