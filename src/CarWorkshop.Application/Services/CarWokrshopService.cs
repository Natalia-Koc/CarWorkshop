using AutoMapper;
using CarWorkshop.Application.CarWorkshop;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CarWorkshop.Application.Services
{
    public class CarWokrshopService : ICarWokrshopService
    {
        private readonly ICarWorkshopRepository _carWorkshopRepository;
        private readonly IMapper _mapper;

        public CarWokrshopService(ICarWorkshopRepository carWorkshopRepository, IMapper mapper)
        {
            _carWorkshopRepository = carWorkshopRepository;
            _mapper = mapper;
        }

        public async Task Create(CarWorkshopDto carWorkshopDto)
        {
            var carWorkshop = _mapper.Map<Domain.Entities.CarWorkshop>(carWorkshopDto);
            carWorkshop.EncodeName();
            await _carWorkshopRepository.Create(carWorkshop);
        }

        public async Task<IEnumerable<CarWorkshopDto>> GetAll()
        {
            var cars = await _carWorkshopRepository.GetAll();
            var carsDto = _mapper.Map<IEnumerable<CarWorkshopDto>>(cars);
            return carsDto;
        }
    }
}
