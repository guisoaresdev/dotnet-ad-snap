using dotnet_webapi_anuncios.Dtos;
using dotnet_webapi_anuncios.Dtos.Product;
using dotnet_webapi_anuncios.Dtos.Service;
using dotnet_webapi_anuncios.Models;

namespace dotnet_webapi_anuncios.Mappers
{
    public static class AnuncioMappers
    {
        public static ProductDto ToProductDto(this Product productModel)
        {
            return new ProductDto
            {
                Id = productModel.Id,
                Nome = productModel.Nome,
                DataPublicacao = productModel.DataPublicacao,
                Valor = productModel.Valor,
                Cidade = productModel.Cidade,
                Categoria = productModel.Categoria,
                Modelo = productModel.Modelo,
                Condicao = productModel.Condicao,
                Quantidade = productModel.Quantidade
            };
        }

        public static Product ToProductFromCreateDto(this CreateProductRequestDto productModel)
        {
            return new Product
            {
                Nome = productModel.Nome,
                Valor = productModel.Valor,
                Cidade = productModel.Cidade,
                Categoria = productModel.Categoria,
                Modelo = productModel.Modelo,
                Condicao = productModel.Condicao,
                Quantidade = productModel.Quantidade
            };
        }

        public static Product ToProductFromUpdateDto(this UpdateProductRequestDto productModel)
        {
            return new Product
            {
                Nome = productModel.Nome,
                Valor = productModel.Valor,
                Cidade = productModel.Cidade,
                Categoria = productModel.Categoria,
                Modelo = productModel.Modelo,
                Condicao = productModel.Condicao,
                Quantidade = productModel.Quantidade
            };
        }

        public static ServiceDto ToServiceDto(this Service serviceModel)
        {
            return new ServiceDto
            {
                Id = serviceModel.Id,
                Nome = serviceModel.Nome,
                DataPublicacao = serviceModel.DataPublicacao,
                Valor = serviceModel.Valor,
                Cidade = serviceModel.Cidade
            };
        }

        public static Service ToServiceFromCreateDto(this CreateServiceRequestDto serviceModel)
        {
            return new Service
            {
                Nome = serviceModel.Nome,
                Valor = serviceModel.Valor,
                Cidade = serviceModel.Cidade,
            };
        }

        public static Service ToServiceFromUpdateDte(this UpdateServiceRequestDto serviceModel)
        {
            return new Service
            {
                Nome = serviceModel.Nome,
                Valor = serviceModel.Valor,
                Cidade = serviceModel.Cidade,
            };
        }
    }
}