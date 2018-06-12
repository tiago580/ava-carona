using ava.carona.app.domains;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ava.carona.app.webapi.dto
{
    public class CaroneiroDTO: ColaboradorDTO
    {
        [JsonConverter(typeof(StringEnumConverter))]
        public StatusCarona StatusCarona { get; set; }

    }
}
