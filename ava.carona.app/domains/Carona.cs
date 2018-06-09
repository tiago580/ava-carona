using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace ava.carona.app.domains
{
    public enum StatusCarona
    {
        PENDENTE,
        PERMITIDO,
        NEGADO
    }
    public class Carona : AEntidadeBloqueavel
    {
        private const string MSG_OFERTANTE_NAO_INFORMADO = "Ofertante da carona não informado.";
        private Colaborador _ofertante;
        public Colaborador Ofertante
        {
            get
            {
                return _ofertante;
            }
            set
            {
                VerificarArgumentoNulo(value, MSG_OFERTANTE_NAO_INFORMADO);

                if (value.EstaBloqueado())
                {
                    throw new ColaboradorBloqueadoException("Colaborador sem permissão para oferecer carona.");
                }

                _ofertante = value;
            }
        }

        private void verificarOfertante()
        {
            VerificarArgumentoNulo(_ofertante, MSG_OFERTANTE_NAO_INFORMADO);
        }
        public int VagasTotal { get; set; }
        public int VagasDisponiveis { get; set; }
        public int VagasOcupadas { get; set; }
        public bool ExisteCaroneiro(Colaborador caroneiro)
        {
            return ObterPorCaroneiro(caroneiro) != null;
        }

        public StatusCarona PermitirCarona(Colaborador caroneiro)
        {   
            return AlterarStatusCarona(caroneiro, StatusCarona.PERMITIDO);
        }

        public StatusCarona NegarCarona(Colaborador caroneiro)
        {
            return AlterarStatusCarona(caroneiro, StatusCarona.NEGADO);
        }
        private StatusCarona AlterarStatusCarona(Colaborador caroneiro, StatusCarona status)
        {
            verificarOfertante();

            VerificarArgumentoNulo(caroneiro);

            if (!ExisteCaroneiro(caroneiro))
            {
                throw new CaroneiroNaoEncontradoException();
            }

            Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).Select(cc => cc.StatusCarona = status).ToList();
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }


        public StatusCarona ObterStatusCarona(Colaborador caroneiro)
        {
            return ObterPorCaroneiro(caroneiro).StatusCarona;
        }
        public CaronaCaroneiro ObterPorCaroneiro(Colaborador caroneiro)
        {
            verificarOfertante();

            VerificarArgumentoNulo(caroneiro);
            return Caroneiros.Where(cc => cc.Caroneiro.Equals(caroneiro)).FirstOrDefault();
        }


        public void SolicitarCarona(Colaborador caroneiro)
        {
            verificarOfertante();
            VerificarArgumentoNulo(caroneiro);
            if (EstaBloqueado())
            {
                throw new CaronaBloqueadaException();
            }
            if (caroneiro.EstaBloqueado())
            {
                throw new ColaboradorBloqueadoException("Colaborador sem permissão para solicitar carona.");
            }

            if (caroneiro.Equals(_ofertante))
            {
                throw new OfertanteComoCaroneiroException("Não é permitido o próprio ofertante ocupar vaga na própria carona.");
            }

            Caroneiros.Add(new CaronaCaroneiro(this, caroneiro));
        }

      
        public Endereco Origem { get; set; }
        public Endereco Destino { get; set; }
        public IList<CaronaCaroneiro> Caroneiros { get; set; } = new List<CaronaCaroneiro>();

        public Carona()
        {
        }

        public Carona(Colaborador ofertante)
        {
            VerificarArgumentoNulo(ofertante, MSG_OFERTANTE_NAO_INFORMADO);
            _ofertante = ofertante;
        }

        public bool Equals(Carona obj)
        {
            VerificarArgumentoNulo(obj);

            if (!(obj is Carona))
            {
                throw new TiposDiferentesException();
            }

            var _obj = obj as Carona;
            if (this.Id == _obj.Id)
            {
                return true;
            }

            return false;

        }

    }
}
