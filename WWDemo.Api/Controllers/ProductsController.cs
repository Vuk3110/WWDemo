﻿using MediatR;
using Microsoft.AspNetCore.Mvc;
using WWDemo.Api.Requests;
using WWDemo.Application.DTOs;
using WWDemo.Application.Products.Commands.AddProduct;
using WWDemo.Application.Products.Commands.UpdateProduct;
using WWDemo.Application.Products.Queries.GetAllProducts;
using WWDemo.Application.Products.Queries.GetProductBySerialNumber;
using WWDemo.Application.Products.Queries.DeleteProductBySerialNumber;

namespace WWDemo.Api.Controllers
{
    [Route("[controller]")]
	[ApiController]
	public class ProductsController : ControllerBase
	{
		private readonly IMediator _mediator;

        public ProductsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
		[ProducesResponseType(200)]
		[ProducesResponseType(400)]
		public async Task<IActionResult> AddProduct(AddProductRequest request)
		{
			await _mediator.Send(new AddProductCommand
			{
				Name = request.Name,
				Price = request.Price,
				SerialNumber = request.SerialNumber,
				Category = request.Category,
            });

            return Ok();
        }

        [HttpPut("{serial-number}")]
        [ProducesResponseType(200)]
        [ProducesResponseType(400)]
        [ProducesResponseType(404)]

        public async Task<IActionResult> UpdateProduct([FromRoute(Name = "serial-number")] string serialNumber, UpdateProductRequest request)
        {
    
            // Call the mediator to execute the update command
            await _mediator.Send(new UpdateProductCommand
            {
                Name = request.Name,
                Price = request.Price,
                SerialNumber = serialNumber,
                NewSerialNumber = request.NewSerialNumber,
                Category = request.Category,// Pass the updated product to the command
            });

            return Ok();
        }


        [HttpGet]
        [ProducesResponseType(typeof(List<ProductRepresentation>), StatusCodes.Status200OK)]
        public async Task<List<ProductRepresentation>> GetAllProducts()
		{
			var result = await _mediator.Send(new GetAllProductsQuery());

			return result;
		}

		[HttpGet("{serial-number}")]
		public async Task<ProductRepresentation> GetProductBySerialNumber([FromRoute(Name = "serial-number")]string serialNumber)
		{
            var result = await _mediator.Send(new GetProductBySerialNumberQuery(serialNumber));
            
			return result;
		}

        [HttpDelete("{serial-number}")]
        public async Task<Unit> DeleteProductBySerialNumber([FromRoute(Name = "serial-number")] string serialNumber)
        {
            var result = await _mediator.Send(new DeleteProductBySerialNumberQuery(serialNumber));

            return result;
        }

    }
}
