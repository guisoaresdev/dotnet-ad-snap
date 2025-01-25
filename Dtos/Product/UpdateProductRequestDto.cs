using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_anuncios.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        public string Nome { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Condicao { get; set; } = string.Empty; 
        public int Quantidade { get; set; }
    }
}