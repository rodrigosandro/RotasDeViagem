using AutoMapper;
using RotasDeViagem.Application.DTOs;
using RotasDeViagem.Application.Interfaces;
using RotasDeViagem.Domain.Entidades;
using RotasDeViagem.Domain.Interfaces.Repository;
using System.Collections.Generic;

namespace RotasDeViagem.Application.Services
{
    public class VooService : IVooService
    {
        private IVooRepository _vooRepository;
        private readonly IMapper _mapper;

        public VooService(IVooRepository vooRepository, IMapper mapper)
        {
            _vooRepository = vooRepository;
            _mapper = mapper;
        }

        public List<VooDTO> GetVoos()
        {
            var voosEntidades = _vooRepository.GetVoos();
            return _mapper.Map<List<VooDTO>>(voosEntidades);
        }

        public VooDTO GetById(int id)
        {
            var vooEntidade = _vooRepository.GetById(id);
            return _mapper.Map<VooDTO>(vooEntidade);
        }

        public List<VooDTO> GetMelhorRota(string origem, string destino)
        {
            var voosEntidades = _vooRepository.GetVoos().FindAll(x => x.Origem == origem && x.Destino == destino);
            return _mapper.Map<List<VooDTO>>(voosEntidades);
        }
        public void Create(Voo2DTO vooDTO)
        {
            var vooEntidade = _mapper.Map<Voo>(vooDTO);
            _vooRepository.Create(vooEntidade);
        }

        public void Update(VooDTO vooDTO)
        {
            var vooEntidade = _mapper.Map<Voo>(vooDTO);
            _vooRepository.Update(vooEntidade);
        }
        public void Remove(int id)
        {
            Voo vooEntidade = _vooRepository.GetById(id);
            if (vooEntidade != null)
                _vooRepository.Remove(vooEntidade);
        }
    }
}
