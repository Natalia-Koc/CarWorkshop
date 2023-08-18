using Microsoft.AspNetCore.Mvc;
using CarWorkshop.Domain.Entities;
using CarWorkshop.Domain.Interfaces;
using CarWorkshop.Application.CarWorkshop;
using Microsoft.AspNetCore.Mvc.Formatters;
using FluentValidation;
using MediatR;
using CarWorkshop.Application.CarWorkshop.Queries.GetAllCarWorkshop;
using CarWorkshop.Application.CarWorkshop.Commands.CreateCarWorkShop;

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
    }
}
