using AutoMapper;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkShop;
using CarWorkshop.Domain.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkshop
{
    public class EditCarWorkshopCommandHandler : IRequestHandler<EditCarWorkshopCommand>
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public EditCarWorkshopCommandHandler( ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task<Unit> Handle(EditCarWorkshopCommand request, CancellationToken cancellationToken)
        {
            var carWorkshopDto = await _carWorkshopRepository.GetByEncodedName(request.EncodedName!);
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);

            carWorkshop.Description = request.Description;
            carWorkshop.Name = request.Name;
            carWorkshop.About = request.About;
            carWorkshop.ContactDetails.City = request.City;
            carWorkshop.ContactDetails.PostalCode = request.PostalCode;
            carWorkshop.ContactDetails.PhoneNumber = request.PhoneNumber;
            carWorkshop.ContactDetails.Street = request.Street;
            carWorkshop.EncodeName();

            await _carWorkshopRepository.Commit();

            return Unit.Value;
        }
    }
}
