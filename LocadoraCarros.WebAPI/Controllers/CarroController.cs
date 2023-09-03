using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using LocadoraCarros.WebUI.Controllers;
using LocadoraCarros.Application.Interfaces;
using LocadoraCarros.Application.DTO;
using Microsoft.OpenApi.Models;

namespace LocadoraCarros.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class CarroController : ControllerBase
    {
        private readonly ICarroService _carroService;
        public CarroController(ICarroService carroService)
        {
            _carroService = carroService;
        }

        [HttpGet("Lista-de-Carros")]
        public async Task<ActionResult<IEnumerable<CarroDTO>>> Get()
        {
            var carros = await _carroService.GetCarros();
            if(carros == null)
            {
                return NotFound("Carros não encontrados!");
            }
            return Ok(carros);
        }

        [HttpGet("Buscar-Carro-por-Id")]
        public async Task<ActionResult<CarroDTO>> Get(int id)
        {
            var carro = await _carroService.BuscaPorId(id);
             if(carro == null)
            {
                return NotFound("Carro não encontrado!");
            }
            return Ok(carro);
        }

        [HttpPost("Create")]
        public async Task<IActionResult> Create(CarroDTO carroDTO)
        {
            if (ModelState.IsValid)
            {
                await _carroService.Add(carroDTO);
                return RedirectToAction(nameof(Index));
            }
            return Ok(carroDTO);
        }



        [HttpPost("")]
        public async Task<ActionResult> Post([FromBody] CarroDTO carroDTO)
        {
            if(carroDTO == null)
                return BadRequest("valores inválidos!");
            
            await _carroService.Add(carroDTO);
            return new CreatedAtRouteResult("GetCarro", new {id = carroDTO.Id}, carroDTO);
        }

        [HttpPut("Editar-Carro")]
        public async Task<ActionResult> Put(int id, [FromBody] CarroDTO carroDTO)
        {
            if(id != carroDTO.Id)
                return BadRequest();
            if(carroDTO == null)
                return BadRequest();

            await _carroService.Update(carroDTO);
            return Ok(carroDTO);
        }

        [HttpDelete("Exclui-Carro")]
        public async Task<ActionResult> Delete(int id)
        {
            var carro = await _carroService.BuscaPorId(id);
            if (carro == null)
                return NotFound("Carro não encontrado!");
            await _carroService.Remove(id);
            return NoContent();
        }

        [HttpPost("{id}/Alugar")]
        public async Task<IActionResult> AlugarCarro(int id, DateTime dataInicio, DateTime dataFim, decimal valorAluguel)
        {
            var carro = await _carroService.BuscaPorId(id);
    
            if (carro == null)
                return NotFound();

            if (carro.Status == CarroStatus.Alugado)
            {
                ModelState.AddModelError(string.Empty, "Este carro já está alugado.");
                var carrosAluguel = await _carroService.GetCarros(); 
                return Ok(carrosAluguel);
            }

            carro.Status = CarroStatus.Alugado;
            await _carroService.Update(carro);

            var carros = await _carroService.GetCarros();
            return RedirectToAction("Index");
        }

    }
}