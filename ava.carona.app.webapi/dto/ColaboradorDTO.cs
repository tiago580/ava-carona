using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ava.carona.app.webapi.dto
{
    public class ColaboradorDTO
    {
        public string EID { get; set; }
        public int PID { get; set; }
        public string Nome { get; set; }
        public bool Bloqueado { get; set; }
    }
}
