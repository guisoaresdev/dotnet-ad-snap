using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace dotnet_webapi_anuncios.Dtos.Service
{
    public class UpdateServiceRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome do serviço deve ter no mínimo 5 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome do serviço não pode exceder 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [FutureDate]
        public DateTime DataPublicacao { get; set; } = DateTime.Now;

        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "O valor do serviço deve ser no mínimo R$1,00")]
        public decimal Valor { get; set; }

        [Required]
        [EnumDataType(typeof (Cidade), ErrorMessage = "Selecione uma cidade válida.")]
        public string Cidade { get; set; } = string.Empty;
    }
}