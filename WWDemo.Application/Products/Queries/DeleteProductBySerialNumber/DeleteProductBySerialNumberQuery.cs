using MediatR;
using WWDemo.Application.DTOs;

namespace WWDemo.Application.Products.Queries.DeleteProductBySerialNumber
{
    public class DeleteProductBySerialNumberQuery : IRequest<Unit>
    {
        public string? SerialNumber { get; set; }
        public DeleteProductBySerialNumberQuery(string SerialNumber)
        {
            this.SerialNumber = SerialNumber;
        }
    }
}
