using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Application.CarWorkshop;
using Microsoft.AspNetCore.Mvc.Formatters;
using FluentValidation;
using MediatR;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkShop;
using CarWorkshop.Application.CarWorkshop.Queries.GetCarWorkshopByEncodedName;
using CarWorkshop.Application.CarWorkshop.Commands.EditCarWorkShop;

namespace CarWorkshopMVC.Controllers
{
    public class CarWorkshopController : Controller
    {
        private readonly IMediator _mediator;

        public CarWorkshopController(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task<IActionResult> Index()
        {
            var carWorkshopList = await _mediator.Send(new GetAllCarWorkshopQuery());
            return View(carWorkshopList);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }

        [Route("CarWorkshop/{encodedName}/Details")]
        public async Task<IActionResult> Details(string encodedName)
        {
            var carWorkshopDto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(carWorkshopDto);
        }

        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(string encodedName)
        {
            var carWorkshopDto = await _mediator.Send(new GetCarWorkshopByEncodedNameQuery(encodedName));
            return View(carWorkshopDto);
        }

        [HttpPost]
        [Route("CarWorkshop/{encodedName}/Edit")]
        public async Task<IActionResult> Edit(EditCarWorkshopCommand command)
        {
            if (!ModelState.IsValid)
            {
                return View(command);
            }
            await _mediator.Send(command);
            return RedirectToAction(nameof(Index));
        }
    }
}
