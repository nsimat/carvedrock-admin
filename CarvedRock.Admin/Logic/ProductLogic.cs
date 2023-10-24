using CarvedRock.Admin.Models;
using CarvedRock.Admin.Repository;

namespace CarvedRock.Admin.Logic;

public class ProductLogic : IProductLogic
{
    private readonly ICarvedRockRepository _repository;

    public ProductLogic(ICarvedRockRepository repository)
    {
        _repository = repository;
    }

    public async Task AddNewProduct(ProductModel productToAdd)
    {
        var productToSave = productToAdd.ToProduct();
        await _repository.AddProductAsync(productToSave);
    }

    public async Task<List<ProductModel>> GetAllProducts()
    {
        var products = await _repository.GetAllProductsAsync();

        // Converts products from DB to product models
        return products.Select(ProductModel.FromProduct).ToList();

        // the above is more terse syntax for:
        //var models = new List<ProductModel>();

        //foreach (var product in products)
        //{
        //    models.Add(ProductModel.FromProduct(product));
        //}
        //return models;
    }

    public async Task<ProductModel?> GetProductById(int id)
    {
        var product = await _repository.GetProductByIdAsync(id);
        return product == null ? null : ProductModel.FromProduct(product);
    }

    public async Task RemoveProduct(int id)
    {
        await _repository.RemoveProductAsync(id);
    }

    public async Task UpdateProduct(ProductModel productToUpdate)
    {
        var productToSave = productToUpdate.ToProduct();
        await _repository.UpdateProductAsync(productToSave);
    }
}