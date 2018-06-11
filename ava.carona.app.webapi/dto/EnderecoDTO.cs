using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ava.carona.app.webapi.dto
{
    public class EnderecoDTO
    {
        public string Numero { get; set; }
        public string Logradouro { get; set; }
        public string Bairro { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}
