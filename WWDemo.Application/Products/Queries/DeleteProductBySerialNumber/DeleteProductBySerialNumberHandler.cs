using AutoMapper;
using MediatR;
using WWDemo.Application.DTOs;
using WWDemo.Data.Products;

namespace WWDemo.Application.Products.Queries.DeleteProductBySerialNumber
{
    public class DeleteProductBySerialNumberHandler : IRequestHandler<DeleteProductBySerialNumberQuery, Unit>
    {
        private readonly IProductRepository _productRepository;
        private readonly IMapper _mapper;

        public DeleteProductBySerialNumberHandler(IProductRepository productRepository, IMapper mapper)
        {
            _productRepository = productRepository;
            _mapper = mapper;
        }
        public async Task<Unit> Handle(DeleteProductBySerialNumberQuery request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteProductBySerialNumber(request.SerialNumber);
            return Unit.Value;

        }
    }
}
