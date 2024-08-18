
namespace Catalog.API.Products.CreateProduct
{
    public record CreateProductCommand(string Name,List<string> Category, string Description, string ImageFile, decimal Price) : ICommand<CreateProductResult>;
    public record CreateProductResult(Guid Id);
    internal class CreateProductCommandHandler(IDocumentSession session) : ICommandHandler<CreateProductCommand, CreateProductResult>
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
            session.Store(product);
            await session.SaveChangesAsync(cancellationToken);
            //return CreateProductResult result
            return new CreateProductResult(product.Id);
        }
    }
}
