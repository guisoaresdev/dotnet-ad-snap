using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_anuncios.Dtos
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; } = DateTime.Now;
        public decimal Valor { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Condicao { get; set; } = string.Empty; 
        public int Quantidade { get; set; }
    }
}
