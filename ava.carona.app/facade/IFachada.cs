using ava.carona.app.domains;
using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.facade
{
    public interface IFachada
    {
        #region Colaborador

        Colaborador CriarColaborador(Colaborador colaborador);

        IEnumerable<Colaborador> ListarColaboradores();

        Colaborador ObterColaborador(Colaborador colaborador);
        Colaborador ObterColaboradorPorId(int id);

        int DeletarColaborador(int id);

        Colaborador AtualizarColaborador(Colaborador colaborador, int id);
        Colaborador BloquearColaborador(Colaborador colaborador, int id);

        #endregion

        #region Carona
        Carona CriarCarona(Carona carona);

        IEnumerable<Carona> ListarCaronas();

        Carona ObterCarona(Carona carona);
        Carona ObterCaronaPorId(int id);
        IEnumerable<Carona> ListarCaronaPorOfertante(int ofertanteId);

        int DeletarCarona(int id);

        Carona AtualizarCarona(Carona carona, int id);


        #endregion
    }
}
