using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_anuncios.Validations.Enums;

namespace dotnet_webapi_anuncios.Dtos.Product
{
    public class UpdateProductRequestDto
    {
        [Required]
        [MinLength(5, ErrorMessage = "Nome deve conter no mínimo 5 caracteres.")]
        [MaxLength(100, ErrorMessage = "Nome não pode ter mais de 100 caracteres.")]
        public string Nome { get; set; } = string.Empty;

        [Required]
        [FutureDate(ErrorMessage = "A data de publicação não pode ser anterior à data de hoje.")]
        public DateTime DataPublicacao { get; set; } = DateTime.Now;

        [Required]
        [Range(1, Double.MaxValue, ErrorMessage = "O Valor deve ser no mínimo R$1,00")]
        public decimal Valor { get; set; }

        [Required]
        [ValidEnum(typeof(Cidade), ErrorMessage = "Selecione uma cidade válida.")]
        public string Cidade { get; set; } = string.Empty;

        [Required]
        [ValidEnum(typeof(Categoria), ErrorMessage = "Selecione uma Categoria válida.")]
        public string Categoria { get; set; } = string.Empty;

        [Required]
        [ValidEnum(typeof (Modelo), ErrorMessage = "Selecione um Modelo válido.")]
        public string Modelo { get; set; } = string.Empty;

        [Required]
        [ValidEnum(typeof(Condicao), ErrorMessage = "Selecione uma condição válida para o produto.")]
        public string Condicao { get; set; } = string.Empty;

        [Required(ErrorMessage = "A quantidade deve ser no mínimo 1 unidade.")]
        [Range(1, int.MaxValue, ErrorMessage = "Quantidade deve ser maior ou igual a 1.")]
        public int Quantidade { get; set; }
    }
}