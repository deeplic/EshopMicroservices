using BuildingBlocks.CQRS;
using Catalog.API.Models;
using MediatR;

namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler : ICommandHandler<CreateProductCommand, CreateProductResult>
    {
        public async Task<CreateProductResult> Handle(CreateProductCommand productCommand, CancellationToken cancellationToken)
        {
            //create product entity from command object
            var product = new Product
            {
                Name = productCommand.Name,
                Category = productCommand.Category,
                Description = productCommand.Description,
                ImageFile = productCommand.ImageFile,
                Price = productCommand.Price,
            };
            //save to database

            //return CreateProductResult result
            return new CreateProductResult(Guid.NewGuid());
        }
    }
}
