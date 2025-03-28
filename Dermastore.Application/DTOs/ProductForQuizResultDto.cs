using Dermastore.Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dermastore.Application.DTOs
{
    public class ProductForQuizResultDto
    {
        public int id { get; set; }
        public string name { get; set; }
        public string description { get; set; }
        public ProductStatus status { get; set; }
        public int quantity { get; set; } = 1;
        public string imageUrl { get; set; }
        public int answerId {  get; set; }
        public decimal price { get; set; }
    }
}
