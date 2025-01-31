using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using dotnet_webapi_anuncios.Validations.Enums;

namespace dotnet_webapi_anuncios.Helpers
{
    public class QueryObject
    {
        public string? Valor {get; set;} = null;
        public string? Cidade {get; set;} = null;
        public string? SortBy {get; set;} = null;
        public bool IsDescending {get; set;} = false;
        
        public int PageNumber {get; set;} = 1;
        public int PageSize {get; set;} = 5;
    }
}