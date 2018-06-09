using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class CaronaCaroneiro
    {
        public int CaronaId { get; set; }
        public int CaroneiroId { get; set; }

        public Carona Carona { get; set; }
        public Colaborador Caroneiro { get; set; }
        public bool Permitido { get; set; }
    }
}
