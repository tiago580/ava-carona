using System;
using System.Collections.Generic;
using System.Text;
using ava.carona.app.helpers;

namespace ava.carona.app.domains
{
    public class CaronaCaroneiro
    {
        public CaronaCaroneiro()
        {

        }
        public CaronaCaroneiro(Carona carona, Colaborador caroneiro): base()
        {
            carona.ValidarArgumentoNulo();
            caroneiro.ValidarArgumentoNulo();

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
                //value.ValidarArgumentoNulo("Carona não informada.");
                _carona = value;
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
                //value.ValidarArgumentoNulo("Caroneiro não informado.");
                _caroneiro = value;
            }
        }
        public StatusCarona StatusCarona
        {
            get;
            set;
        }

    }
}
