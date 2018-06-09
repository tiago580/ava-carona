using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class CaronaCaroneiro
    {
        public CaronaCaroneiro()
        {

        }
        public CaronaCaroneiro(Carona carona, Colaborador caroneiro)
        {
            Carona = carona;
            Caroneiro = caroneiro;
            StatusCarona = StatusCarona.PENDENTE;

        }
        public int CaronaId { get; set; }
        public int CaroneiroId { get; set; }

        private Carona _carona;

        public Carona Carona
        {
            get
            {
                return _carona;
            }

            set
            {
                _carona = value ?? throw new ArgumentNullException("Carona não informada.");
            }
        }

        private Colaborador _caroneiro;
        public Colaborador Caroneiro
        {
            get
            {
                return _caroneiro;
            }

            set
            {
                _caroneiro = value ?? throw new ArgumentNullException("Caroneiro não informado.");
            }
        }
        public StatusCarona StatusCarona
        {
            get;
            set;
        }

    }
}
