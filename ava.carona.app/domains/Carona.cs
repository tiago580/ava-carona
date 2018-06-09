using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class Carona: AEntidade
    {
        public Colaborador Ofertante { get; set; }
        public int VagasTotal { get; set; }
        public int VagasDisponiveis { get; set; }
        public int VagasOcupadas { get; set; }

        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public IList<CaronaCaroneiro> Caroneiros { get; set; } = new List<CaronaCaroneiro>();
    }
}
