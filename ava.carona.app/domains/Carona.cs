using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class Carona : AEntidade
    {
        private Colaborador _ofertante;
        public Colaborador Ofertante
        {
            get
            {
                return _ofertante;
            }
            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("Ofertante da carona não informado.");
                }

                if (value.EstaBloqueado())
                {
                    throw new ColaboradorBloqueadoException("Colaborador sem permissão para oferecer carona.");
                }

                _ofertante = value;
            }
        }
        public int VagasTotal { get; set; }
        public int VagasDisponiveis { get; set; }
        public int VagasOcupadas { get; set; }

        public void SolicitarCarona(Colaborador caroneiro)
        {
            if (caroneiro == null)
            {
                throw new ArgumentNullException("Caroneiro não informado.");
            }
            if (caroneiro.EstaBloqueado())
            {
                throw new ColaboradorBloqueadoException("Colaborador sem permissão para solicitar carona.");
            }
        }

        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public IList<CaronaCaroneiro> Caroneiros { get; set; } = new List<CaronaCaroneiro>();
    }
}
