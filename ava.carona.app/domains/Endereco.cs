using System;
using System.Collections.Generic;
using System.Text;

namespace ava.carona.app.domains
{
    public class Endereco: AEntidade
    {
        public string Numero { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }

        public Carona Carona { get; set; }
    }
}
