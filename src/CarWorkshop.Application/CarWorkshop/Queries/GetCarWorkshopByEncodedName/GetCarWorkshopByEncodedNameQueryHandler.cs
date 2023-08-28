using MediatR;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using CarWorkshop.Domain.Interfaces;
using AutoMapper;

namespace CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName
{
    public class GetCarWorkshopByEncodedNameQueryHandler : IRequestHandler<GetCarWorkshopByEncodedNameQuery, CarWorkshopDto>
    {
        private readonly ICarWorkshopRepository carWorkshopRepository;
        private readonly IMapper mapper;

        public GetCarWorkshopByEncodedNameQueryHandler(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            this.carWorkshopRepository = carWorkshopRepository;
            this.mapper = mapper;
        }

        public async Task<CarWorkshopDto> Handle(GetCarWorkshopByEncodedNameQuery request, CancellationToken cancellationToken)
        {
            var carWorkshop = await carWorkshopRepository.GetByEncodedName(request.EncodedName);
            var carWorkshopDto = mapper.Map<CarWorkshopDto>(carWorkshop);
            return carWorkshopDto;
        }
    }
}
