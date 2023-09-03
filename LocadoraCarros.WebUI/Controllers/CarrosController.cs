using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.DTO;
using LocadoraCarros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace LocadoraCarros.WebUI.Controllers
{
    public class CarrosController : Controller
    {
        private readonly ICarroService _carroService;

        public CarrosController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {   
            var carros = await _carroService.GetCarros();
            return View(carros);
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        /*[HttpPost]
        public async Task<IActionResult> Create(CarroDTO carroDTO)
        {
            if (ModelState.IsValid)
            {
                await _carroService.Add(carroDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(carroDTO);
        }
        */

        [HttpGet()]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var carroDTO = await _carroService.BuscaPorId(id);
            if (carroDTO == null) return NotFound();
            return View(carroDTO);
        }

        [HttpPost()]
        public async Task<IActionResult> Edit(CarroDTO carroDTO)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    await _carroService.Update(carroDTO);
                }catch (Exception)
                {
                    throw;
                }
                return RedirectToAction(nameof(Index));
            }
            return View(carroDTO);
        }

        [HttpGet()]
        public async Task<IActionResult> Delete(int? id)
        {
            if(id == null) return NotFound();
            var carroDto = await _carroService.BuscaPorId(id);
            if (carroDto == null) return NotFound();
            return View(carroDto);
        }

        [HttpPost(), ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _carroService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet()]//talvez esse precise apagar
        public async Task<IActionResult> Details(int? id)
        {
            if(id == null) return NotFound();
            var carroDTO = await _carroService.BuscaPorId(id);
            if(carroDTO == null) return NotFound();
            return View(carroDTO);

        }
    }
}