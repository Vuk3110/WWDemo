using MediatR;
using WWDemo.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WWDemo.Application.Products.Commands.UpdateProduct
{
    public class UpdateProductCommand : IRequest<ProductRepresentation>
    {
        public string? SerialNumber { get; set; }
        public string? Name { get; set; }
        public string? Price { get; set; }
        public string? Category { get; set; }
        public string? NewSerialNumber { get; set; }
    }
}
