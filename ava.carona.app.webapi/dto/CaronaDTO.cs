using AutoMapper;
using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ava.carona.app.webapi.dto
{
    public class CaronaDTO
    {
        public int Id { get; set; }
        public Colaborador Ofertante { get; set; }
        public int VagasTotal { get; set; }
        public int VagasDisponiveis { get; set; }
        public DateTime Horario { get; set; }
        public EnderecoDTO Origem { get; set; }
        public EnderecoDTO Destino { get; set; }
        public bool Bloqueado { get; set; }
        public ICollection<CaroneiroDTO> Caroneiros { get; set; }

        public CaronaDTO()
        {

        }

        public CaronaDTO(Carona carona)
        {
            Id = carona.Id;
            VagasDisponiveis = carona.VagasDisponiveis;
            VagasTotal = carona.VagasTotal;
            Origem = Mapper.Map<EnderecoDTO>(carona.ObterEndereco(TipoEndereco.ORIGEM));
            Destino = Mapper.Map<EnderecoDTO>(carona.ObterEndereco(TipoEndereco.DESTINO));
            Ofertante = carona.Ofertante;
            Caroneiros = carona.Caroneiros.Where(c => true).Select(c => {
                var caroneiroDTO = Mapper.Map<CaroneiroDTO>(c.Caroneiro);
                caroneiroDTO.StatusCarona = c.StatusCarona;
                return caroneiroDTO;
            }).ToList();

        }

    }
}
