using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Application.Services;
using CarWorkshop.Application.CarWorkshop;
using Microsoft.AspNetCore.Mvc.Formatters;
using FluentValidation;

namespace CarWorkshop.MVCv2.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly ICarWokrshopService _carWorkshopService;

        public CarWorkshopController(ICarWokrshopService carWorkshopService)
        {
            _carWorkshopService = carWorkshopService;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshopList = await _carWorkshopService.GetAll();
            return View(carWorkshopList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarWorkshopDto carWorkshop)
        {
            if (!ModelState.IsValid)
            {
                return View(carWorkshop);
            }
            await _carWorkshopService.Create(carWorkshop);
            return RedirectToAction(nameof(Index));
        }
    }
}
