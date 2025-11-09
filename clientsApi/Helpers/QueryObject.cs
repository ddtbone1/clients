using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace clientsApi.Helpers
{
    public class QueryObject
    {
        public string? Name { get; set; } = null;
        public string? CompanyName { get; set; } = null;
        public string? SortBy { get; set; } = null; //Name, CompanyName
        public bool IsDescending { get; set; } = false;
        public int PageNumber { get; set; } = 1;
        public int PageSize { get; set; } = 10;
    }
}