using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_anuncios.Dtos
{
    public class ServiceDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        public decimal Valor { get; set; }
        public string Cidade { get; set; } = string.Empty;
    }
}