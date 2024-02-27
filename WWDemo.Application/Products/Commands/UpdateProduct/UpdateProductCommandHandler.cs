using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Data.Products;
using WWDemo.Models;

namespace WWDemo.Application.Products.Commands.UpdateProduct
{
    internal class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand, ProductRepresentation>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }
        public async Task<ProductRepresentation> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var existingProduct = await _productRepository.GetProductBySerialNumber(request.SerialNumber);

            if (existingProduct == null)
            {
                throw new Exception($"Product with serial number '{request.SerialNumber}' not found.");
            }

            // Update the existing product with the new information
            existingProduct.Name = request.Name;
            existingProduct.Price = request.Price;
            existingProduct.SerialNumber = request.NewSerialNumber;
            existingProduct.Category = request.Category;

           var result = await _productRepository.UpdateProduct(existingProduct);
          

            return new ProductRepresentation { SerialNumber = result.SerialNumber };
        }
    }
}
