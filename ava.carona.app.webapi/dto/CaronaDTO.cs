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
        public DateTime Horario { get; set; }
        public EnderecoDTO Origem { get; set; }
        public EnderecoDTO Destino { get; set; }
        public bool Bloqueado { get; set; }

    }
}
