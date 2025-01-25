using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_anuncios.Dtos.Service
{
    public class UpdateServiceRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Cidade { get; set; } = string.Empty;
    }
}