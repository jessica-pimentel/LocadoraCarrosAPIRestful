using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using LocadoraCarros.Application.DTO;
using LocadoraCarros.Application.Interfaces;
using LocadoraCarros.Domain.Interfaces;
using LocadoraCarros.Domain.Entities;

namespace LocadoraCarros.Application.Services
{
    public class AluguelService : IAluguelService
    {
        private IAluguelRepository _aluguelRepository;
        private readonly IMapper _mapper;
        public AluguelService(IMapper mapper, IAluguelRepository aluguelRepository)
        {
            _aluguelRepository = aluguelRepository ?? throw new ArgumentNullException(nameof(aluguelRepository));
            _mapper = mapper;
            
        }

        public async Task<IEnumerable<AluguelDTO>> getAluguelAsync()
        {
            var aluguelEntity = await _aluguelRepository.getAluguelAsync();
            return _mapper.Map<IEnumerable<AluguelDTO>>(aluguelEntity);
        }

        public async Task<AluguelDTO> BuscaPorIdAsync(int? id)
        {
            var aluguelEntities = await _aluguelRepository.BuscaPorIdAsync(id);
            return _mapper.Map<AluguelDTO>(aluguelEntities);
        }

        public async Task<AluguelDTO> getAluguelCarroAsync(int? id)
        {
            var aluguelEntity = await _aluguelRepository.getAluguelCarroAsync(id);
            return _mapper.Map<AluguelDTO>(aluguelEntity);
        }

        public async Task Add(AluguelDTO aluguelDTO)
        {
            var aluguelEntity = _mapper.Map<Aluguel>(aluguelDTO);
            await _aluguelRepository.CreateAsync(aluguelEntity);
        }

        public async Task Update(AluguelDTO aluguelDTO)
        {
            var aluguelEntity = _mapper.Map<Aluguel>(aluguelDTO);
            await _aluguelRepository.UpdateAsync(aluguelEntity);
        }

        public async Task Remove(int? id)
        {
            var aluguelEntity = _aluguelRepository.BuscaPorIdAsync(id).Result;
            await _aluguelRepository.RemoveAsync(aluguelEntity.Id);
        }
    }
}