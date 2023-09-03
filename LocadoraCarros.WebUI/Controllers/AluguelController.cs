using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using LocadoraCarros.Application.DTO;
using LocadoraCarros.Application.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace LocadoraCarros.WebUI.Controllers
{
    public class AluguelController : Controller
    {
        private readonly IAluguelService _aluguelService;

        public AluguelController(IAluguelService aluguelService)
        {
            _aluguelService = aluguelService;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var aluguel = await _aluguelService.getAluguelAsync();
            return View(aluguel);
        }


        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var aluguelDTO = new AluguelDTO();

            return View(aluguelDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Create(AluguelDTO aluguelDTO)
        {
            if (ModelState.IsValid)
            {
                await _aluguelService.Add(aluguelDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(aluguelDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null) return NotFound();
            var aluguelDTO = await _aluguelService.BuscaPorIdAsync(id);
            if (aluguelDTO == null) return NotFound();
            return View(aluguelDTO);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(AluguelDTO aluguelDTO)
        {
            if (ModelState.IsValid)
            {
                await _aluguelService.Update(aluguelDTO);
                return RedirectToAction(nameof(Index));
            }
            return View(aluguelDTO);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null) return NotFound();
            var aluguelDTO = await _aluguelService.BuscaPorIdAsync(id);
            if (aluguelDTO == null) return NotFound();
            return View(aluguelDTO);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _aluguelService.Remove(id);
            return RedirectToAction("Index");
        }

        [HttpGet] // Talvez esse precise apagar
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null) return NotFound();
            var aluguelDTO = await _aluguelService.BuscaPorIdAsync(id);
            if (aluguelDTO == null) return NotFound();
            return View(aluguelDTO);
        }

        private async Task<bool> VerificarDisponibilidadeCarro(int carroId)
        {
            // Aqui você deve implementar a lógica para verificar a disponibilidade do carro.
            // Por enquanto, retornamos sempre true.
            return true;
        }
    }
}
