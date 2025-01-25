using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace dotnet_webapi_anuncios.Models
{
    public class Product
    {
        public int Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public DateTime DataPublicacao { get; set; } = DateTime.Now;

        [Column(TypeName = "decimal(18,2)")]
        public decimal Valor { get; set; }
        public string Cidade { get; set; } = string.Empty;
        public string Categoria { get; set; } = string.Empty;
        public string Modelo { get; set; } = string.Empty;
        public string Condicao { get; set; } = string.Empty; 
        public int Quantidade { get; set; }
    }
}